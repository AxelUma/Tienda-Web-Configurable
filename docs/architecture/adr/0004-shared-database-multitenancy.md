# ADR-0004: Multi-tenancy con base y tablas compartidas

## Status

Accepted — 14 de septiembre de 2026, estrategia inicial de Phase 0.

## Context

La plataforma atenderá múltiples compañías con administración independiente. Se busca una primera arquitectura operable como una aplicación, manteniendo aislamiento verificable sin gestionar una base o esquema por compañía.

## Decision

Usar **una aplicación, una base MySQL compartida y tablas compartidas**, con discriminador **CompanyId/TenantId** en datos pertenecientes a una compañía. El nombre final del discriminador se fijará con las convenciones de código; no representan dos campos obligatorios.

- Tenant administrativo derivado del contexto de identidad/autorización. No confiar en CompanyId enviado por el cliente.
- El storefront puede resolver compañía por slug/ruta pública; eso no concede permisos administrativos.
- EF Core global query filters como defensa por defecto para lecturas, nunca como única defensa.
- Validar CompanyId al crear, modificar, eliminar y relacionar recursos; rechazar relaciones entre compañías distintas.
- Diseñar foreign keys, unique constraints e índices con ámbito de compañía para impedir asociaciones incorrectas cuando sea viable; no se define DDL ahora.
- Revisar explícitamente raw SQL, operaciones que omitan filtros y accesos fuera del contexto habitual: deben mantener autorización y aislamiento.
- Integration tests obligatorios desde Phase 1 con al menos dos compañías, cubriendo lecturas, escrituras y relaciones.

## Alternatives considered

- **Database-per-tenant:** no se adopta inicialmente por la operación y evolución de múltiples bases que exigiría.
- **Schema-per-tenant:** no se adopta en esta arquitectura; se mantienen tablas compartidas.
- **Solo filtros de lectura:** insuficiente para escrituras, relaciones y rutas que omiten filtros.

## Consequences

- El aislamiento debe verificarse en casos de uso, persistencia, archivos y futuros procesos/cachés; la separación física no actúa como frontera por compañía.
- Restricciones e índices deben considerar el tenant; los detalles se definirán con el modelo real.
- Fallos de aislamiento pueden afectar datos de otras compañías, por lo que se requieren pruebas negativas desde Phase 1.
- No decide una única compañía por usuario frente a múltiples memberships, roles definitivos ni alcance global de plantillas.
