# ADR-0001: Usar MySQL como motor de persistencia

## Status

Accepted — registrada el 14 de septiembre de 2026; elección ya expresada en documentación previa.

## Context

La plataforma necesita persistir compañías, catálogo, configuración, contenido y pedidos. MySQL fue elegido explícitamente por el autor, que ya dispone de él. El reset conserva esa decisión; no documenta una evaluación comparativa que no ocurrió.

## Decision

Utilizar MySQL. Versión, esquema, estrategia multi-tenant y proveedor de acceso permanecen pendientes. EF Core es la dirección prevista, sujeta a validación de proveedor y compatibilidad.

## Alternatives considered

No consta comparación formal de motores para este proyecto. SQL Server y PostgreSQL aparecieron como referencias de otras propuestas, no como alternativas evaluadas para justificar esta elección.

## Consequences

- Diseño y operación deberán considerar capacidades y restricciones de MySQL.
- Validar proveedor con .NET, EF Core y MySQL antes de iniciar persistencia.
- No se aprueban paquetes, migraciones, esquema de PageSection ni cloud.
- Cambiar de motor requerirá evaluación explícita y un ADR que sustituya este.
