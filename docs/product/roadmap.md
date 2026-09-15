# Roadmap

Plan evolutivo por fases técnicas, sin fechas arbitrarias ni compromiso contractual. Estado: **Phase 0, consolidación documental**; ninguna fase de implementación está completada.

Las fases pueden solaparse o cambiar según dependencias y aprendizaje. Pruebas, seguridad y documentación acompañan al código desde el inicio; Quality amplía cobertura y revisiones, no las posterga.

## Phase 0 — Foundation

- Consolidar visión, requisitos, arquitectura, ADR y preguntas abiertas.
- Resolver decisiones que bloqueen el primer caso de uso; validar versiones/proveedor.
- Crear solución inicial backend y frontend inicial al comenzar implementación.
- Convenciones, contratos, errores y CI básico.
- Referencia de salida: base mínima reproducible y documentada.

## Phase 1 — Identity & Multi-tenancy

- Compañías y usuarios administrativos.
- Autenticación, autorización y relación de usuarios con compañías.
- Estrategia de tenant y aislamiento de lecturas, escrituras y relaciones.
- Referencia de salida: pruebas de acceso permitido y denegado entre compañías.

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

- Ampliar unit tests, integration tests, frontend tests y E2E.
- Seguridad, accesibilidad y performance básico.
- Referencia de salida: evidencia sobre flujos críticos y corrección de problemas encontrados.

## Phase 7 — Infrastructure

- Docker, Docker Compose y configuración de entornos.
- Health checks, logging y observabilidad básica.
- Referencia de salida: entorno reproducible con persistencia/configuración documentadas.
- Adelantar infraestructura necesaria para desarrollo o CI cuando aporte valor.

## Phase 8 — Delivery

- GitHub Actions, CI completo y CD.
- Cloud deployment, HTTPS y base de datos desplegada.
- Demo pública e instrucciones operativas y de recuperación.
- Referencia de salida: despliegue verificable; proveedor y estrategia sujetos a evaluación.

## Open Questions

Primer corte funcional y criterios concretos se refinarán al comenzar cada fase. Consultar [producto](requirements.md) y [arquitectura](../architecture/overview.md) antes de asumir alcance o herramientas.
