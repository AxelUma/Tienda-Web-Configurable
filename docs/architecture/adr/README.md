# Architecture Decision Records

Los ADR registran decisiones arquitectónicas importantes, su contexto y consecuencias. No reemplazan requisitos ni presentan propuestas como implementación.

Usar numeración consecutiva y nombre descriptivo, por ejemplo 0001-use-mysql.md. Un ADR puede comenzar como Proposed y pasar a Accepted solo cuando se resuelva. Registrar cambios de estado; si se reemplaza una decisión, conservar el original como Superseded con enlace al nuevo.

## Formato

```markdown
# ADR-XXXX: Título

## Status

Proposed / Accepted / Superseded / Rejected

## Context

## Decision

## Alternatives considered

## Consequences
```

Indicar un único estado actual y fecha de decisión o actualización. Explicar alternativas honestamente: si no hubo comparación formal, decirlo. No inventar evaluaciones retrospectivas.

## Índice

| ADR | Estado | Decisión |
| --- | --- | --- |
| [ADR-0001](0001-use-mysql.md) | Accepted | MySQL como motor de persistencia |
| [ADR-0002](0002-modular-layered-architecture.md) | Accepted | Arquitectura modular por capas |
| [ADR-0003](0003-ef-core-mysql-provider.md) | Accepted | EF Core 10, proveedor Oracle y MySQL 8.4 LTS |
| [ADR-0004](0004-shared-database-multitenancy.md) | Accepted | Base y tablas compartidas con discriminador de compañía |
| [ADR-0005](0005-browser-identity-cookies.md) | Accepted | ASP.NET Core Identity y cookies para administración web |

Las decisiones nuevas complementan ADR-0001 sin cambiar el motor elegido. El [baseline técnico](../../development/technical-baseline.md) registra plataforma backend/frontend y versiones; las [convenciones HTTP](../overview.md) y la [estrategia de pruebas](../../development/testing.md) no requieren ADR por cada herramienta.

Siguen abiertos PageSection, plantillas en código frente a persistencia, memberships/roles, compradores, archivos, correo, cloud, publicación/borradores, observabilidad concreta, inventario, pagos reales, CDN/caché/Redis y message broker. Accepted no significa implementado.
