# Persistencia

## Decisiones y dirección

**MySQL sigue elegido** en [ADR-0001](adr/0001-use-mysql.md). [ADR-0003](adr/0003-ef-core-mysql-provider.md) acepta **EF Core 10**, **MySql.EntityFrameworkCore oficial de Oracle** y **MySQL Server 8.4 LTS**. Referencias investigadas: EF Core **10.0.12** y proveedor **10.0.9**; usar el parche soportado más reciente de MySQL 8.4 al desplegar.

Los parches no son una congelación permanente: actualizar con compatibilidad verificada y pruebas apropiadas. Pomelo no se adopta actualmente por falta de release estable para EF Core 10 en la investigación; revisar si aparece una alternativa estable con ventajas reales. Conservar licencia propia del proveedor y licencias/avisos de terceros.

[ADR-0004](adr/0004-shared-database-multitenancy.md) fija una base y tablas compartidas con CompanyId/TenantId en datos de compañía; no database-per-tenant ni schema-per-tenant inicialmente. Query filters como defensa de lectura más validaciones de escrituras/relaciones y restricciones por tenant cuando sea viable.

No hay base creada, esquema definitivo, paquetes instalados ni migraciones. La selección está aceptada; la verificación en ejecución se realizará con la implementación.

MySQL conservará datos del negocio y referencias de archivos. Los archivos se prevén en almacenamiento persistente externo a las tablas de contenido, sin proveedor elegido. El [modelo de dominio](domain-model.md) es conceptual.

## Contenido de PageSection: decisión abierta

Cada instancia conserva contenido propio aunque repita plantilla. No hay estructura concreta elegida.

| Alternativa propuesta | Aspecto a evaluar |
| --- | --- |
| Columnas comunes y tablas específicas por tipo | Validación y consultas explícitas frente a cambios por nuevos diseños |
| JSON validado por definición de plantilla | Flexibilidad frente a validación, consultas y evolución |
| Definiciones de campos y valores | Flexibilidad dinámica frente a complejidad de relaciones y validaciones |

Galerías requieren colecciones, no solo título/texto/imagen. Un eventual modelo campo-valor debe asociar contenido a la instancia, no solo a compañía o plantilla. No se ha elegido guardar páginas HTML arbitrarias.

## Criterios para evaluar

- Integridad de relaciones entre compañías, páginas, secciones y recursos.
- Consultas y validación por diseño, sin perder contenido de instancias.
- Snapshots de precios en OrderItem y pedidos históricos frente a cambios del catálogo.
- Evolución de diseños, migraciones y restauración.
- Verificación del proveedor elegido con operaciones, transacciones y pruebas necesarias contra MySQL real; EF InMemory no sustituye persistencia relevante.

## Open Questions

- Claves, foreign keys, unique constraints e índices concretos que preserven integridad por compañía en tablas compartidas.
- Formato de PageSection y evolución/versionado de contenido.
- Esquema, agregados, cardinalidades y persistencia de plantillas.
- Migraciones, datos de demo, backups y restauración.
- Eliminación de productos, secciones y archivos referenciados.

No crear ADR aceptados sobre estas cuestiones sin evaluarlas.
