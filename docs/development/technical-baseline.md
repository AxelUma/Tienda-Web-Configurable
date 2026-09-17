# Baseline técnico

Decisiones aceptadas para **Phase 0 — Foundation**, según la investigación aportada el 14 de septiembre de 2026. El scaffolding del 16 de septiembre de 2026 resuelve las versiones indicadas abajo; los resultados reales están en el [registro de verificación](phase-0-verification.md).

## Backend y persistencia

| Componente | Baseline |
| --- | --- |
| Plataforma | .NET 10 LTS y ASP.NET Core 10 |
| Lenguaje | C# 14 |
| SDK | .NET SDK 10.0.401, reportado como probado inicialmente en la investigación aportada |
| ORM | EF Core 10; parche de referencia 10.0.12 |
| Proveedor | MySql.EntityFrameworkCore oficial de Oracle; referencia 10.0.9 |
| Servidor | MySQL Server 8.4 LTS; parche soportado más reciente al desplegar |

No adoptar .NET 11 RC. global.json fija SDK **10.0.401**, **rollForward: latestPatch** y **allowPrerelease: false**: permite parches de la misma banda y requiere actualización explícita para cambiar de banda. También selecciona Microsoft.Testing.Platform para dotnet test, requerido por el xUnit v3 estable resuelto. La [documentación de global.json](https://learn.microsoft.com/en-us/dotnet/core/tools/global-json) define estas políticas.

Persistencia se formaliza en [ADR-0003](../architecture/adr/0003-ef-core-mysql-provider.md). Las versiones de referencia no congelan parches: actualizar con compatibilidad y pruebas verificadas y registrar las versiones efectivamente utilizadas.

## Frontend

| Componente | Baseline |
| --- | --- |
| UI | React 19.3 |
| Lenguaje | TypeScript 6 estable |
| Herramienta de desarrollo/build | Vite 8.x |
| Runtime de desarrollo | Node.js 24 LTS |
| Gestor de paquetes | npm |

**Aclaración del 15 de septiembre de 2026:** TypeScript 7.0 es estable desde julio de 2026. Se mantiene **TypeScript 6 estable** como baseline inicial del scaffolding porque 7.0 aún no ofrece la API programática estable que necesitan algunas herramientas. La [documentación oficial de TypeScript](https://devblogs.microsoft.com/typescript/announcing-typescript-7-0/) menciona typescript-eslint y contempla ejecución side-by-side con TypeScript 6 durante la transición.

El [template oficial React + TypeScript de Vite 8](https://github.com/vitejs/vite/blob/main/packages/create-vite/template-react-ts/package.json), revisado en esa fecha, también mantiene TypeScript 6. El proyecto difiere TypeScript 7 para evitar una configuración dual o complejidad de tooling innecesaria. Reevaluar con TypeScript 7.1 o posteriores cuando la API y el toolchain elegido permitan adoptarlo limpiamente; no es una prohibición permanente ni una actualización automática por número de versión. Los parches de TypeScript 6 siguen la política de actualizaciones compatibles y verificadas, sin fijar un parche perpetuo.

No usar Create React App. React Router y TanStack Query son la dirección prevista para routing y server state cuando el primer flujo los necesite; no se instalan por anticipado. No agregar Redux, Zustand u otra librería de estado global sin necesidad concreta.

## Reproducibilidad y mantenimiento

Directory.Build.props centraliza net10.0, nullable, implicit usings y builds deterministas; C# 14 se obtiene del SDK/target sin LangVersion redundante. CI trata advertencias como errores. Se usan los analyzers .NET incluidos. Directory.Packages.props centraliza versiones NuGet compartidas por pruebas e infraestructura; packages.lock.json por proyecto y package-lock.json del frontend fijan restauraciones. .editorconfig, dotnet format, Oxlint y Oxfmt aportan formato/lint reproducibles. .nvmrc es el selector único de versión Node; package.json declara la línea compatible y npm. Las actualizaciones compatibles son permitidas; cambios arquitectónicos importantes requieren ADR.

La licencia MIT cubre el trabajo del proyecto. Conservar licencias y avisos de terceros, incluido el proveedor de Oracle. Hay dependencias restaurables y CI básico, sin migraciones ni funcionalidades de negocio.

## Versiones resueltas del scaffolding

| Componente | Versión |
| --- | --- |
| .NET SDK / ASP.NET Core local | 10.0.401 / 10.0.12 |
| EF Core / MySql.EntityFrameworkCore | 10.0.12 / 10.0.9 |
| React / React DOM | 19.3.0 / 19.3.0 |
| TypeScript / Vite / plugin React | 6.0.3 / 8.3.0 / 6.1.1 |
| Node / npm | 24.13.0 / 11.6.2 |
| xunit.v3 / Microsoft.Testing.Platform transitivo | 4.0.1 / 2.4.0 |
| Microsoft.AspNetCore.Mvc.Testing | 10.0.12 |
| Testcontainers.MySql / imagen de prueba | 4.15.0 / mysql:8.4.6 |
| Vitest / React Testing Library | 5.0.1 / 16.3.3 |
| jest-dom / jsdom | 7.0.1 / 29.1.1 |
| Playwright | 1.63.0 |
| Oxlint / Oxfmt | 1.83.0 / 0.68.0 |

El paquete xunit.v3 4.0.1 corresponde a la familia xUnit v3, no a xUnit v2; incorpora Microsoft.Testing.Platform v2. No se conservan adaptadores VSTest redundantes.

Se seleccionó jsdom 29.1.1 estable: 30.1.0 exige Node >=24.15.0 en la línea 24 y no es compatible con el Node 24.13.0 disponible. La combinación final restaura sin avisos de engines. La imagen MySQL de tests fija un parche 8.4 para reproducibilidad; no define el parche de un futuro despliegue.

El scaffolding frontend es una generación equivalente limpia al template oficial React/TypeScript de Vite revisado, con React ajustado al baseline del proyecto. Oxlint sigue la dirección del template y Oxfmt cubre formato sin añadir Prettier. Las configuraciones no requieren router, server-state ni UI kits.
