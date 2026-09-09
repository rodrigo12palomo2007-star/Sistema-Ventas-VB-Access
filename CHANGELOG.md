# Sistema de Ventas - Cambios y Versiones

## Versión 1.0.0 - Inicial (2026-09-09)

### ✨ Características
- ✅ Sistema de login con validación de usuario y rol
- ✅ Menú diferenciado por rol (Jefe, Cliente, Trabajador)
- ✅ CRUD completo de productos
- ✅ Registro de ventas con actualización automática de stock
- ✅ Consultas de productos disponibles
- ✅ Base de datos en Access con 3 tablas principales
- ✅ Validación de campos y manejo de errores
- ✅ Mensajes de confirmación

### 🔧 Técnico
- Base de datos: Microsoft Access (.accdb)
- ORM: ADO.NET con OleDbConnection
- Framework: .NET Framework 4.7.2
- Lenguaje: Visual Basic .NET

### 📁 Archivos Agregados
- Formularios: 7 archivos (Login, 3 Menús, Productos, Ventas, Consultas)
- Módulos: 4 archivos (Conexión, Usuarios, Productos, Ventas)
- Documentación: 4 archivos (README, Estructura DB, Instrucciones, Descripción Formularios)

---

## Próximas Versiones Planeadas

### v1.1.0 - Mejoras de Seguridad
- [ ] Cifrado SHA256 para contraseñas
- [ ] Auditoría de acciones de usuario
- [ ] Bloqueo de cuenta después de intentos fallidos
- [ ] Cambio de contraseña por usuario

### v1.2.0 - Reportes y Análisis
- [ ] Reporte de ventas por fecha
- [ ] Reporte de inventario
- [ ] Gráficos de ventas mensuales
- [ ] Exportar reportes a PDF

### v1.3.0 - Funcionalidades Avanzadas
- [ ] Sistema de devoluciones
- [ ] Gestión de clientes
- [ ] Descuentos y promociones
- [ ] Backups automáticos

### v2.0.0 - Migración a Base de Datos Moderna
- [ ] Migrar de Access a SQL Server
- [ ] API REST
- [ ] Aplicación móvil
- [ ] Sincronización en la nube

---

## Historial de Cambios

### 2026-09-09
- Commit: `3c00e93` - docs: Agregar estructura de base de datos
- Commit: `0831c9a` - feat: Agregar módulos de conexión, productos, ventas y usuarios
- Commit: `a498dee` - feat: Agregar formularios de menús (Jefe, Cliente, Trabajador)
- Commit: `88e4a08` - feat: Agregar formularios de productos, ventas y consultas
- Commit: `019e71a` - docs: Agregar guías de instalación, descripción de formularios y desarrollo

---

## Problemas Conocidos

- ⚠️ La encriptación actual es básica (Base64). Usar SHA256 en producción.
- ⚠️ No hay validación de SQL injection en algunas consultas. Usar prepared statements.
- ⚠️ El backup automático no está implementado en v1.0

---

## Contribuciones

Para contribuir:
1. Fork el repositorio
2. Crea una rama: `git checkout -b feature/nueva-funcionalidad`
3. Realiza cambios y commit: `git commit -am 'Agregar nueva funcionalidad'`
4. Push a la rama: `git push origin feature/nueva-funcionalidad`
5. Abre un Pull Request

---

## Licencia

Este proyecto está disponible bajo licencia MIT.

---

**Última actualización**: 2026-09-09
