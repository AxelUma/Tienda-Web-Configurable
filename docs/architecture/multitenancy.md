# Multi-tenancy

## Decisión conceptual vigente

Múltiples compañías en una misma aplicación. Cada compañía es un tenant: un ámbito de datos y permisos con administración independiente. No es una instalación por negocio.

## Principios de implementación

- Toda entidad perteneciente a una compañía debe conservar un ámbito de tenant verificable.
- Resolver compañía y comprobar permisos en servidor; un identificador de ruta, encabezado o cuerpo no autoriza acceso.
- Aplicar aislamiento al consultar, crear, modificar, eliminar y relacionar entidades.
- Verificar pertenencia de recursos relacionados, incluidos productos de pedidos, categorías, páginas y archivos.
- El storefront expone contenido público de su compañía; eso no concede acceso a administración, pedidos o documentos privados.
- Vista previa y futuras cachés, procesos en segundo plano y almacenamiento deben conservar contexto de tenant.
- Pruebas de integración deben intentar accesos y asociaciones entre al menos dos compañías.

Estas reglas no eligen estrategia física de almacenamiento ni implementación de filtros.

## Open Questions

- Base compartida con discriminador, separación de bases u otra estrategia compatible con MySQL: evaluar costos, operación e integridad.
- Resolución del tenant: ruta, subdominio u otra opción. /tiendas/la-espiga es solo un ejemplo.
- Una compañía por usuario o múltiples membresías; roles, invitaciones y administración global.
- Cómo aplicar aislamiento en persistencia, restricciones y contratos de API.
- Alcance global de plantillas y otros recursos compartidos frente a datos privados.

La estrategia técnica requerirá un [ADR](adr/README.md); el aislamiento conceptual ya forma parte del producto.
