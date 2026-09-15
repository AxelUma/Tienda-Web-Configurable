# Multi-tenancy

## Estrategia inicial aceptada

[ADR-0004](adr/0004-shared-database-multitenancy.md): **una aplicación, una base MySQL compartida y tablas compartidas**, con discriminador **CompanyId/TenantId** en datos pertenecientes a una compañía. El nombre final del campo se fijará al implementar; no son dos campos obligatorios.

Cada compañía es un tenant: ámbito de datos y permisos con administración independiente. No se adopta database-per-tenant ni schema-per-tenant en la primera arquitectura. No hay aislamiento implementado todavía.

## Resolución y autorización

- El tenant administrativo se obtiene del contexto de identidad/autorización con Identity y cookies. No confiar en CompanyId enviado por el cliente.
- Si se aceptan múltiples memberships, cualquier selección de compañía deberá validarse contra las autorizadas; esta regla no decide que existan memberships múltiples.
- El storefront puede resolver compañía públicamente mediante slug/ruta, por ejemplo /tiendas/la-espiga. No concede permisos administrativos ni acceso a pedidos/documentos privados.
- Toda entidad de compañía conserva ámbito verificable, incluidos archivos y relaciones.

## Defensa en lecturas, escrituras y relaciones

- EF Core global query filters serán la defensa por defecto para lecturas de datos de compañía, **no la única defensa**.
- Validar CompanyId al crear, modificar, eliminar y relacionar recursos; no permitir cambiar de tenant manipulando datos del cliente.
- Comprobar pertenencia de productos de pedidos, categorías, páginas, secciones y archivos.
- Diseñar foreign keys, unique constraints e índices considerando el tenant para impedir asociaciones incorrectas cuando sea viable. El esquema exacto sigue abierto.
- Raw SQL, operaciones sin filtros y accesos fuera del contexto habitual requieren revisión explícita de autorización y ámbito; no se presume protección por EF.
- Vista previa, futuros procesos en segundo plano, cachés y almacenamiento deben conservar contexto de compañía. Eso no selecciona Redis ni un broker.

## Verificación obligatoria

Desde **Phase 1**, integration tests con al menos dos compañías verifican lecturas, escrituras, eliminación y asociaciones permitidas/denegadas, incluyendo manipulación de CompanyId. Persistencia relevante se verifica contra MySQL real mediante la [estrategia de pruebas](../development/testing.md).

## Open Questions

- Una compañía por usuario o múltiples memberships; roles definitivos, invitaciones y administración global.
- Selección autorizada de compañía y rutas públicas concretas.
- Claves, restricciones e índices específicos al definir el esquema.
- Catálogo global de plantillas y otros recursos compartidos frente a datos privados.
