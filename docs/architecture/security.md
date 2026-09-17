# Seguridad prevista

Phase 0: decisiones aceptadas, sin autenticación ni controles de autorización implementados. La API mínima registra ProblemDetails.

## Autenticación administrativa aceptada

[ADR-0005](adr/0005-browser-identity-cookies.md) define **ASP.NET Core Identity y cookie authentication** para el panel web. Cookies de autenticación **HttpOnly** y **Secure en producción** sobre HTTPS.

Diseñar SameSite, envío de credenciales y protección antiforgery/CSRF para los orígenes y flujos reales. SameSite no es la única protección CSRF; CORS no sustituye autorización ni antiforgery. No almacenar tokens de autenticación en localStorage ni usar JWT como predeterminado del SPA.

OAuth/OIDC/bearer permanece como estrategia futura abierta para móviles, integraciones externas, terceros o una API pública real. No diseñar ahora un identity server para clientes inexistentes. Identity no define aún roles ni una o múltiples compañías por usuario.

## Principios

- Autorizar operaciones para la compañía desde el contexto de identidad; [aislamiento](multitenancy.md) en servidor. Slug público o CompanyId del cliente no concede permisos administrativos.
- Query filters como defensa de lectura más validaciones de escritura/relaciones y restricciones por tenant cuando sea viable. Revisar raw SQL y operaciones que omitan filtros.
- Reglas de negocio fuera de controllers/endpoints; validar entradas aunque el frontend use TypeScript.
- Calcular precios/totales en servidor, preservar precios históricos y definir transiciones del pago simulado.
- Plantillas mediante códigos conocidos, sin HTML, rutas o código arbitrario del usuario.
- Una referencia de archivo no concede acceso. Distinguir imágenes públicas y documentos privados y comprobar permisos.
- Definir tipos, tamaños, validación y ciclo de vida de cargas.
- Secretos fuera del repositorio/frontend; no exponer excepciones internas al cliente. Logs estructurados sin credenciales.
- Pruebas negativas de permisos, entradas e aislamiento; al menos dos compañías desde Phase 1.

## Open Questions

- Duración y revocación de sesiones, recuperación, alta e invitaciones.
- Roles definitivos y una o múltiples memberships por usuario.
- Valores concretos de SameSite, flujo antiforgery y CORS según despliegue; límites de solicitudes y cargas.
- Cuentas de compradores; datos personales de checkout, acceso al pedido, retención y eliminación.
- Reintentos de pago simulado, cancelaciones y estados; pagos reales fuera del alcance inicial y sin estrategia decidida.
- Formatos y seguridad de contenido enriquecido si se incorpora.
- Proveedor y permisos de archivos públicos/privados.
- Correos, si se incorporan: eventos, proveedor y manejo de errores.
- Estrategia futura OAuth/OIDC/bearer solo si aparecen los consumidores indicados.

La configuración concreta se probará con el flujo real; no hay permisos ni sesiones administrativas implementados; solo existe infraestructura técnica de scaffolding y CI.
