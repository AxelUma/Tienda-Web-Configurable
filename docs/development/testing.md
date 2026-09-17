# Estrategia inicial de pruebas

Existen tres proyectos backend y pruebas frontend del scaffolding de Phase 0. Resultados y límites del equipo en el [registro de verificación](phase-0-verification.md).

## Pruebas actuales

- Tienda.Domain.Tests: el proyecto Domain no declara dependencias de proyecto, paquetes ni frameworks adicionales.
- Tienda.Application.Tests: Application referencia solo Domain y no agrega frameworks/paquetes.
- Tienda.Api.IntegrationTests: WebApplicationFactory verifica arranque en /health y ProblemDetails 404; una prueba Category=Docker abre MySQL 8.4.6 con Testcontainers y ejecuta SELECT VERSION() mediante el driver Oracle.
- Vitest/React Testing Library: el componente inicial identifica el proyecto e informa que las funciones de negocio no están disponibles.
- Playwright/Chromium: navegación y contenido de la compilación de producción mediante vite preview.

No hay DbContext ni entidades artificiales. La prueba MySQL comprueba conectividad, no consultas EF, migraciones ni aislamiento: esas pruebas de persistencia real llegan con el modelo de Phase 1. Los checks de dependencias leen los csproj copiados al output; no sustituyen una revisión completa de arquitectura.

## Backend

- **xUnit v3** para pruebas backend.
- Unit tests de reglas puras de **Domain/Application**, sin servidor HTTP ni base cuando no sean necesarios.
- **Microsoft.AspNetCore.Mvc.Testing / WebApplicationFactory** para integration tests de la API y sus casos de uso.
- **Testcontainers** para integration tests que necesiten **MySQL real**, alineado con el baseline MySQL 8.4 LTS y el proveedor Oracle.
- Las pruebas relevantes de persistencia no sustituyen MySQL por **EF InMemory**: deben verificar consultas, restricciones y comportamiento del proveedor real.

## Aislamiento obligatorio desde Phase 1

Usar al menos dos compañías y verificar acceso autorizado y denegado: lecturas, creación, modificación, eliminación y asociaciones. Incluir intentos de manipular CompanyId del cliente y recursos de otro tenant. Los filtros no sustituyen pruebas de escrituras ni de operaciones que omiten filtros, si existen.

Mantener datos y ciclo de vida de pruebas aislados y reproducibles. Los fixtures del modelo de negocio se definirán con el primer flujo; el test de conectividad actual no define ese modelo.

## Frontend

- **Vitest** para pruebas frontend.
- **React Testing Library** para comportamiento de componentes desde la interacción del usuario.
- **Playwright** para E2E de flujos críticos cuando exista un flujo completo.

Priorizar acceso administrativo, aislamiento visible, catálogo de la compañía correcta, independencia y orden de secciones, checkout y pago simulado conforme aparezcan. Evitar pruebas que solo repliquen detalles de implementación.

## Evolución

Pruebas y seguridad comienzan con el código. Phase 6 amplía cobertura, accesibilidad y revisión de rendimiento; no posterga obligaciones de Phase 1. Medir rendimiento antes de optimizar. Comandos en [cómo empezar](getting-started.md). El CI actual ejecuta todos los tests, incluida conectividad MySQL; no omite la categoría Docker.
