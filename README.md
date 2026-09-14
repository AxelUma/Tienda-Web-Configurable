# Tienda Web Configurable

**Propuesta: Tienda Web Personalizable para pequeños negocios.**

Estado al **13 de septiembre de 2026**: planificación y documentación. No hay aplicación implementada, solución .NET, frontend React, base de datos creada ni despliegue. La propuesta no tiene selección o aprobación del profesor confirmada. Puede continuar como proyecto personal aunque se elija otra para el curso.

## Objetivo

Permitir que una compañía cree una cuenta administrativa, gestione su contenido y productos, y componga el inicio de su tienda mediante diseños de secciones preparados por el equipo. El resultado se demuestra con una **vista previa funcional**. Una panadería o repostería es el ejemplo propuesto; todavía no existe un negocio concreto elegido ni un diagnóstico validado con entrevistas.

La referencia para personalizar es **elegir diseños de diapositivas en PowerPoint**: añadir una sección, seleccionar su disposición y rellenar sus espacios. Se puede repetir un diseño con contenido independiente. No se limita la página a dos diseños completos ni a dos secciones fijas.

## Alcance que se viene proponiendo

- Cuenta administrativa por compañía; información y permisos separados por compañía.
- Panel independiente con **Parámetros, Productos, Noticias y Personalizar Tienda**.
- Inicio compuesto por secciones que se pueden añadir, quitar, ordenar y repetir.
- Header y footer de estructura limitada, con contenido y apariencia configurables.
- Tienda y carrito con distribución fija en esta primera versión.
- Pago simulado que cambia el estado del pedido, sin procesar dinero.
- Multimedia y noticias, más funciones del sílabo cuya ubicación exacta sigue por concretar.
- Vista previa funcional, demostrable localmente.

**No se acordaron cuentas de compradores, pago al recoger ni una instalación por negocio.** Esas interpretaciones anteriores fueron corregidas. La publicación, exportación y alojamiento comercial son ampliaciones, no promesas para el curso.

## Tecnologías propuestas

C# / ASP.NET Core para la API; React con TypeScript para el frontend; HTML, CSS y Bootstrap para la interfaz; peticiones AJAX con `fetch`; **MySQL**, elegido por Axel porque ya cuenta con él. Arquitectura ligera inspirada en Clean Architecture y DDD. Versiones, bibliotecas de persistencia y autenticación siguen pendientes.

## Documentación

1. [Alcance y comportamiento](docs/01-alcance.md): pantallas, usuarios, editor y límites.
2. [Arquitectura y datos](docs/02-arquitectura-y-datos.md): propuesta técnica, relaciones y archivos.
3. [Decisiones, correcciones y pendientes](docs/03-decisiones-y-pendientes.md): evolución y asuntos abiertos.
4. [Contexto académico](docs/04-contexto-academico.md): entregas, rúbricas y relación con el curso.
5. [Trabajo en equipo y próximos pasos](docs/05-planificacion.md): reparto tentativo y secuencia sugerida.
6. [Contexto para otra conversación](docs/06-contexto-para-chat.md): resumen autocontenido para adjuntar a ChatGPT.

Los documentos separan **definiciones expresadas por Axel**, **propuestas técnicas** y **decisiones pendientes**. No constituyen aprobación del equipo ni especificación cerrada.

## Procedencia y mantenimiento

Esta documentación consolida la conversación de planificación con el asistente llamado Nano, las notas locales iniciales y la propuesta compartida con los compañeros. Sustituye como referencia de trabajo las notas antiguas de `contexto-proyecto`, que contienen supuestos posteriormente corregidos. No se copiaron los textos de las otras propuestas ni los PDF del curso a este repositorio.

Actualizar estas notas cuando el grupo o el profesor decidan el alcance. No confundir una posibilidad conversada con un requisito aprobado. El propósito inmediato es conservar el contexto para separar tareas y preparar una estructura, sin implementar todavía.
