# Seguridad prevista

No hay autenticación ni controles implementados. Estos criterios orientan su diseño y verificación.

## Principios

- Autenticar administradores y autorizar operaciones para su compañía; aplicar [aislamiento](multitenancy.md) en servidor.
- Reglas de negocio fuera de controllers; validar entradas aunque el frontend use TypeScript.
- Calcular precios/totales en servidor, preservar precios históricos y definir transiciones del pago simulado.
- Plantillas mediante códigos conocidos; no ejecutar HTML, rutas o código arbitrario del usuario.
- Una referencia de archivo no concede acceso. Distinguir imágenes públicas de documentos privados y comprobar permisos.
- Definir tipos, tamaños, validación y ciclo de vida de cargas; impedir acceso entre compañías.
- Secretos fuera del repositorio y frontend; HTTPS y orígenes permitidos al desplegar.
- Pruebas negativas de permisos, entradas inválidas y aislamiento desde el inicio.

## Open Questions

- Autenticación, sesiones y recuperación de acceso. JWT, cookies y ASP.NET Core Identity son opciones no decididas.
- Roles, membresías, alta administrativa e invitaciones.
- Datos personales del checkout, acceso al pedido, retención y eliminación.
- Reintentos, efecto de simular el pago dos veces, cancelaciones y estados.
- Formatos y seguridad de contenido enriquecido si se incorpora.
- CSRF según autenticación, CORS según despliegue, límites de solicitudes y cargas.
- Proveedor y permisos de archivos públicos/privados.
- Correos, si se incorporan: eventos, proveedor y manejo de errores.

Las cuentas de compradores siguen abiertas. Autenticación requiere evaluación y ADR.
