# Arquitectura y datos: propuesta inicial

**No hay código ni un esquema de base de datos implementado.** Este documento ofrece una base para discutir la estructura; no convierte cada sugerencia en una decisión.

## Tecnologías

- C# / ASP.NET Core: API HTTP y reglas del negocio.
- React: administración, componentes visuales, editor y vista previa.
- TypeScript: código del frontend con comprobación de tipos; salida JavaScript. La pregunta académica es si el profesor acepta ese uso para el rubro JavaScript.
- HTML, CSS, Bootstrap: estructura, estilos y distribución adaptable.
- AJAX con fetch: solicitudes a la API sin recargar toda la página.
- MySQL: elección explícita de Axel; no volver a presentarlo como motor por elegir.
- EF Core: propuesta de persistencia; proveedor MySQL y versiones por decidir.
- Git/GitHub: repositorio de documentación y eventual desarrollo colaborativo.

Angular y PHP se discutieron pero no se eligieron. Razor/MVC fue una sugerencia inicial sustituida por React + API. jQuery no se necesita por defecto para manipular una interfaz controlada por React.

No hay una elección de versiones de .NET, React, TypeScript o MySQL, ni de herramientas de construcción, formularios, routing o gestión de estado.

## Clean Architecture y DDD ligeros

Axel propuso inspirarse en estas ideas, aprovechando su experiencia en backend. Estructura sugerida:

- **Domain:** entidades y reglas de negocio, sin dependencia del framework web o persistencia.
- **Application:** casos de uso, contratos y puertos hacia servicios externos.
- **Infrastructure:** base de datos, archivos y correo.
- **API:** endpoints, autenticación, autorización y composición de dependencias.
- **Frontend:** aplicación React separada por funcionalidades.

Las dependencias de negocio apuntan hacia Domain; Infrastructure implementa contratos de Application. API compone las implementaciones. Son nombres sugeridos: todavía no existen carpetas ni proyectos con esa estructura.

No hacen falta microservicios, event sourcing, bus de eventos ni repositorios genéricos por costumbre. No se acordó MediatR, CQRS, JWT, cookies, ASP.NET Identity u otro mecanismo de autenticación.

## Separar diseño, contenido y archivos

1. **Diseño:** componentes React preparados por el equipo.
2. **Contenido:** registros en MySQL, asociados a compañía, página y sección.
3. **Archivos:** almacenamiento persistente, con referencias en MySQL.

No se decidió guardar páginas HTML completas ni crear una aplicación distinta por compañía. Un código conocido de plantilla selecciona el componente React correspondiente; no debe interpretarse como una ruta o código arbitrario.

## Modelo conceptual para comenzar

Las siguientes entidades y campos son una propuesta, no un DDL definitivo:

- **Compania:** identidad del negocio y configuración general.
- **UsuarioAdministrador:** cuenta y relación con la compañía. Una compañía por usuario o múltiples membresías sigue por definir.
- **Pagina:** identidad de una página de la compañía, si resulta útil modelarla por separado.
- **PlantillaBloque:** catálogo del equipo, con Id, código estable y nombre del diseño.
- **BloquePagina:** instancia con Id propio, compañía/página, PlantillaBloqueId, orden y contenido.
- **Producto** y **Categoria:** datos del catálogo asociados a compañía.
- **Noticia:** publicaciones de una compañía.
- **Pedido** y **DetallePedido:** compra simulada y productos/cantidades/precios de esa operación.
- **Archivo:** identificador, referencia de almacenamiento, nombre original, tipo y tamaño.
- **ElementoMultimedia:** posible relación ordenada entre una galería/sección y sus archivos.

Header, footer, colores, logo y contacto pueden almacenarse en configuración general o estructuras relacionadas. No duplicar datos generales en cada sección.

No agregar automáticamente una entidad de comprador registrado. Un pedido puede existir sin una cuenta de comprador; qué datos se requieren se definirá después.

## Repetir una plantilla

Ejemplo conceptual:

- Plantilla 2: imagen y texto.
- Bloque 10: plantilla 2, orden 2, contenido sobre la historia del negocio.
- Bloque 11: plantilla 2, orden 4, contenido sobre encargos.

El contenido pertenece al **bloque 10 o 11**, no a la plantilla 2. Borrar un bloque no borra el diseño reutilizable ni los otros bloques.

## Alternativas de almacenamiento de contenido discutidas

Axel planteó Plantillas, Campos, una relación plantilla-campo y valores por compañía. Es viable, pero no se cerró el esquema.

Para pocos diseños conocidos se propusieron campos explícitos o estructuras tipadas por tipo de bloque, por ser más fáciles de validar. Una galería requiere una colección de archivos; no todo cabe en un único título/texto/imagen.

Opciones pendientes de comparar:

- Columnas comunes más tablas específicas por tipo.
- Contenido JSON validado contra la definición de cada diseño.
- Modelo de definiciones de campos y valores, si su flexibilidad justifica la complejidad.

No dar por elegido JSON, un modelo genérico campo-valor ni una tabla final. El HTML de los diseños permanece en el código propuesto.

Productos y noticias vienen de sus módulos administrativos. Su bloque de presentación no debe duplicar los registros completos. Filtros o cantidades a mostrar quedan por definir.

## Reglas técnicas sugeridas

- La API comprueba a qué compañía pertenece cada recurso y quién puede modificarlo.
- Validar cantidades y calcular precios/totales en el servidor.
- Conservar el precio de la operación en el detalle del pedido.
- Definir transiciones permitidas y marcar claramente el pago como simulado.
- Separar baja de productos de borrado de registros históricos; demostrar delete donde sea válido.
- Definir tipos/tamaños de archivos y tratamiento de archivos referenciados al eliminar bloques.
- No confiar en valores del frontend solo porque TypeScript los tipa.

Estas pautas no implican que ya exista un módulo de inventario, reportes o administración de pedidos.

## Archivos y alojamiento

Una referencia de almacenamiento identifica un archivo, pero no autoriza su acceso. Logos y fotos comerciales pueden ser públicos; documentos privados requieren comprobación de permisos.

Se pueden usar carpetas persistentes accesibles por la API o almacenamiento de objetos. No se eligió proveedor. No guardar credenciales dentro del frontend exportable.

Una carpeta de frontend publicada en otro servidor puede consumir una API alojada en una dirección HTTPS accesible, con autenticación y configuración de orígenes apropiadas. No basta exportar HTML para disponer de un backend .NET o una base de datos.

Sites se conversó como posible alojamiento de una demostración, no como integración automática aprobada. Compatibilidad, acceso público y alojamiento de la API .NET deben comprobarse al implementarlo. No se ha creado ningún Site.
