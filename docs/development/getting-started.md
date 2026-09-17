# Cómo empezar

## Estado y requisitos

Phase 0 — Foundation: scaffolding técnico, sin funcionalidades de negocio. Leer [README](../../README.md), [AGENTS](../../AGENTS.md), [baseline](technical-baseline.md) y [pruebas](testing.md). Los resultados reales se registran en [verificación de Phase 0](phase-0-verification.md).

- .NET SDK 10.0.401; global.json permite patches de la misma banda, sin prereleases.
- Node.js 24.13.0 según .nvmrc y npm 11.6.2. Con nvm compatible, usar nvm install/nvm use; Windows puede instalar esa versión mediante su gestor habitual.
- Docker disponible con contenedores Linux para el test MySQL. No se necesita MySQL instalado ni una base de desarrollo.
- Chromium de Playwright para E2E; en Linux se requieren sus dependencias del sistema.

## Backend (desde la raíz)

```sh
dotnet --info
dotnet restore Tienda.slnx --locked-mode
dotnet build Tienda.slnx --no-restore --configuration Release
dotnet run --project src/backend/Tienda.Api --urls http://localhost:5080
```

GET http://localhost:5080/health devuelve Healthy si arranca. No consulta base de datos ni acredita readiness de negocio. Configuración base en appsettings.json; variables ASP.NET Core pueden sobrescribirla por entorno. No hay secretos ni connection strings de negocio.

```sh
dotnet test --solution Tienda.slnx --no-build --configuration Release
dotnet format Tienda.slnx --no-restore --verify-no-changes
dotnet format Tienda.slnx --no-restore
```

El runner es Microsoft.Testing.Platform (seleccionado en global.json), con xUnit v3. La primera orden de formato comprueba y la segunda aplica correcciones.

Si solo se desea ejecutar pruebas sin Docker, hacerlo explícitamente:

```sh
dotnet test --solution Tienda.slnx --no-build -c Release -- --filter-not-trait Category=Docker
```

Esto no verifica persistencia. El CI completo no utiliza ese filtro. La prueba Docker arranca y elimina su contenedor MySQL con credenciales efímeras de Testcontainers.

## Frontend (desde src/frontend)

```sh
node --version
npm --version
npm ci
npm run dev
```

Vite escucha en 127.0.0.1 y muestra su puerto (5173 por defecto). La pantalla no requiere API ni implementa administración/storefront.

```sh
npm run lint
npm run format:check
npm run format
npm run build
npm test
npm run test:watch
```

Lint usa Oxlint; formato usa Oxfmt. build comprueba TypeScript y genera dist; test ejecuta Vitest sin interacción. test:watch es solo para desarrollo.

```sh
npx playwright install chromium
npm run build
npm run test:e2e
```

En Ubuntu, instalar navegador y dependencias mediante `npx playwright install --with-deps chromium`. Playwright inicia vite preview en 127.0.0.1:4173 sobre dist y lo detiene; el puerto debe estar libre.

## CI y reproducibilidad

[ci.yml](../../.github/workflows/ci.yml) valida push/PR hacia main en Ubuntu 24.04: restore bloqueado, build Release, dotnet format y todos los tests backend; npm ci, lint, formato, build, Vitest y Playwright Chromium. No hay CD ni secretos cloud.

NuGet usa Central Package Management y packages.lock.json; npm usa package-lock.json. Para una actualización intencionada, modificar versiones centrales/package.json, regenerar locks con dotnet restore/npm install y repetir las verificaciones. No editar los locks manualmente.

## Limitaciones del equipo de validación

En este Windows, Docker no está instalado y Control de aplicaciones bloqueó algunas DLL de tests y el binding nativo de Rolldown. No desactivar ni eludir esa política; validar en un entorno autorizado como CI Ubuntu. La ausencia de dist por ese bloqueo también impide la smoke E2E local.

Si npm muestra UNABLE_TO_VERIFY_LEAF_SIGNATURE en este entorno, Node 24 puede usar el almacén de certificados del sistema. En PowerShell, `$env:NODE_USE_SYSTEM_CA = '1'` antes de npm ci resolvió la confianza TLS; no deshabilitar strict-ssl.

## Decisiones pendientes

Una o múltiples compañías por usuario, memberships, roles definitivos, invitaciones y alta administrativa siguen abiertas para Phase 1, antes del modelo funcional que las necesite. El scaffolding no las resuelve. También siguen abiertas las demás Open Questions de producto, persistencia, seguridad y despliegue; no crear entidades ficticias para llenar estas capas.
