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
| Backend | .NET 10 LTS, ASP.NET Core 10 y C# 14; arquitectura modular por capas Domain, Application, Infrastructure y API |
| Frontend | React 19.3, TypeScript 6 estable, Vite 8.x, Node.js 24 LTS y npm; organización por features |
| Persistencia | EF Core 10, MySql.EntityFrameworkCore oficial de Oracle y MySQL Server 8.4 LTS |
| Multi-tenancy | Una aplicación, base y tablas compartidas; discriminador CompanyId/TenantId y defensas en lecturas, escrituras y relaciones |
| Autenticación administrativa | ASP.NET Core Identity y cookies; protección CSRF y cookies HttpOnly/Secure en producción |
| Entrega | CI básico con GitHub Actions al crear el scaffolding de Phase 0; delivery completo y CD con destino definido en fases posteriores |

Application coordinará casos de uso, Domain concentrará reglas de negocio e Infrastructure resolverá persistencia y servicios externos. La API expondrá esos casos de uso y compondrá dependencias. No se añaden repositorios genéricos, MediatR/CQRS, microservicios o event bus por defecto.

El [baseline técnico](docs/development/technical-baseline.md) registra SDK 10.0.401, parches iniciales y política de actualización. React Router y TanStack Query se incorporarán cuando un flujo los necesite. REST JSON, ProblemDetails y códigos HTTP semánticos son las convenciones iniciales. Persistencia de PageSection, membresías, roles y cloud siguen abiertos.

## Estado actual

**Phase 0 — Foundation (diseño/fundación).** Decisiones técnicas formalizadas el 14 de septiembre de 2026. El repositorio contiene documentación, AGENTS.md, .gitignore y LICENSE. No existen solución .NET, proyecto React, migraciones, esquema definitivo, dependencias instaladas, workflows ni despliegue.

El objetivo es demostrar experiencia FullStack, especialmente backend .NET, con decisiones justificadas, pruebas y una entrega reproducible. Se podrán incorporar tecnologías nuevas cuando aporten valor técnico.

## Documentación

- [Visión](docs/product/vision.md), [requisitos y preguntas de producto](docs/product/requirements.md) y [roadmap](docs/product/roadmap.md).
- [Arquitectura y estructura futura](docs/architecture/overview.md), [modelo conceptual](docs/architecture/domain-model.md), [multi-tenancy](docs/architecture/multitenancy.md), [seguridad](docs/architecture/security.md) y [persistencia](docs/architecture/database.md).
- [Architecture Decision Records](docs/architecture/adr/README.md).
- [Cómo empezar](docs/development/getting-started.md), [despliegue previsto](docs/deployment/README.md) y [guía para agentes](AGENTS.md).
- [Baseline técnico y actualizaciones](docs/development/technical-baseline.md) y [estrategia de pruebas](docs/development/testing.md).
- [Archivo histórico](docs/archive/academic-context.md), sin autoridad sobre el alcance actual.

## Roadmap resumido

Foundation → Identity & Multi-tenancy → Catalog → Store Builder → Commerce → Content & Media → Quality → Infrastructure → Delivery.

Las fases son evolutivas. Pruebas, seguridad y documentación acompañarán al código desde el inicio; Quality profundizará esas prácticas. La entrega prevista incluye una demo pública, sin proveedor ni fecha comprometidos.

## Licencia

[MIT License](LICENSE) — Copyright (c) 2026 AxelUma. Las dependencias de terceros conservan sus propias licencias y avisos, incluido el proveedor MySQL de Oracle.
