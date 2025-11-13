<#
Simple script para:
 - loguear en ECR
 - construir/usar imagen desde folder nest.core.contabilidad con Dockerfile lambda.Dockerfile
 - taguear y pushear a ECR
 - actualizar Lambda con la nueva imagen

Ejemplo: desde la carpeta 'main':
  .\uploadimage.ps1
#>

param(
  [string]$fname    = "contabilidad"
)

$AwsRegion = "us-east-1"
$AwsAccountId = "949982764789"
$Repo = "nest-servicesinfra-$fname-ecr"
$ImageTag = "latest"
$LocalImage = "nest-servicesinfra-$fname-ecr:local"
$LambdaName = "nest-servicesinfra-$fname-lambda"
$ImageFolder = "nest.core.$fname"
$Dockerfile = "lambda.Dockerfile"

# Derived
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Definition
# contexto absoluto de la carpeta que contiene el Dockerfile
$imageContextPath = Join-Path -Path $scriptDir -ChildPath $ImageFolder
$ecrHost = "$AwsAccountId.dkr.ecr.$AwsRegion.amazonaws.com"
$ecrUri = "$ecrHost/$Repo`:$ImageTag"

Write-Host "Script dir: $scriptDir"
Write-Host "Image context: $imageContextPath"
Write-Host "Dockerfile: $Dockerfile"
Write-Host "ECR URI: $ecrUri"
Write-Host "Lambda: $LambdaName"
Write-Host ""

try {
	# 1) Login to ECR
	Write-Host "Logging into ECR..."
	aws ecr get-login-password --region $AwsRegion | docker login --username AWS --password-stdin $ecrHost
	if ($LASTEXITCODE -ne 0) { throw "ECR login failed" }

	# 2) Build image (use -f for custom Dockerfile and context = folder)
	$dockerfilePath = Join-Path -Path $imageContextPath -ChildPath $Dockerfile
	if (-not (Test-Path $dockerfilePath)) { throw "No se encontró Dockerfile en: $dockerfilePath" }

	Write-Host "Construyendo imagen desde '$imageContextPath' usando Dockerfile '$Dockerfile'..."
	docker build -t $ecrUri -f $dockerfilePath .
	if ($LASTEXITCODE -ne 0) { throw "docker build falló" }

	# 3) Tag y push
	#Write-Host "Tagging $LocalImage -> $ecrUri"
	#docker tag $LocalImage $ecrUri
	if ($LASTEXITCODE -ne 0) { throw "docker tag falló" }

	Write-Host "Pushing $ecrUri ..."
	docker push $ecrUri  --platform linux/amd64
	if ($LASTEXITCODE -ne 0) { throw "docker push falló" }

	# 4) Update Lambda
	Write-Host "Actualizando Lambda '$LambdaName' para usar la imagen $ecrUri ..."
	aws lambda update-function-code --function-name $LambdaName --image-uri $ecrUri --region $AwsRegion --no-cli-pager
	if ($LASTEXITCODE -ne 0) { throw "aws lambda update-function-code falló" }

	Write-Host ""
	Write-Host "✅ Hecho. Lambda actualizado. Revisa logs en CloudWatch: /aws/lambda/$LambdaName"
}
catch {
  Write-Host ""
  Write-Error "Error: $_"
  exit 1
}
