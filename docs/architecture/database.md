# Persistencia

## Decisiones y dirección

**MySQL está elegido**: [ADR-0001](adr/0001-use-mysql.md). No hay versión seleccionada, base creada, esquema definitivo ni migraciones.

Entity Framework Core es la dirección prevista, condicionada a validar proveedor MySQL y compatibilidad con .NET, EF Core y servidor. No hay proveedor ni paquetes seleccionados.

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
- Compatibilidad del proveedor con operaciones, transacciones y pruebas necesarias.

## Open Questions

- Proveedor EF Core y matriz de versiones: validar antes de cerrar la elección.
- Estrategia física multi-tenant, claves, restricciones e índices.
- Formato de PageSection y evolución/versionado de contenido.
- Esquema, agregados, cardinalidades y persistencia de plantillas.
- Migraciones, datos de demo, backups y restauración.
- Eliminación de productos, secciones y archivos referenciados.

No crear ADR aceptados sobre estas cuestiones sin evaluarlas.
