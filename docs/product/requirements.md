# Requisitos del producto

Estado: capacidades previstas, sin implementación.

## Alcance vigente

| Área | Comportamiento previsto |
| --- | --- |
| Compañías | Múltiples compañías en una aplicación; administración independiente y aislamiento de información |
| Administración | Usuarios administrativos gestionan su compañía; áreas de Parámetros, Productos, Noticias y Personalizar Tienda |
| Catálogo | Productos, categorías e imágenes administrables y visibles en el storefront de su compañía |
| Identidad | Nombre comercial, logo, contacto y colores configurables; datos generales reutilizables sin duplicación inconsistente |
| Constructor | Añadir, quitar, repetir y ordenar secciones con contenido independiente por instancia; diseños preparados por el proyecto |
| Vista previa | Comprobar composición, identidad y navegación; flujo de publicación pendiente |
| Storefront | Página pública por compañía, separada del panel administrativo |
| Comercio | Carrito con productos, cantidades y total; checkout, pedidos persistidos y pago simulado que modifica el estado del pedido |
| Contenido | Noticias administrables consumidas por bloques de presentación; multimedia con fotografías y videos |

Las cuentas administrativas no implican cuentas de compradores. Registro, login e historial del comprador siguen abiertos. No se asumen recogida en tienda ni entrega a domicilio.

## Dirección de interfaz conservada

- Inicio como secuencia vertical de secciones, sin número fijo de dos/tres bloques ni elección entre dos sitios completos.
- Header limitado: nombre comercial y enlaces Inicio, Tienda, Carrito y Multimedia; colores configurables y dirección de dos efectos hover elegibles. Subrayado y cambio de fondo son ejemplos, no efectos cerrados.
- Footer con dirección de tres columnas: logo/identidad, misión/visión y contacto; contenido y colores editables. No se acordaron distribuciones alternativas ni efectos hover propios.
- Catálogo y carrito con distribución común inicialmente. El constructor no habilita diseño libre de esas pantallas.
- Noticias como bloque que consulta publicaciones del módulo; un enlace propio en el header sigue abierto.

Estas direcciones podrán revisarse por motivos de producto o usabilidad documentados, sin sustituirlas silenciosamente.

## Propuestas de detalle

- Plantillas: título con imagen grande, imagen/texto en ambos órdenes, galería y listado de noticias. Catálogo inicial y límites pendientes.
- Controles de subir/bajar secciones; arrastrar y soltar no es obligatorio.
- Menú adaptable a celular y apilado del footer; comportamiento por definir considerando accesibilidad.
- Parámetros adicionales: dirección, horarios, misión y visión. Su ubicación respecto al editor sigue pendiente.
- Productos: descripción, precio y disponibilidad; noticias: título, imagen, fecha y cuerpo. No son un esquema aprobado.
- Multimedia independiente y galerías insertadas en páginas; relación por definir.
- Archivos/documentos en una fase posterior: propósito, flujo y permisos requieren definición. Adjuntar instrucciones de encargos fue un ejemplo.
- Correos y enlaces sociales son opciones a justificar por un caso de uso, no requisitos aceptados.

## Validaciones que guiarán la implementación

- Un administrador no puede leer/modificar recursos privados de otra compañía ni relacionar entidades de tenants distintos.
- Catálogo, noticias, multimedia y pedidos corresponden a la compañía seleccionada y autorizada.
- Dos secciones de la misma plantilla mantienen contenido independiente; añadir, quitar o reordenar no altera otras instancias ni elimina la plantilla.
- Los parámetros compartidos se reutilizan sin valores contradictorios.
- El servidor valida cantidades, precios, totales y transiciones; el pedido conserva precios de la operación y el pago se identifica como simulado.
- Formularios y archivos rechazan entradas inválidas. Una vista previa local no demuestra preparación para producción.

## Open Questions

- ¿Qué negocio y nombre se usarán para la demo y cómo validar el problema con usuarios reales?
- ¿Cómo se crean compañías y administradores? ¿Habrá múltiples administradores, membresías, invitaciones o superadministración?
- ¿Se necesitarán cuentas de compradores? ¿Qué datos de contacto pide el checkout y cómo se conservan?
- ¿Cuáles serán las plantillas iniciales, límites de secciones y páginas editables además del inicio?
- ¿Qué campos pertenecen a Parámetros y cuáles al editor? ¿Qué efectos y comportamiento responsive se ofrecerán?
- ¿Cómo se relacionan noticias, navegación, multimedia y galerías? ¿Qué filtros y cantidades admiten sus bloques?
- ¿Cómo funciona la vista previa y qué flujos transaccionales permite? ¿Habrá borrador, versión visible y acción de publicar?
- ¿Cómo se persiste el carrito? ¿Cuáles son los estados, cancelaciones y reglas ante pagos simulados repetidos?
- ¿Se manejará disponibilidad simple, existencias numéricas, reservas o variantes? ¿Qué implica retirar un producto con pedidos históricos?
- ¿Habrá gestión administrativa de pedidos y cuál será su alcance?
- ¿Qué usos, permisos y límites tendrán los documentos? ¿Se necesitan correos, para qué eventos y con qué comportamiento ante errores? ¿Se ofrecerán enlaces sociales?

Preguntas técnicas: [arquitectura](../architecture/overview.md), [datos](../architecture/database.md), [multi-tenancy](../architecture/multitenancy.md), [seguridad](../architecture/security.md) y [despliegue](../deployment/README.md).
