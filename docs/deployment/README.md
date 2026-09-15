# Despliegue previsto

Sin despliegue ni proveedor elegido. Delivery busca una demo pública reproducible con frontend, API y MySQL desplegados, HTTPS y configuración segura.

## Dirección del roadmap

- Docker y Docker Compose, configuración de entornos y health checks.
- Logging y observabilidad básica.
- Ampliar CI básico a GitHub Actions con validaciones completas y CD cuando exista destino definido.
- Documentar configuración, secretos, persistencia y recuperación.

Son actividades futuras y evolutivas; no hay contenedores, workflows ni infraestructura creada.

## Consideraciones

Una vista previa local no equivale a producción. Publicar/exportar archivos del frontend no despliega la API .NET ni MySQL. Con orígenes distintos se necesita API HTTPS accesible y políticas coherentes con autenticación.

Cambiar contenido de compañía obtenido de la API no debería requerir recompilar el frontend. Exportar a carpeta/ZIP sigue como propuesta fuera del alcance inicial; nunca incluir credenciales.

## Open Questions

- Cloud y servicios para frontend, API, MySQL y archivos: costos y compatibilidad.
- Entornos, dominios, rutas por compañía y certificados.
- Secretos, backups, restauración y persistencia en contenedores.
- CD, aprobación de despliegues y recuperación ante fallos.
- Herramientas de logging, métricas y health checks.
- Borrador/publicación y exposición de la demo.

Sites fue una opción mencionada para una demo; no está seleccionado ni existe integración. La estrategia cloud requiere evaluación y ADR.
