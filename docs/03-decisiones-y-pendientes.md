# Decisiones, correcciones y pendientes

## Cómo interpretar el estado

- **Definido en la conversación:** intención explícita de Axel; todavía puede necesitar acuerdo del equipo/profesor.
- **Propuesto:** recomendación del asistente o ejemplo técnico, sin decisión final.
- **Pendiente:** no hay definición.
- **Descartado/superado:** no debe reaparecer como requisito vigente.

## Evolución del proyecto

1. Se exploraron peluquería, panadería y una solución genérica de catálogo/ventas.
2. Se tomó panadería/repostería como ejemplo para una tienda personalizable.
3. Axel explicó su experiencia profesional en .NET/React y propuso Clean Architecture/DDD simplificados.
4. Se eligió React como dirección de frontend; Razor fue una propuesta anterior.
5. Se aclaró que plantilla significa un diseño de sección, comparable con PowerPoint.
6. Se confirmó poder añadir varias secciones y repetir diseños con contenido distinto.
7. Se limitaron header, footer, tienda y carrito; la composición libre por bloques corresponde al inicio.
8. Se corrigió el pago: simulación que cambia estado, no obligación de pagar al recoger.
9. Se corrigió el modelo de negocio: compañía con cuenta administrativa, no una instalación independiente por negocio.
10. Se limitó el compromiso de publicación a vista previa funcional; exportación y hosting quedan como ampliaciones.
11. Se hizo explícito el panel separado: Parámetros, Productos, Noticias y Personalizar Tienda.
12. Se discutió el trabajo de dos personas y el riesgo de sobrealcance.
13. Se presentaron tres alternativas al profesor: tienda, fitness y parqueos. No hay selección confirmada.
14. Axel desea conservar esta idea para un proyecto personal y planificar con otra conversación aunque no gane la selección académica.

## Correcciones que deben respetarse

- **No cuentas de compradores:** se añadieron por error en respuestas/notas iniciales.
- **No pago al recoger:** fue una simplificación propuesta por el asistente, posteriormente rechazada.
- **No una tienda por instalación:** no describe el flujo de cuentas de compañías que Axel busca.
- **No dos diseños de sitios completos:** son diseños reutilizables de secciones.
- **No número fijo de dos/tres bloques:** se pueden añadir más y repetir.
- **MySQL ya está elegido:** no sustituir por SQL Server o PostgreSQL tomados de otras propuestas.
- **TypeScript sustituye escribir JavaScript directamente:** Axel nunca dijo que reemplazara CSS o Bootstrap.
- **No editor libre de diseños:** el usuario rellena y organiza diseños preparados por el equipo.
- **No publicación automática comprometida:** el alcance comunicable es vista previa.
- **No tareas de compañeros asignadas definitivamente:** el reparto fue tentativo.
- **No confundir dos integrantes previstos para Tienda con los roles listados por otra propuesta.**
- **No copiar requisitos/tecnologías de fitness o parqueos a Tienda.**

## Pendientes de producto

- Selección del profesor y alcance final del equipo.
- Negocio de demostración y nombre comercial.
- Número y tipos de diseños iniciales; límites de secciones.
- Qué pantallas exactas se pueden componer y cómo se ofrece su vista previa.
- Campos de Parámetros frente a campos del editor, sin duplicar información.
- Efectos hover concretos y comportamiento en celular.
- Noticias como bloque del inicio; posible enlace futuro en header.
- Multimedia independiente y relación con galerías.
- Datos que se piden al completar el pedido, sin introducir cuentas de compradores.
- Estados de pedido, persistencia del carrito y efecto de pagar dos veces.
- Existencias numéricas frente a mera disponibilidad.
- Gestión administrativa de pedidos: ubicación y alcance.
- Evento de correo, proveedor y manejo de errores.
- Uso exacto y permisos de documentos adjuntos.
- Qué espera el docente como conexión con redes sociales y ejemplos del día de proyecto.

## Pendientes técnicos

- Versiones de herramientas, scaffolding y convenciones.
- Proveedor MySQL/ORM y estrategia de migraciones.
- Autenticación y relación entre usuarios administrativos y compañías.
- Esquema definitivo de bloques y contenido.
- Biblioteca de formularios, routing y estado, solo si hacen falta.
- Ubicación de imágenes/documentos y límites.
- Contratos de API, errores y paginación.
- Si habrá borrador y versión visible separadas.
- Forma de publicación, exportación y alojamiento de API, si se amplía.

## Alternativa simplificada, sin seleccionar

Página de un negocio concreto, con inicio fijo y formularios para cambiar textos/imágenes. Conserva catálogo, carrito, pago simulado, multimedia, noticias y administración, pero elimina constructor y cuentas de varias compañías.

Axel teme que el proyecto sea demasiado grande, pero también quiere hacer proyectos con continuidad real. No se decidió reemplazar la visión original por esta alternativa. Se puede negociar un recorte explícito; no asumirlo silenciosamente.

## Futuro posible, fuera del compromiso inicial

- Demostración alojada en Sites.
- Publicación por compañía y contenido actualizado al consultar la API.
- Borradores, versiones y restauración.
- Exportación de frontend y configuración a carpeta/ZIP.
- Dominios propios, alojamiento y medición de consumo.
- Planes comerciales/cobro por uso o tráfico: idea de negocio exploratoria.
- Pagos reales, facturación y otras funciones comerciales.
- Diseños adicionales; un editor libre requeriría nuevo alcance.

Nada de lo anterior está implementado, contratado o aprobado por el profesor.

## Material trabajado

Se crearon seis notas TXT iniciales y borradores de mensaje, se compararon herramientas y se revisó el sílabo. Más tarde se unieron tres propuestas en un Google Doc y se ajustó su formato sin modificar el contenido técnico de los compañeros. Ese trabajo fue editorial, no desarrollo de la aplicación.

Las notas TXT anteriores contienen contradicciones conocidas. Estos Markdown consolidan las correcciones posteriores; no trasladar aquellas notas como requisitos sin revisar este documento.
