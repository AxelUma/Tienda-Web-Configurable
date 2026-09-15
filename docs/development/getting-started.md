# Cómo empezar

## Estado real

Phase 0 — Foundation. El repositorio contiene documentación, AGENTS.md, .gitignore y LICENSE. No existen solución .NET, frontend React, dependencias instaladas, migraciones, workflows ni aplicación ejecutable. Todavía no hay comandos de instalación, build o pruebas.

## Lectura inicial

1. [README](../../README.md) y [AGENTS](../../AGENTS.md).
2. [Visión](../product/vision.md), [requisitos](../product/requirements.md) y [roadmap](../product/roadmap.md).
3. [Arquitectura](../architecture/overview.md), modelo conceptual, multi-tenancy, seguridad y persistencia enlazados desde README.
4. [ADR](../architecture/adr/README.md), [baseline técnico](technical-baseline.md), [estrategia de pruebas](testing.md) y Open Questions del área de trabajo.

## Antes del primer código

Ya están aceptados plataforma, arquitectura por capas, proveedor Oracle/EF Core 10, MySQL 8.4 LTS, tenant compartido e Identity/cookies. REST JSON y ProblemDetails son las convenciones HTTP iniciales. No volver a presentarlos como decisiones pendientes.

Antes del primer código, concretar lo que bloquee el caso de uso: membresías/roles, nombres, contratos específicos y dependencias justificadas. Registrar decisiones importantes en ADR. No hace falta cerrar todo el producto para iniciar una fase.

Al implementar, crear global.json para SDK 10 compatible con la política de roll-forward del baseline, registrar versiones resueltas y verificarlas con las pruebas apropiadas. No instalar paquetes ni crear proyectos, migraciones o workflows durante esta tarea documental.

Crear proyectos y carpetas cuando tengan contenido funcional y exista una tarea de implementación. Acordar contratos y componentes compartidos antes de dividir trabajo entre módulos.

## Prácticas previstas

Código nuevo incluirá pruebas apropiadas y actualización documental. Priorizar aislamiento entre compañías, independencia de secciones, parámetros compartidos, totales/estados de pedidos y validación de archivos. Las herramientas ya están definidas en la estrategia de pruebas; los comandos se documentarán al crear la solución. Aislamiento entre al menos dos compañías es obligatorio desde Phase 1. Ahora no hay pruebas de aplicación que reportar.

Revisar .gitignore al introducir herramientas. El archivo actual contempla artefactos Visual Studio/.NET, node_modules y archivos .env; eso no implica selección de dependencias. No versionar credenciales.
