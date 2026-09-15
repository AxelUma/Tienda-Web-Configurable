# Cómo empezar

## Estado real

Solo hay documentación y .gitignore. No existen solución .NET, frontend React, dependencias, migraciones ni aplicación ejecutable. Todavía no hay comandos de instalación, build o pruebas.

## Lectura inicial

1. [README](../../README.md) y [AGENTS](../../AGENTS.md).
2. [Visión](../product/vision.md), [requisitos](../product/requirements.md) y [roadmap](../product/roadmap.md).
3. [Arquitectura](../architecture/overview.md), modelo conceptual, multi-tenancy, seguridad y persistencia enlazados desde README.
4. [ADR](../architecture/adr/README.md) y Open Questions del área de trabajo.

## Antes del primer código

Resolver decisiones que bloqueen el caso de uso inicial: versiones compatibles, convenciones, contratos HTTP y errores, contexto de compañía y dependencias justificadas. Registrar decisiones importantes en ADR. No hace falta cerrar todo el producto para iniciar una fase.

Crear proyectos y carpetas cuando tengan contenido funcional y exista una tarea de implementación. Acordar contratos y componentes compartidos antes de dividir trabajo entre módulos.

## Prácticas previstas

Código nuevo incluirá pruebas apropiadas y actualización documental. Priorizar aislamiento entre compañías, independencia de secciones, parámetros compartidos, totales/estados de pedidos y validación de archivos. Definir herramientas y comandos al crear la solución; ahora no hay pruebas de aplicación que reportar.

Revisar .gitignore al introducir herramientas. El archivo actual contempla artefactos Visual Studio/.NET, node_modules y archivos .env; eso no implica selección de dependencias. No versionar credenciales.
