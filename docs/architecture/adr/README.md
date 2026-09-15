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

Autenticación, proveedor EF Core, almacenamiento de PageSection y cloud permanecen abiertos en sus documentos; no hay ADR aceptados sobre ellos.
