# Trabajo en equipo y próximos pasos

## Contexto

Se contempló un equipo de aproximadamente dos personas para Tienda, sin reparto formal. Axel tiene unos tres, casi cuatro años de experiencia como desarrollador full-stack .NET/React, principalmente backend, integración y modernización de sistemas legacy. Quiere trabajar en la implementación y desarrollar un proyecto con continuidad, con apoyo de Nano (asistente).

Inicialmente pidió ideas para presentar al grupo, no hacer por su cuenta toda la documentación académica. La documentación actual conserva contexto para conversar, dividir tareas y preparar estructura; no pretende ser una entrega académica final ni asignar trabajo unilateralmente.

## Reparto tentativo

- Compañero: panel administrativo, especialmente Parámetros, Productos y Noticias.
- Axel: editor, diseños reutilizables, composición, vista previa y parte pública de tienda/carrito.
- API: reparto por funcionalidades y contratos compartidos.
- Documentación académica, pruebas e integración: repartir mediante acuerdo.

No se sabe qué experiencia tiene el compañero con React. El panel ofrece CRUD más repetibles, pero archivos, validación y permisos no son necesariamente triviales.

Se sugirió construir juntos el primer CRUD como patrón. La ayuda del asistente no constituye garantía de plazos. La parte de Axel probablemente tiene más incertidumbre; reajustar la carga en lugar de atribuirle toda complejidad por ser quien propuso la idea.

## Pautas antes de trabajar en paralelo

Acordar estructura, nombres, contratos HTTP, manejo de errores, identificación de compañía, componentes compartidos, ramas y responsables de integración. Definir quién prepara autenticación y la base compartida.

No iniciar scaffolding ni elegir dependencias como si ya estuvieran aprobadas: el pedido actual es documentación.

## Secuencia sugerida, no calendario comprometido

1. Confirmar si se continúa como proyecto del curso o personal, y cerrar el alcance mínimo.
2. Definir flujo compañía → administración → personalización → vista previa.
3. Modelar compañía, productos y un bloque; acordar contratos antes de dividir módulos.
4. Construir un CRUD completo con persistencia y su pantalla.
5. Mostrar catálogo y hacer carrito con pago simulado.
6. Incorporar identidad, un diseño de sección y su vista previa.
7. Añadir repetición y orden de secciones; comprobar que el contenido sea independiente.
8. Integrar noticias, multimedia, archivos y correo según los casos acordados.
9. Contrastar la rúbrica y preparar demostración.
10. Evaluar publicación/exportación únicamente si queda tiempo y se decide ampliar.

Las etapas pueden priorizar una tienda de demostración antes del editor, pero no eliminan por sí mismas la intención de cuentas por compañía. Cualquier reducción de alcance debe declararse.

## Validaciones útiles para una futura implementación

- Un administrador no puede leer/modificar recursos privados de otra compañía.
- Dos bloques con el mismo diseño mantienen contenidos independientes.
- Añadir/quitar/reordenar no pierde bloques ajenos.
- Cambiar parámetros actualiza sus usos sin duplicación inconsistente.
- Totales y estados del pedido se validan en servidor; pago simulado claramente identificable.
- Catálogo, noticias y multimedia muestran información de la compañía correcta.
- Archivos y formularios rechazan entradas inválidas.
- No se compromete una vista previa como equivalente a producción desplegada.

No hay tests ni resultados de ejecución que reportar todavía.
