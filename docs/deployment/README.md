# Despliegue previsto

Sin despliegue ni proveedor elegido. Delivery busca una demo pública reproducible con frontend, API y MySQL Server 8.4 LTS desplegados, HTTPS y configuración segura.

## Dirección del roadmap

- Docker y Docker Compose, configuración de entornos y health checks.
- Logs estructurados y observabilidad básica; herramientas concretas aún abiertas.
- Phase 0: CI básico de GitHub Actions configurado para restore/install, build, lint/format y pruebas; incluye Testcontainers/MySQL y Playwright.
- Phase 8 — Delivery: ampliar esa automatización con el pipeline completo de delivery y controles operativos/deployment; incorporar CD únicamente cuando exista un destino definido.
- Documentar configuración, secretos, persistencia y recuperación.

CI básico y /health existen como scaffolding. Docker/MySQL se usa de forma efímera en tests mediante Testcontainers; no existe Compose, infraestructura desplegada ni CD. Logs estructurados y observabilidad concreta siguen como trabajo futuro.

## Consideraciones

Usar el parche soportado más reciente de MySQL 8.4 LTS al desplegar. Mantener configuración por entorno y secretos fuera del repositorio. El baseline de Identity/cookies requiere HttpOnly, Secure en producción y diseño de SameSite/antiforgery coherente con los orígenes elegidos. No se selecciona proveedor cloud ni topología de dominios todavía.

Una vista previa local no equivale a producción. Publicar/exportar archivos del frontend no despliega la API .NET ni MySQL. Con orígenes distintos se necesita API HTTPS accesible y políticas coherentes con autenticación.

Cambiar contenido de compañía obtenido de la API no debería requerir recompilar el frontend. Exportar a carpeta/ZIP sigue como propuesta fuera del alcance inicial; nunca incluir credenciales.

## Open Questions

- Cloud y servicios para frontend, API, MySQL y archivos: costos y compatibilidad.
- Entornos, dominios, rutas por compañía y certificados.
- Secretos, backups, restauración y persistencia en contenedores.
- CD, aprobación de despliegues y recuperación ante fallos.
- Herramientas de logging, métricas, health checks y observabilidad concreta.
- CDN, caché/Redis y message broker: sin selección ni incorporación anticipada.
- Borrador/publicación y exposición de la demo.

Sites fue una opción mencionada para una demo; no está seleccionado ni existe integración. La estrategia cloud requiere evaluación y ADR.
