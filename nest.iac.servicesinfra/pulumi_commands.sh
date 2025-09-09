#!/usr/bin/env bash
set -euo pipefail

# Pulumi local backend
pulumi login

# Selecciona el stack "dev"
pulumi stack select ${PULUMI_STACK} --non-interactive --create

# Ejecuta la actualizaci�n
pulumi refresh --yes
pulumi up --yes