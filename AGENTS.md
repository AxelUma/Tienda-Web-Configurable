# Guía para agentes

- Proyecto personal y público de portafolio: tiendas configurables para pequeños negocios. Leer README y la documentación del área antes de modificarla.
- Estado: diseño/fundación. No hay aplicación ni comandos de build definidos. Ejecutar solo el alcance solicitado.
- Backend previsto: ASP.NET Core modular, inspirado en Clean Architecture y DDD sin dogmatismo. Domain no depende de otras capas; Application depende de Domain; Infrastructure implementa contratos de Application y puede depender de Domain; API usa Application y conecta Infrastructure en la composición de dependencias.
- Organizar backend por features/casos de uso dentro de las capas. Reglas de negocio en Domain y coordinación en Application, nunca en controllers.
- Frontend previsto: React + TypeScript por features, componentes reutilizables y separación entre administración y storefront.
- MySQL está elegido. EF Core es la dirección prevista, pendiente de validar proveedor y compatibilidad. No asumir decisiones de las secciones Open Questions.
- Toda entidad perteneciente a una compañía debe respetar aislamiento de tenant. Validar pertenencia y autorización en servidor en lecturas, escrituras, relaciones y archivos. Un identificador del cliente no concede acceso.
- Una plantilla define una sección; cada instancia conserva contenido y orden propios. No introducir HTML libre ni instalaciones por compañía. Las cuentas de compradores siguen abiertas.
- Preferir soluciones simples que resuelvan correctamente el problema. Evitar repositorios genéricos, abstracciones y microservicios sin necesidad demostrada.
- No añadir paquetes/dependencias sin razón técnica. Se permiten tecnologías y prácticas nuevas cuando aporten valor y aprendizaje relevante; no limitarse a lo conocido por el autor.
- Registrar cambios arquitectónicos importantes en un [ADR](docs/architecture/adr/README.md), distinguiendo propuestas de decisiones aceptadas.
- Código nuevo debe incluir pruebas apropiadas, especialmente de aislamiento y reglas de negocio. Actualizar documentación afectada junto con el código y reportar verificaciones realmente ejecutadas.