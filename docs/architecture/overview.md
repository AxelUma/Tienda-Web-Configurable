# Arquitectura prevista

Estado: dirección de diseño; no existen proyectos ni componentes implementados.

## Backend modular

API sobre **.NET 10 LTS, ASP.NET Core 10 y C# 14**, organizada por features/casos de uso dentro de las capas. [ADR-0002](adr/0002-modular-layered-architecture.md) formaliza esta arquitectura. Clean Architecture y DDD son guías pragmáticas. SDK inicial 10.0.401 y política del futuro global.json en el [baseline técnico](../development/technical-baseline.md); no adoptar .NET 11 RC.

| Capa | Responsabilidad | Dependencias entre capas |
| --- | --- | --- |
| Domain | Entidades, invariantes y reglas de negocio | Ninguna |
| Application | Casos de uso, coordinación y contratos necesarios | Domain |
| Infrastructure | Persistencia, archivos y servicios externos; implementa contratos | Application y Domain |
| API | HTTP, validación de transporte, integración de seguridad y composición | Application; Infrastructure para composición |

Domain no depende de ASP.NET Core, EF Core, Identity ni almacenamiento. Los controllers/endpoints no contienen reglas de negocio. API es el composition root. La autorización de operaciones también se protege en casos de uso; no basta ocultar controles en la interfaz.

No se añade generic repository por defecto. MediatR, CQRS, microservicios, event bus, event sourcing y abstracciones adicionales requieren necesidad concreta y una decisión documentada cuando afecten la arquitectura.

## Frontend

**React 19.3, TypeScript 6 estable, Vite 8.x, Node.js 24 LTS y npm**, por features y componentes reutilizables, separando administración y storefront. HTML y CSS siguen siendo parte de la interfaz. No Create React App. TypeScript 7.0 ya es estable; se mantiene TypeScript 6 inicialmente para evitar tooling dual durante la transición de la API programática/ecosistema. Reevaluar con TypeScript 7.1 o posteriores cuando el toolchain permita adoptarlo limpiamente, según el [baseline técnico](../development/technical-baseline.md).

React Router y TanStack Query son la dirección prevista para routing y server state cuando exista un flujo que los necesite. No agregar Redux/Zustand u otra librería de estado global sin necesidad concreta. Bootstrap y fetch permanecen como propuestas; biblioteca visual y detalles de acceso HTTP se evaluarán sin instalar paquetes por anticipado. Angular, PHP y Razor/MVC no son el stack previsto; jQuery no se añade por defecto.

## Persistencia, tenant y autenticación

EF Core 10 con MySql.EntityFrameworkCore de Oracle y MySQL Server 8.4 LTS: [ADR-0003](adr/0003-ef-core-mysql-provider.md). Una base y tablas compartidas, discriminador de compañía, query filters y validaciones de escritura/relaciones: [ADR-0004](adr/0004-shared-database-multitenancy.md).

Panel administrativo con ASP.NET Core Identity y cookies, no JWT por defecto ni tokens en localStorage: [ADR-0005](adr/0005-browser-identity-cookies.md). Esto no resuelve membresías ni roles. Los detalles de permisos están en [seguridad](security.md).

## Convenciones HTTP

- REST JSON como estilo inicial y códigos HTTP semánticos según el resultado.
- ProblemDetails para errores HTTP y ValidationProblemDetails para validación cuando corresponda.
- No envolver todas las respuestas en un objeto genérico success/data/message; respuestas exitosas representan el recurso/resultado apropiado.
- No exponer excepciones internas, stack traces ni detalles sensibles al cliente.
- No introducir /api/v1 todavía. Añadir versionado al existir un consumidor externo o necesidad de mantener contratos simultáneos.
- Paginación, filtros y ordenamiento se concretarán con el primer listado real.

No hay endpoints implementados. Estas convenciones no eligen nombres de rutas ni formato definitivo de listados.

## Diseño, contenido y archivos

- Diseño: componentes React conocidos, identificados por códigos controlados; nunca rutas o código arbitrario.
- Contenido: datos de compañía, configuración y secciones en MySQL.
- Archivos: almacenamiento persistente con referencias y metadatos en MySQL, proveedor pendiente.

Productos y noticias se consumen desde sus módulos; los bloques no duplican registros completos. Cambiar un texto obtenido de la API no debería requerir recompilar por compañía. Esto no exige actualizaciones en tiempo real.

## Estructura futura aproximada

```text
src/
  backend/
    Tienda.Api/
    Tienda.Application/
    Tienda.Domain/
    Tienda.Infrastructure/
  frontend/
tests/
docs/
infra/
.github/
```

Guía para cuando comience la implementación, sin crear carpetas vacías. Proyectos de pruebas y módulos se concretarán con los primeros casos de uso.

## Open Questions

- Convenciones de nombres, límites de módulos, rutas concretas, paginación, filtros y ordenamiento del primer listado.
- Formularios, biblioteca visual y estado adicional solo según necesidades; routing y server state ya tienen dirección prevista.
- Una o múltiples compañías por usuario, roles y selección autorizada de compañía: [multi-tenancy](multitenancy.md) y [seguridad](security.md).
- Contenido de PageSection, plantillas en código frente a persistencia, esquema y detalles de migraciones: [persistencia](database.md).
- CDN, caché, Redis y message broker siguen abiertos y no se incorporan sin necesidad concreta.
- Entornos y cloud: [despliegue](../deployment/README.md).

Los cambios arquitectónicos importantes requieren [ADR](adr/README.md).
