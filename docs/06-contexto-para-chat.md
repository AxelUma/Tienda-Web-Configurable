# Contexto autocontenido para continuar en otra conversación

Actualizado: 13 de septiembre de 2026. Podés adjuntar este archivo y el resto de docs para planificar tareas o estructura. No hay implementación.

## Qué quiero construir

Una Tienda Web Personalizable para pequeños negocios. Cada compañía crea una cuenta administrativa, configura su negocio y compone su página. Panadería/repostería es el caso de ejemplo, sin negocio concreto elegido. Quiero que pueda crecer como proyecto real/personal incluso si no se elige para la universidad.

La personalización funciona como los diseños de diapositivas de PowerPoint. Nosotros programamos diseños de secciones; el administrador añade instancias, elige diseño y rellena contenido. Puede tener dos, tres, cuatro o más, repetir un diseño con contenido independiente y ordenar/quitar secciones. Aparecen una debajo de otra al hacer scroll. No es elegir entre dos sitios completos ni tener dos bloques obligatorios.

## Pantallas

Panel administrativo distinto de la página:
- Parámetros: datos generales e identidad.
- Productos: CRUD del catálogo.
- Noticias: publicaciones que consume su bloque.
- Personalizar Tienda: editor y vista previa.

Página:
- Header fijo: nombre comercial, Inicio, Tienda, Carrito, Multimedia. Colores y dos hovers elegibles; efectos concretos pendientes.
- Inicio: secciones de diseños preparados.
- Tienda: distribución fija; productos y algunos textos/colores cambiables.
- Carrito: distribución fija, cantidades y total.
- Pago: simulación que cambia estado del pedido, sin dinero real.
- Multimedia: fotografías y videos.
- Footer de tres columnas: logo, misión/visión, medios de contacto; contenido y colores editables.
- Noticias como bloque/plantilla; posible enlace posterior en header.

NO acordamos cuentas de compradores, historial personal ni pago al recoger. NO es una instalación independiente por compañía. Tampoco se definió un superadministrador o una pantalla de Pedidos.

## Tecnología

C# / ASP.NET Core, React, TypeScript, HTML, CSS, Bootstrap, AJAX con fetch y MySQL. MySQL ya está elegido porque lo tengo. Clean Architecture/DDD simplificados; Domain/Application/Infrastructure/API son una estructura sugerida, no código existente. EF Core es una posibilidad. Versiones, ORM/proveedor, auth, routing y esquema final están por decidir.

Tengo unos tres, casi cuatro años de experiencia full-stack .NET/React, orientado a backend, integración y sistemas legacy. No soy principiante en programación. TypeScript se propone para escribir la lógica en lugar de JavaScript directamente; nunca dije que sustituyera CSS o Bootstrap.

## Datos y publicación

Diseños en componentes React; MySQL guarda compañías, configuración, productos, noticias, pedidos e instancias de bloques con diseño, orden y contenido propios. Imágenes/documentos en almacenamiento con referencias. No se eligió guardar HTML completo.

Hablamos de tablas de plantillas/campos/valores; es alternativa, no decisión. También se propusieron columnas específicas o contenido tipado. No decidir unilateralmente JSON o modelo campo-valor.

Para el curso solo mencionar vista previa funcional, demostrable localmente. Publicar en Sites un ejemplo sería extra. Exportar una carpeta/ZIP que consuma nuestra API también es extra. Una API real podría estar accesible por HTTPS. Publicar una ruta por compañía y consultar configuración desde la API es otra opción, no integración implementada.

Borradores, versiones visibles y botón de publicar/generar demo son propuestas, no requisitos aprobados. No se requiere actualización instantánea. Alojamiento comercial, dominios, cobro por tráfico y pagos reales son futuro.

## Curso y equipo

Curso: Programación de Aplicaciones y Servicios Web, ULACIT. Profesor: Ing. Mauricio Rivera Villalobos. Hay tres propuestas: Tienda, asesoramiento fitness y parqueos. No está confirmada la elección del profesor; considero poco probable que elijan Tienda, pero me interesa conservarla.

Se contemplaron dos integrantes. Reparto tentativo: compañero en CRUD administrativo, yo en editor/plantillas/vista previa/página pública; API dividida por funcionalidad. No se conoce la experiencia React del compañero. Hacer un CRUD juntos como ejemplo sería útil. No asignar documentación ni trabajo definitivamente sin acuerdo.

Proyecto: 50 % del curso; avance 1 semana 5 (10 %), avance 2 semana 10 (10 %), final semana 15 (30 %). Primer avance documental; segundo requiere diseño BD/diccionario y propuesta visual, con código opcional en rúbrica. Cronograma de semana 10 menciona pruebas/programación: atender aclaraciones del docente. Ver docs/04-contexto-academico.md.

La rúbrica también pide acceso, CRUD, gráficos originales, galería/video, documentos, carrito, noticias, redes, correo, cálculos/validaciones, AJAX, orden de código, al menos tres herramientas de su lista y video demostrativo. Uso exacto de correo/documentos/redes y aceptación de TypeScript para JavaScript pendientes.

## Cómo ayudarme

Primero separar decisiones, recomendaciones y preguntas pendientes. No inventar funciones, cuentas, estados, proveedores ni compromisos. Se pueden proponer opciones explicando que son propuestas. No reintroducir cuentas de compradores, pago al recoger, una tienda por instalación o dos diseños completos.

No convertir dudas sobre complejidad en una decisión de abandonar el constructor. Una página fija para un solo negocio fue alternativa conversada, no seleccionada. El alcance definitivo todavía se puede negociar.

Para mensajes compartibles: lenguaje sencillo, título “Propuesta 1 - Tienda Web Personalizable para pequeños negocios”, listas y negritas permitidas, sin tablas cuando sea un mensaje. Conservar el contenido de compañeros; no copiar sus tecnologías o requisitos a Tienda.

Objetivo de la próxima conversación: revisar alcance y pendientes, dividir tareas o preparar estructura a partir de estas definiciones, antes de asumir implementación.
