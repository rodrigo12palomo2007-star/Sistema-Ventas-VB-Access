# Guía de Instalación y Configuración

## 📋 Requisitos Previos

- Visual Studio 2019 o superior
- .NET Framework 4.7.2 o superior
- Microsoft Access 2010 o superior (para crear la base de datos)
- Windows 7 o superior

## 🚀 Pasos de Instalación

### 1. Clonar el Repositorio

```bash
git clone https://github.com/rodrigo12palomo2007-star/Sistema-Ventas-VB-Access.git
cd Sistema-Ventas-VB-Access
```

### 2. Preparar la Base de Datos

#### Opción A: Crear manualmente en Access

1. Abre **Microsoft Access**
2. Crea una nueva base de datos y guárdala como `VentasDB.accdb` en la carpeta `BaseDatos/`
3. Crea las siguientes tablas con los campos especificados:

**Tabla: Usuarios**
```
idUsuario (Número Entero) - Clave primaria, Autonumeración
usuario (Texto, 50 caracteres) - Único
contraseña (Texto, 100 caracteres)
rol (Texto, 20 caracteres) - Valores: Jefe, Cliente, Trabajador
estado (Sí/No) - Valor por defecto: Sí
```

**Tabla: Productos**
```
idProducto (Número Entero) - Clave primaria, Autonumeración
nombre (Texto, 100 caracteres)
precio (Moneda)
stock (Número Entero)
descripcion (Memo)
fechaCreacion (Fecha/Hora) - Valor por defecto: NOW()
```

**Tabla: Ventas**
```
idVenta (Número Entero) - Clave primaria, Autonumeración
idProducto (Número Entero) - Clave foránea
cantidad (Número Entero)
fecha (Fecha/Hora) - Valor por defecto: NOW()
usuario (Texto, 50 caracteres)
total (Moneda)
```

#### Opción B: Ejecutar script SQL

1. En Access, ve a **Herramientas > Base de datos > SQL**
2. Copia y ejecuta los scripts de `Documentacion/EstructuraDB.md`

### 3. Insertar Datos de Prueba

En Access, inserta los siguientes registros:

**Usuarios:**
```sql
INSERT INTO Usuarios VALUES ('admin', 'admin123', 'Jefe', TRUE);
INSERT INTO Usuarios VALUES ('cliente1', 'cliente123', 'Cliente', TRUE);
INSERT INTO Usuarios VALUES ('trabajador', 'trabajo123', 'Trabajador', TRUE);
```

**Productos:**
```sql
INSERT INTO Productos VALUES ('Laptop HP', 800, 10, 'Laptop 15.6 pulgadas', NOW());
INSERT INTO Productos VALUES ('Mouse Logitech', 25, 50, 'Mouse inalámbrico', NOW());
INSERT INTO Productos VALUES ('Teclado Mecánico', 120, 15, 'Teclado RGB', NOW());
INSERT INTO Productos VALUES ('Monitor 24"', 200, 8, 'Monitor Full HD', NOW());
```

### 4. Configurar el Proyecto en Visual Studio

1. Abre Visual Studio
2. Ve a **Archivo > Abrir > Proyecto/Solución**
3. Selecciona la carpeta del proyecto
4. Abre el archivo `.sln` (Solución)

### 5. Verificar la Ruta de la Base de Datos

1. Abre el archivo `Modulos/ModuloConexion.vb`
2. Verifica que la ruta en `connectionString` sea correcta:
   ```vb
   Public connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\BaseDatos\VentasDB.accdb"
   ```
3. Asegúrate de que el archivo `VentasDB.accdb` esté en la carpeta `BaseDatos/`

### 6. Compilar y Ejecutar

1. En Visual Studio, presiona **F5** o **Depurar > Iniciar Depuración**
2. La aplicación abrirá la pantalla de login
3. Utiliza las credenciales de prueba para acceder

## 🔐 Credenciales de Prueba

| Usuario | Contraseña | Rol |
|---------|-----------|-----|
| admin | admin123 | Jefe |
| cliente1 | cliente123 | Cliente |
| trabajador | trabajo123 | Trabajador |

## 🎯 Características por Rol

### Jefe (admin)
- ✅ Gestión completa de productos (CRUD)
- ✅ Registro de ventas
- ✅ Consultas de productos
- ✅ Acceso a reportes

### Cliente (cliente1)
- ✅ Consultas de productos disponibles
- ❌ No puede gestionar productos
- ❌ No puede registrar ventas

### Trabajador (trabajador)
- ✅ Registro de ventas
- ❌ No puede gestionar productos
- ❌ No puede acceder a consultas

## 🐛 Solución de Problemas

### Error: "No se puede encontrar la base de datos"

**Solución:**
1. Verifica que `VentasDB.accdb` esté en `BaseDatos/`
2. Revisa la ruta en `ModuloConexion.vb`
3. Asegúrate de tener permisos de lectura en la carpeta

### Error: "Proveedor no encontrado"

**Solución:**
1. Instala el **Microsoft Access Database Engine 2016** (32 o 64 bits según tu sistema)
2. Descárgalo desde: https://www.microsoft.com/en-us/download/details.aspx?id=54920

### Error de Conexión OLEDB

**Solución:**
1. Abre **Panel de Control > Programas > Características de Windows**
2. Activa **.NET Framework 3.5**
3. Reinicia Visual Studio y el proyecto

## 📁 Estructura de Carpetas

```
Sistema-Ventas-VB-Access/
├── BaseDatos/
│   └── VentasDB.accdb          ← Base de datos (crear manualmente)
├── Documentacion/
│   ├── EstructuraDB.md
│   └── INSTRUCCIONES.md
├── Formularios/
│   ├── frmLogin.vb
│   ├── frmMenuJefe.vb
│   ├── frmMenuCliente.vb
│   ├── frmMenuTrabajador.vb
│   ├── frmProductos.vb
│   ├── frmVentas.vb
│   └── frmConsultas.vb
├── Modulos/
│   ├── ModuloConexion.vb
│   ├── ModuloProductos.vb
│   ├── ModuloVentas.vb
│   └── ModuloUsuarios.vb
├── README.md
└── Sistema-Ventas-VB-Access.sln
```

## 🔄 Mantener la Aplicación

### Hacer respaldo de la base de datos:
```bash
copy BaseDatos\VentasDB.accdb BaseDatos\VentasDB_backup.accdb
```

### Limpiar datos de prueba:
1. Abre `VentasDB.accdb` en Access
2. Elimina los registros de prueba de cada tabla
3. Deja los usuarios básicos para pruebas

## 📞 Soporte

Si encuentras problemas:
1. Revisa los logs de Visual Studio (Salida > Error)
2. Verifica la estructura de la base de datos
3. Asegúrate de tener las versiones correctas de .NET
4. Crea un Issue en el repositorio

## ✨ Próximos Pasos

Después de la instalación:
1. Prueba cada rol de usuario
2. Verifica todas las funcionalidades
3. Personaliza según tus necesidades
4. Implementa cifrado de contraseñas mejorado en producción

---

**¡Instalación completada! Disfruta del Sistema de Ventas** 🎉
