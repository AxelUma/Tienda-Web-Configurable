# Roadmap

Plan evolutivo por fases técnicas, sin fechas arbitrarias ni compromiso contractual. Estado: **Phase 0 — Foundation, formalización documental de decisiones**; ninguna fase de implementación está completada.

Las fases pueden solaparse o cambiar según dependencias y aprendizaje. Pruebas, seguridad y documentación acompañan al código desde el inicio; Quality amplía cobertura y revisiones, no las posterga.

## Phase 0 — Foundation

- Consolidar visión, requisitos, arquitectura, ADR y preguntas abiertas.
- Baseline aceptado: .NET 10/ASP.NET Core 10/C# 14, frontend y herramientas de pruebas; arquitectura, proveedor Oracle/EF Core 10, tenant compartido e Identity/cookies formalizados en ADR-0002 a ADR-0005.
- Al comenzar implementación, verificar versiones resueltas y compatibilidad en ejecución; crear global.json y archivos de bloqueo apropiados según el [baseline técnico](../development/technical-baseline.md).
- Crear solución inicial backend y frontend inicial al comenzar implementación.
- REST JSON y ProblemDetails aceptados; concretar convenciones restantes con primeros casos de uso.
- Al crear el scaffolding real, crear CI básico con GitHub Actions: restore/install, build, lint/format cuando corresponda y tests disponibles, proporcional al estado inicial. Sin workflows en esta tarea documental.
- Referencia de salida: base mínima reproducible y documentada.

## Phase 1 — Identity & Multi-tenancy

- Compañías y usuarios administrativos.
- Resolver una o múltiples compañías por usuario, memberships, roles definitivos e invitaciones/alta administrativa antes de implementar el modelo funcional de Identity/multi-tenancy que dependa de esas decisiones. Siguen abiertas y no bloquean el esqueleto técnico de Phase 0.
- Implementar Identity/cookies y autorización conforme a esas definiciones.
- Implementar base/tablas compartidas, discriminador, query filters y validaciones de escrituras/relaciones conforme al ADR-0004.
- Referencia de salida: integration tests obligatorios de acceso permitido y denegado entre al menos dos compañías, con MySQL real para persistencia relevante.

## Phase 2 — Catalog

- Categorías, productos e imágenes.
- Administración y storefront por compañía.
- Resolver disponibilidad/inventario según alcance acordado.
- Referencia de salida: flujo completo de administración y consulta pública aislado por tenant.

## Phase 3 — Store Builder

- Configuración visual, páginas, templates y PageSection.
- Evaluar almacenamiento de contenido antes de persistirlo.
- Edición, repetición, eliminación, ordenamiento y preview.
- Referencia de salida: secciones repetidas con contenido independiente y composición persistente.

## Phase 4 — Commerce

- Carrito, checkout, pedidos y OrderItem.
- Snapshots de precios, validación de totales y pago simulado.
- Resolver estados, reintentos, cancelaciones y datos de checkout.
- Referencia de salida: pedido consistente y pago claramente simulado; cuentas de compradores no obligatorias.

## Phase 5 — Content & Media

- Noticias, multimedia y archivos.
- Bloques integrados con contenido administrativo.
- Concretar usos de documentos, tipos, límites y permisos.
- Referencia de salida: contenido de la compañía correcta y cargas/accesos validados.
- El manejo mínimo de imágenes requerido por Catalog se incorpora allí, sin esperar esta ampliación.

## Phase 6 — Quality

- Ampliar unit tests, integration tests, frontend tests y E2E sobre el [baseline de pruebas](../development/testing.md): xUnit v3, WebApplicationFactory, Testcontainers, Vitest, React Testing Library y Playwright. No posponer aislamiento hasta esta fase.
- Seguridad, accesibilidad y performance básico.
- Referencia de salida: evidencia sobre flujos críticos y corrección de problemas encontrados.

## Phase 7 — Infrastructure

- Docker, Docker Compose y configuración de entornos.
- Health checks, logging y observabilidad básica.
- Referencia de salida: entorno reproducible con persistencia/configuración documentadas.
- Adelantar infraestructura necesaria para desarrollo o CI cuando aporte valor.

## Phase 8 — Delivery

- Ampliar la automatización de GitHub Actions iniciada en Phase 0 con CI completo y el pipeline de delivery.
- Incorporar CD solo cuando exista un destino de despliegue definido y añadir los controles operativos/deployment correspondientes.
- Cloud deployment, HTTPS y base de datos desplegada.
- Demo pública e instrucciones operativas y de recuperación.
- Referencia de salida: despliegue verificable; proveedor y estrategia sujetos a evaluación.

## Open Questions

Primer corte funcional y criterios concretos se refinarán al comenzar cada fase. Consultar [producto](requirements.md) y [arquitectura](../architecture/overview.md) antes de asumir alcance o herramientas.
