# Arquitectura prevista

Estado: dirección de diseño; no existen proyectos ni componentes implementados.

## Backend modular

API ASP.NET Core con organización preferentemente por feature/caso de uso dentro de las capas. Clean Architecture y DDD sirven como guía práctica, sin imponer patrones donde no aporten valor.

| Capa | Responsabilidad | Dependencias entre capas |
| --- | --- | --- |
| Domain | Entidades, invariantes y reglas de negocio | Ninguna |
| Application | Casos de uso, coordinación y contratos necesarios | Domain |
| Infrastructure | Persistencia, archivos y servicios externos; implementa contratos | Application y Domain |
| API | HTTP, validación de transporte, integración de seguridad y composición | Application; Infrastructure para composición |

Domain no depende de ASP.NET Core, EF Core ni almacenamiento. Los controllers no contienen reglas de negocio. La autorización de operaciones también se protege en casos de uso; no basta ocultar controles en la interfaz.

Se evitarán repositorios genéricos y abstracciones innecesarias. Microservicios, event sourcing, bus de eventos, MediatR y CQRS no son decisiones tomadas ni requisitos.

## Frontend

React + TypeScript por features y componentes reutilizables, con separación clara entre administración y storefront. HTML y CSS siguen siendo parte de la interfaz. Bootstrap y fetch fueron propuestas; bibliotecas de UI y acceso HTTP deberán evaluarse. Angular, PHP y Razor/MVC no son el stack previsto; jQuery no se añade por defecto.

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

- Versiones de .NET, React, TypeScript y MySQL y compatibilidad de herramientas.
- Convenciones de nombres, scaffolding, límites de módulos, contratos HTTP, errores y paginación.
- Routing, formularios, estado y biblioteca visual según necesidades.
- Usuarios, autenticación y resolución de tenant: [multi-tenancy](multitenancy.md) y [seguridad](security.md).
- Proveedor EF Core, contenido de PageSection y migraciones: [persistencia](database.md).
- Entornos y cloud: [despliegue](../deployment/README.md).

Los cambios arquitectónicos importantes requieren [ADR](adr/README.md).
