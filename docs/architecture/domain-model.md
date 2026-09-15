# Modelo conceptual del dominio

Este vocabulario orienta el diseño; **no es un esquema definitivo**, DDL, listado cerrado de tablas ni definición de agregados.

| Concepto | Responsabilidad propuesta |
| --- | --- |
| Company / Compañía | Identidad y configuración del negocio; límite de aislamiento |
| AdministrativeUser | Identidad administrativa; relación y membresías por definir |
| Page / Página | Página de la compañía; representación persistente por evaluar |
| SectionTemplate / Plantilla | Diseño reutilizable controlado por el proyecto, con código estable |
| PageSection / Sección de página | Instancia con identidad, compañía/página, plantilla, posición y contenido propios |
| Product / Category | Catálogo de una compañía |
| News / Noticia | Publicación de una compañía |
| Order / Pedido | Operación de compra con pago simulado inicial |
| OrderItem / DetallePedido | Productos, cantidades y snapshots de precios de la operación |
| File / Archivo | Referencia de almacenamiento y metadatos como nombre, tipo y tamaño |
| MultimediaElement | Posible relación ordenada entre galería/sección y archivos |

PageSection corresponde al antiguo BloquePagina y SectionTemplate a PlantillaBloque. Los nombres finales de código quedan abiertos. No se añade automáticamente una entidad de comprador registrado.

[ADR-0004](adr/0004-shared-database-multitenancy.md) define tablas compartidas con CompanyId/TenantId para datos de compañía; no fija claves ni cardinalidades definitivas. Identity resuelve la tecnología de identidad administrativa, no el modelo de una o múltiples memberships ni los roles. Domain no debe depender de tipos de Identity.

## Invariantes conceptuales

- La información de una compañía respeta aislamiento de tenant, incluidas relaciones.
- Plantilla y contenido de instancia son conceptos distintos. Dos secciones de imagen/texto pueden compartir plantilla y mostrar historia y encargos con textos independientes.
- Eliminar una sección no elimina su plantilla ni otras instancias; los archivos referenciados requieren reglas propias.
- Logo, contacto y parámetros generales no se duplican arbitrariamente en cada sección.
- Productos y noticias se administran en sus módulos y se referencian desde bloques.
- Cantidades, totales y transiciones se validan en servidor; detalles del pedido conservan el precio de la operación.

## Open Questions

- Agregados, cardinalidades, identificadores y representación de páginas/configuración.
- Catálogo global de plantillas: registro en código, persistencia y evolución de versiones.
- Formato de contenido de PageSection: [alternativas de persistencia](database.md).
- Membresías, datos del comprador y ciclo de vida del pedido.
- Baja de productos y conservación histórica; no asumir borrado físico o lógico universal.
- Propiedad y ciclo de vida de archivos compartidos entre secciones de una misma compañía.
