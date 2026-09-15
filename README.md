# Tienda Web Configurable

Proyecto personal y público de portafolio de **AxelUma**: una plataforma para que pequeños negocios administren su catálogo, contenido e identidad visual y compongan su tienda mediante secciones reutilizables.

## Problema y concepto del producto

El proyecto busca reducir el trabajo de crear y mantener un sitio a medida para cada negocio. Una misma aplicación atenderá múltiples compañías, con administración independiente y aislamiento de datos. Esta necesidad es una hipótesis pendiente de validar con negocios reales.

Cada tienda tendrá una página pública y un editor: el administrador seleccionará diseños preparados, completará su contenido y podrá añadir, quitar, repetir y ordenar secciones. Una plantilla representa el diseño de una sección, no un sitio completo. El constructor no será un editor HTML libre.

## Capacidades previstas

- Compañías, usuarios administrativos y autorización por compañía.
- Catálogo, categorías, productos e imágenes.
- Identidad visual configurable, páginas, secciones y vista previa.
- Storefront público separado de la administración.
- Carrito, checkout y pedidos con pago simulado inicialmente.
- Noticias, contenido y multimedia.

Las cuentas de compradores siguen abiertas; no son un requisito obligatorio. Ninguna de estas capacidades está implementada todavía.

## Arquitectura y stack previstos

| Área | Dirección |
| --- | --- |
| Backend | C# / ASP.NET Core modular; Domain, Application, Infrastructure y API; inspiración en Clean Architecture y DDD sin dogmatismo |
| Frontend | React + TypeScript por features y componentes reutilizables; HTML y CSS para la interfaz |
| Persistencia | MySQL elegido; Entity Framework Core previsto, sujeto a validar proveedor y compatibilidad |
| Entrega | CI básico al iniciar el código; infraestructura y demo pública en fases posteriores |

Application coordinará casos de uso, Domain concentrará reglas de negocio e Infrastructure resolverá persistencia y servicios externos. La API expondrá esos casos de uso. No se prevén microservicios sin una razón técnica real. Versiones, autenticación, bibliotecas de interfaz y estrategia cloud están pendientes.

## Estado actual

**Diseño/fundación — 14 de septiembre de 2026.** El repositorio contiene documentación y reglas de trabajo. No existen solución .NET, proyecto React, migraciones, esquema definitivo, dependencias instaladas ni despliegue.

El objetivo es demostrar experiencia FullStack, especialmente backend .NET, con decisiones justificadas, pruebas y una entrega reproducible. Se podrán incorporar tecnologías nuevas cuando aporten valor técnico.

## Documentación

- [Visión](docs/product/vision.md), [requisitos y preguntas de producto](docs/product/requirements.md) y [roadmap](docs/product/roadmap.md).
- [Arquitectura y estructura futura](docs/architecture/overview.md), [modelo conceptual](docs/architecture/domain-model.md), [multi-tenancy](docs/architecture/multitenancy.md), [seguridad](docs/architecture/security.md) y [persistencia](docs/architecture/database.md).
- [Architecture Decision Records](docs/architecture/adr/README.md).
- [Cómo empezar](docs/development/getting-started.md), [despliegue previsto](docs/deployment/README.md) y [guía para agentes](AGENTS.md).
- [Archivo histórico](docs/archive/academic-context.md), sin autoridad sobre el alcance actual.

## Roadmap resumido

Foundation → Identity & Multi-tenancy → Catalog → Store Builder → Commerce → Content & Media → Quality → Infrastructure → Delivery.

Las fases son evolutivas. Pruebas, seguridad y documentación acompañarán al código desde el inicio; Quality profundizará esas prácticas. La entrega prevista incluye una demo pública, sin proveedor ni fecha comprometidos.