# ADR-0002: Arquitectura modular por capas

## Status

Accepted — 14 de septiembre de 2026, formalización de la dirección vigente en Phase 0.

## Context

La plataforma tendrá administración, catálogo, constructor y comercio compartiendo reglas de compañía. Necesita límites claros y pruebas de negocio sin acoplar el dominio a HTTP o persistencia. La separación por capas ya era una regla operativa; se formaliza antes del scaffolding.

## Decision

Una aplicación backend modular con cuatro proyectos previstos:

- **Tienda.Domain:** entidades e invariantes; no depende de otras capas ni de frameworks web/persistencia.
- **Tienda.Application:** casos de uso y contratos necesarios; depende de Domain.
- **Tienda.Infrastructure:** implementa contratos de servicios y persistencia; puede depender de Application y Domain.
- **Tienda.Api:** capa HTTP y composition root; usa Application y conecta Infrastructure para componer dependencias.

Organizar internamente por features/casos de uso dentro de las capas. Reglas de negocio en Domain y coordinación en Application, nunca en controllers/endpoints. No introducir generic repository por defecto ni MediatR, CQRS, microservicios o event bus sin una necesidad concreta.

Clean Architecture y DDD son guías pragmáticas. Los contratos y abstracciones se crean cuando resuelven un problema, no para cumplir una estructura ceremonial.

## Alternatives considered

- Concentrar negocio, HTTP y persistencia en endpoints: no ofrece los límites que el proyecto busca mantener y probar.
- Microservicios o infraestructura de mensajería desde el inicio: sin necesidad actual que justifique operación y coordinación distribuidas.
- Aplicación dogmática de patrones y repositorios genéricos: añade abstracciones antes de conocer los casos de uso.

Son razones de diseño, no resultados de benchmarks o prototipos comparativos.

## Consequences

- Las dependencias apuntan hacia el negocio; API concentra la composición de implementaciones.
- Los casos de uso verifican autorización y aislamiento además de los controles HTTP.
- Nuevas features deben respetar límites y aportar pruebas apropiadas, evitando interfaces que solo repliquen APIs existentes.
- Al aceptar este ADR los proyectos aún no existían; el scaffolding del 16 de septiembre de 2026 materializa estos límites. Cambiarlos requiere otro ADR.
