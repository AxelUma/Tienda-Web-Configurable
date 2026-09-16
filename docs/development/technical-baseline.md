# Baseline técnico

Decisiones aceptadas para **Phase 0 — Foundation**, según la investigación aportada el 14 de septiembre de 2026. Las versiones son referencias iniciales; este registro no afirma que se hayan instalado o probado dentro del repositorio.

## Backend y persistencia

| Componente | Baseline |
| --- | --- |
| Plataforma | .NET 10 LTS y ASP.NET Core 10 |
| Lenguaje | C# 14 |
| SDK | .NET SDK 10.0.401, reportado como probado inicialmente en la investigación aportada |
| ORM | EF Core 10; parche de referencia 10.0.12 |
| Proveedor | MySql.EntityFrameworkCore oficial de Oracle; referencia 10.0.9 |
| Servidor | MySQL Server 8.4 LTS; parche soportado más reciente al desplegar |

No adoptar .NET 11 RC. Al implementar, crear global.json con SDK compatible de .NET 10. La política inicial prevista es **rollForward: latestPatch**, con **allowPrerelease: false**, partiendo de 10.0.401: permite parches de la misma banda y requiere actualización explícita para cambiar de banda. No crear global.json durante esta tarea. La [documentación de global.json](https://learn.microsoft.com/en-us/dotnet/core/tools/global-json) define estas políticas.

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

Al crear los proyectos, registrar versiones exactas resueltas y archivos de bloqueo apropiados; versionar package-lock.json para npm. Mantener SDK, dependencias y configuración de entornos documentados. Las actualizaciones compatibles son permitidas; cambios arquitectónicos importantes requieren ADR.

La licencia MIT cubre el trabajo del proyecto. Conservar licencias y avisos de terceros, incluido el proveedor de Oracle. No se instalan paquetes ni se crean builds, workflows o migraciones ahora.
