# ADR-0005: Autenticación administrativa con Identity y cookies

## Status

Accepted — 14 de septiembre de 2026, para el cliente web administrativo.

## Context

El cliente principal actual es una aplicación en navegador. La [guía de ASP.NET Core para Identity y SPAs](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity-api-authorization?view=aspnetcore-10.0) recomienda cookies para ese escenario, aprovechando su manejo por el navegador sin exponer la credencial a JavaScript.

No existen clientes móviles, integraciones externas ni una API pública para terceros que justifiquen diseñar ahora un servidor de identidad.

## Decision

- Usar **ASP.NET Core Identity** y **cookie authentication** para el panel administrativo.
- Cookies de autenticación **HttpOnly**, y **Secure en producción** sobre HTTPS.
- Diseñar **SameSite** y protección **antiforgery/CSRF** según los orígenes y flujos reales. SameSite no reemplaza por sí solo la protección antiforgery.
- No almacenar tokens de autenticación en **localStorage** ni usar JWT como opción predeterminada del SPA.
- Mantener autorización por compañía además de autenticación: iniciar sesión no concede acceso a cualquier tenant.

## Alternatives considered

- JWT/bearer por defecto para el SPA: no se necesita para el cliente actual y añade gestión de credenciales en el cliente.
- OAuth/OIDC/bearer: estrategia futura abierta para móviles, integraciones externas, clientes de terceros o una API pública real.
- Identity server propio ahora: no hay consumidores que lo justifiquen.

## Consequences

- Diseñar duración/revocación de sesiones, recuperación, envío de credenciales y CSRF durante la implementación; no fijar valores sin el flujo real.
- CORS y SameSite deben ser coherentes con el despliegue, aún abierto. HttpOnly no elimina los riesgos XSS y CORS no sustituye autorización ni CSRF.
- La integración de Identity no introduce dependencia de sus tipos en Domain ni decide tablas de membresía.
- Continúan abiertos roles, una o múltiples compañías por usuario, alta/invitaciones y cuentas de compradores.
- No hay autenticación implementada ni servidor OAuth/OIDC creado.
