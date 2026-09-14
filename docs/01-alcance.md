# Alcance y comportamiento

## Visión y estado

Se propone una plataforma para que distintas compañías configuren su página y catálogo. El negocio de ejemplo puede ser una panadería o repostería. El alcance académico comprometible se limita a configuración y **vista previa funcional**, con catálogo, carrito y pago simulado; publicación y exportación quedan como ampliaciones.

También se discutió simplificar a una página fija de un solo negocio. No se tomó esa decisión: Axel conserva interés en el constructor como proyecto que pueda crecer fuera del curso.

## Personas y acceso

- **Administrador de compañía:** crea su cuenta, configura su negocio y gestiona sus datos.
- **Visitante/comprador:** consulta el sitio y usa el carrito. No se acordó registro, login ni historial personal para compradores.
- No se definió un superadministrador, membresías de varios administradores, invitaciones ni un panel global de la plataforma.

Las cuentas administrativas de compañías son distintas de cuentas de compradores. La separación entre compañías forma parte de la idea, aunque su implementación detallada esté pendiente. El checkout puede necesitar datos de contacto; cuáles, y cómo relacionarlos con un pedido, aún no se decidió.

## Panel administrativo independiente

### Parámetros

Datos generales reutilizables: nombre comercial, logo y medios de contacto. Se han mencionado compañía, dirección, horarios, misión y visión y colores. La distribución exacta entre Parámetros y Personalizar Tienda se concretará para no duplicar formularios o valores.

### Productos

Mantenimiento de los productos que consulta la tienda. Se han propuesto categorías, imágenes, descripción, precios y disponibilidad. Control de existencias numéricas, reservas de inventario y variantes no están definidos.

### Noticias

Crear y editar publicaciones del negocio. El bloque de noticias consume estas publicaciones: no se escribe una copia de cada noticia dentro del editor. Título, imagen, fecha y cuerpo son campos propuestos, no un esquema aprobado.

### Personalizar Tienda

Editor de identidad visual y secciones, con vista previa. No es el panel CRUD en sí: es una funcionalidad a la que se accede desde él.

Se necesita persistir pedidos para demostrar el pago simulado, pero no se definió un apartado administrativo de Pedidos. Su eventual incorporación debe acordarse.

## Personalización como una presentación

El equipo construye un catálogo de diseños. Cada sección añadida es una instancia independiente de uno de esos diseños, con su propia información y posición.

Ejemplos de diseños conversados:

- Título e imagen grande.
- Imagen a la izquierda y texto a la derecha.
- Texto a la izquierda e imagen a la derecha.
- Galería.
- Noticias obtenidas del módulo administrativo.

El usuario puede tener dos, tres, cuatro o más secciones y repetir el mismo diseño con contenido diferente. La cantidad final de diseños disponibles y los límites de secciones no están fijados.

Ejemplo de composición: bienvenida, historia del negocio, galería y encargos. Historia y encargos pueden compartir diseño sin compartir textos.

Se han propuesto controles sencillos para añadir, eliminar y subir/bajar secciones. No se exige arrastrar y soltar. No se incluye crear diseños nuevos, colocar elementos libremente, introducir código o editar HTML arbitrario.

## Header

Estructura planteada por Axel:

`[Nombre Comercial]     [Inicio] [Tienda] [Carrito] [Multimedia]`

- Enlaces y distribución base definidos por el equipo.
- Colores configurables.
- Dos efectos hover elegibles. Subrayado y cambio de fondo fueron ejemplos sugeridos, no efectos definitivamente elegidos.
- Noticias podría añadirse al encabezado después; no es un enlace confirmado en la base.
- Menú adaptado a celular es una propuesta de comportamiento responsive.

## Inicio

Secuencia vertical de secciones elegidas por el administrador, visible al desplazarse hacia abajo. No son dos versiones completas del sitio entre las que se escoge una; tampoco una secuencia fija de dos o tres bloques.

## Tienda

Distribución común de catálogo, productos y selección durante la primera versión. Cambian productos, colores y algunos textos. La personalización de bloques del inicio no implica un diseñador libre del catálogo.

## Carrito y pago

Estructura fija con selección de productos, cantidades y total. El proceso de pagar **simula la operación y modifica el estado del pedido**. No cobra dinero ni requiere integrar una pasarela.

Estados exactos, cancelaciones, persistencia del carrito, datos del checkout y detalle de la confirmación están pendientes. No se presupone entrega a domicilio ni recogida en tienda.

## Multimedia y noticias

Multimedia puede ser una página/espacio de fotografías y videos, coherente con el enlace del header. La relación entre ese espacio y las galerías de inicio aún se debe precisar.

Noticias se aceptó como plantilla o bloque que consulta publicaciones administrativas; se dejó abierta la posibilidad de un enlace en el encabezado.

## Footer

Base de tres columnas propuesta y aceptada como dirección:

1. Logo e identidad.
2. Misión y visión.
3. Medios de contacto.

Contenido y colores editables, configuración limitada. No hay un diseñador libre del footer. Se propuso apilar columnas en pantallas pequeñas. No se acordaron dos efectos hover propios del footer ni varias distribuciones elegibles.

## Otros requisitos del curso por concretar

- Envío de correos: contemplado, evento y proveedor pendientes.
- Carga de documentos: contemplada; indicaciones para encargos fue un ejemplo, no flujo cerrado.
- Redes sociales: enlaces propuestos; confirmar si satisfacen lo que espera el profesor.
- Galería, video, noticias, CRUD, cálculos y AJAX: deben tener una demostración verificable.

## Vista previa y publicación

La vista previa funcional es el resultado que se propone mencionar para el curso. Puede ejecutarse con frontend y API locales. Debe permitir comprobar composición, identidad y navegación; no se fijó si todos los flujos transaccionales ocurren dentro de un marco de preview o en una ruta aparte.

Son propuestas técnicas adicionales, todavía no compromisos:

- Ruta local por compañía, por ejemplo `/tiendas/la-espiga`.
- Separar borrador y versión visible.
- Botón para generar una copia de demostración.
- Publicar un ejemplo en Sites.
- Exportar un frontend configurable en carpeta o ZIP.

Actualizar contenido publicado desde una API no requiere recompilar el frontend por cada texto. Tampoco implica actualizaciones instantáneas en una página abierta: esa función no está solicitada.
