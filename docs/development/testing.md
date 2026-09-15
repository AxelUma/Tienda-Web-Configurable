# Estrategia inicial de pruebas

Baseline aceptado en Phase 0; todavía no existen proyectos de pruebas ni resultados de ejecución de la aplicación. Se incorporarán pruebas junto al código correspondiente.

## Backend

- **xUnit v3** para pruebas backend.
- Unit tests de reglas puras de **Domain/Application**, sin servidor HTTP ni base cuando no sean necesarios.
- **Microsoft.AspNetCore.Mvc.Testing / WebApplicationFactory** para integration tests de la API y sus casos de uso.
- **Testcontainers** para integration tests que necesiten **MySQL real**, alineado con el baseline MySQL 8.4 LTS y el proveedor Oracle.
- Las pruebas relevantes de persistencia no sustituyen MySQL por **EF InMemory**: deben verificar consultas, restricciones y comportamiento del proveedor real.

## Aislamiento obligatorio desde Phase 1

Usar al menos dos compañías y verificar acceso autorizado y denegado: lecturas, creación, modificación, eliminación y asociaciones. Incluir intentos de manipular CompanyId del cliente y recursos de otro tenant. Los filtros no sustituyen pruebas de escrituras ni de operaciones que omiten filtros, si existen.

Mantener datos y ciclo de vida de pruebas aislados y reproducibles. La estructura concreta de proyectos/fixtures se definirá con el primer flujo, no mediante scaffolding anticipado.

## Frontend

- **Vitest** para pruebas frontend.
- **React Testing Library** para comportamiento de componentes desde la interacción del usuario.
- **Playwright** para E2E de flujos críticos cuando exista un flujo completo.

Priorizar acceso administrativo, aislamiento visible, catálogo de la compañía correcta, independencia y orden de secciones, checkout y pago simulado conforme aparezcan. Evitar pruebas que solo repliquen detalles de implementación.

## Evolución

Pruebas y seguridad comienzan con el código. Phase 6 amplía cobertura, accesibilidad y revisión de rendimiento; no posterga obligaciones de Phase 1. Medir rendimiento antes de optimizar. Los comandos y la integración continua se documentarán al existir proyectos y flujos ejecutables.
