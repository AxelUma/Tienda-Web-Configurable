# Verificación del scaffolding de Phase 0

Registro del 16 de septiembre de 2026. Scaffolding sin funcionalidades de Phase 1; base técnica verificada en CI Ubuntu. Phase 1 no ha comenzado.

## Resultados locales (Windows)

| Comando / comprobación | Resultado |
| --- | --- |
| dotnet --info | SDK 10.0.401; runtime ASP.NET Core 10.0.12 |
| dotnet restore Tienda.slnx | Correcto; EF Core 10.0.12 y proveedor Oracle 10.0.9 restaurados |
| dotnet build Tienda.slnx --no-restore -c Release | Correcto, cero advertencias y errores |
| dotnet format Tienda.slnx --no-restore --verify-no-changes | Correcto |
| dotnet test inicial en modo VSTest | Falló por incompatibilidad del runner con Microsoft.Testing.Platform v2; corregido en global.json, eliminando adaptadores VSTest |
| dotnet test --solution Tienda.slnx --no-build -c Release | Dos pruebas HTTP correctas; Domain/Application no ejecutadas porque Control de aplicaciones bloqueó sus DLL (0x800711C7); MySQL falló al conectar al endpoint Docker |
| Pruebas HTTP con filtro explícito Category!=Docker | Dos correctas, cero fallos |
| docker version | Comando ausente; tampoco se encontró Docker Desktop en su ruta habitual |
| node --version / npm --version | 24.13.0 / 11.6.2 |
| npm install / npm ci inicial | Error de confianza TLS; resuelto usando NODE_USE_SYSTEM_CA=1, manteniendo validación TLS |
| npm ci final | Correcto, sin avisos engines; auditoría npm sin vulnerabilidades reportadas |
| npm run lint | Correcto |
| npm run format / format:check | Correctos |
| npx tsc -b | Correcto |
| npm run build / npm test | Bloqueados al cargar el binario nativo de Rolldown por Control de aplicaciones de Windows |
| npm run test:e2e | No pudo arrancar vite preview porque no existe dist tras el bloqueo del build |

## Ajustes técnicos y límites

- xunit.v3 4.0.1 usa Microsoft.Testing.Platform v2. Se seleccionó ese runner en global.json; dotnet test usa --solution o --project. No se cambió la familia xUnit v3.
- jsdom 30.1.0 requería Node >=24.15 en la línea 24. Se resolvió jsdom 29.1.1 estable compatible con Node 24.13, regenerando el lock y repitiendo npm ci sin advertencias de engines.
- No se alteraron las políticas de seguridad del equipo ni se sustituyó MySQL por InMemory. CI Ubuntu ejecutó todos los tests, incluida conectividad MySQL.
- La prueba MySQL usa el driver Oracle para SELECT VERSION(); no acredita aún consultas EF, migraciones ni aislamiento multi-tenant. No existe DbContext o dominio ficticio.
- La arquitectura aceptada no cambió. No hay negocio, Identity, compañías, roles, memberships, PageSection, pedidos, archivos, cloud ni correo implementados.

## CI

GitHub Actions en Ubuntu 24.04 terminó correctamente en la [ejecución 35172735099](https://github.com/AxelUma/Tienda-Web-Configurable/actions/runs/35172735099), sobre el scaffolding c0b0d5b antes de incorporar este cierre documental al mismo commit. El [PR #1](https://github.com/AxelUma/Tienda-Web-Configurable/pull/1) permanece en borrador; no hay merge, CD ni despliegue.

| Verificación en Ubuntu | Resultado |
| --- | --- |
| dotnet restore Tienda.slnx --locked-mode | Correcto |
| dotnet build Tienda.slnx --no-restore --configuration Release | Correcto, cero advertencias y errores |
| dotnet format Tienda.slnx --no-restore --verify-no-changes | Correcto |
| dotnet test --solution Tienda.slnx --no-build --configuration Release | 5 pruebas correctas, cero fallos: Domain, Application, dos HTTP y conectividad MySQL real |
| npm ci | Correcto |
| npm run lint / npm run format:check | Correctos |
| npm run build | Correcto, TypeScript y compilación Vite |
| npm test | 1 prueba Vitest/React Testing Library correcta |
| npx playwright install --with-deps chromium | Correcto |
| npm run test:e2e | 1 prueba Chromium correcta |

Los bloqueos locales siguen documentados; el resultado de Ubuntu no implica que esos binarios ya puedan ejecutarse en este Windows.

## Revisión del repositorio

- Siete proyectos incluidos en Tienda.slnx y siete locks NuGet; referencias por capas revisadas.
- package-lock.json versionado con bindings opcionales de Linux; TypeScript 6 y Vite 8 confirmados.
- Proveedor Oracle presente; sin Pomelo ni EF InMemory en proyectos/locks.
- Sin bin, obj, node_modules, dist ni resultados de pruebas versionados.
- Revisión de diff y búsqueda de patrones de credenciales en archivos versionados sin hallazgos; esto no equivale a una auditoría de seguridad completa.
- Documentación operativa actualizada. La mención de proyectos inexistentes en ADR-0002 quedó identificada como estado histórico; seguridad aclara que los controles administrativos siguen sin implementar.
- No se cerraron decisiones de Phase 1+, ni se crearon carpetas infra vacías, migraciones o modelos de negocio.
