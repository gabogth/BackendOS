# nest.core.view.security

Proyecto base en Angular 21 con arquitectura por capas para vista de seguridad.

## Stack
- Angular 21 (standalone components)
- Bootstrap 5.3
- TypeScript estricto

## Estructura base
- `src/app/core/layout`: shell y layout principal.
- `src/app/core/services`: servicios de aplicación.
- `src/app/core/entities`: entidades base.
- `src/app/features/main/pages`: página principal (`INDEX`).
- `src/app/shared/components`: componentes reutilizables.

## Ambientes
La app ahora soporta dos ambientes principales y sus variables en `src/environments`:

- `environment.development.ts` (DEV)
  - `production: false`
  - `envName: 'development'`
  - `apiBaseUrl: 'http://localhost:5080'`
- `environment.production.ts` (PRD)
  - `production: true`
  - `envName: 'production'`
  - `apiBaseUrl: 'https://api.tu-dominio.com'`

> Ajusta `apiBaseUrl` con la URL real de tu backend en cada ambiente.

## Ejecutar localmente con ng serve
```bash
npm install

# DEV (recomendado para desarrollo)
ng serve --configuration development
# o
npm run start:dev

# PRD (simula configuración de producción)
ng serve --configuration production
# o
npm run start:prd
```

También puedes usar:
```bash
npm start
```
que levanta `ng serve --configuration development`.
