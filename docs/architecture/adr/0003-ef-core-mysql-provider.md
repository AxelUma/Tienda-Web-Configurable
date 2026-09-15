# ADR-0003: EF Core 10 y proveedor MySQL oficial

## Status

Accepted — 14 de septiembre de 2026, según la investigación y decisión aceptadas para Phase 0.

## Context

[ADR-0001](0001-use-mysql.md) eligió MySQL. El backend usará .NET 10 LTS y necesita un proveedor estable para EF Core 10. La investigación aportada fija EF Core 10.0.12 y MySql.EntityFrameworkCore 10.0.9 como versiones iniciales de referencia; no se ejecutaron pruebas de persistencia en esta tarea documental.

## Decision

- Usar **EF Core 10** y **MySql.EntityFrameworkCore**, proveedor oficial de Oracle, inicialmente.
- Adoptar **MySQL Server 8.4 LTS**, con el parche soportado más reciente de esa línea al desplegar.
- Versiones de referencia: **EF Core 10.0.12** y **MySql.EntityFrameworkCore 10.0.9**. Permitir actualizaciones de parches compatibles y verificadas; no son una prohibición permanente de actualizar.
- Verificar restauración, migraciones y consultas reales cuando se implemente, sin reabrir como pendiente la selección ya aceptada.
- Conservar la licencia propia del proveedor y las licencias/avisos de dependencias de terceros. La licencia MIT del repositorio no las reemplaza.

## Alternatives considered

**Pomelo** no se utiliza actualmente: su release estable revisada soporta EF Core 9, no EF Core 10. No se adopta una versión preliminar ni se baja el baseline para incorporarlo. Revisar la decisión si Pomelo u otro proveedor ofrece posteriormente una alternativa estable con ventajas técnicas reales. Véanse las [releases de Pomelo](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/releases).

El [paquete oficial de Oracle 10.0.9](https://www.nuget.org/packages/MySql.EntityFrameworkCore/10.0.9) publica sus dependencias y licencia. La elección no presupone igualdad de comportamiento entre proveedores ni una comparación de rendimiento ya ejecutada.

## Consequences

- Infrastructure integrará el proveedor; Domain permanece independiente de EF Core.
- Probar comportamiento relevante de persistencia contra MySQL real, incluyendo aislamiento e integridad entre compañías; EF InMemory no lo sustituye.
- Mantener versiones resueltas reproducibles al crear los proyectos y verificar actualizaciones con pruebas apropiadas.
- El esquema, formato persistente de PageSection y almacenamiento de archivos siguen abiertos. No se crean paquetes instalados, migraciones ni base de datos ahora.
