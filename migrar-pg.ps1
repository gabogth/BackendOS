param (
    [Parameter(Mandatory=$true)]
    [string]$Name
)

dotnet ef migrations add $Name `
    --context DbContextPsSql `
    --project ../nest.core.driver.postgres `
    --startup-project . `
    -- connection=Npgsql