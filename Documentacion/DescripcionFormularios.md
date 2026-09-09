# Descripción de Formularios

## 1. frmLogin
**Descripción:** Pantalla de inicio de sesión

**Controles:**
- TextBox: usuario
- TextBox: contraseña (PasswordChar = "*")
- Botón: Login
- Botón: Salir

**Funcionalidades:**
- Valida credenciales contra la tabla Usuarios
- Determina el rol del usuario
- Abre el menú correspondiente según el rol
- Tecla Enter para navegar y enviar

---

## 2. frmMenuJefe
**Descripción:** Menú principal para usuarios con rol Jefe

**Botones:**
- Gestionar Productos → abre frmProductos
- Registro de Ventas → abre frmVentas
- Consultas → abre frmConsultas
- Cerrar Sesión → vuelve al login
- Salir → cierra la aplicación

**Información:**
- Muestra el usuario actual

---

## 3. frmMenuCliente
**Descripción:** Menú principal para usuarios con rol Cliente

**Botones:**
- Consultas de Productos → abre frmConsultas
- Cerrar Sesión → vuelve al login
- Salir → cierra la aplicación

**Restricciones:**
- No tiene acceso a gestión de productos
- No puede registrar ventas

---

## 4. frmMenuTrabajador
**Descripción:** Menú principal para usuarios con rol Trabajador

**Botones:**
- Registro de Ventas → abre frmVentas
- Cerrar Sesión → vuelve al login
- Salir → cierra la aplicación

**Restricciones:**
- No puede gestionar productos
- No tiene acceso a consultas

---

## 5. frmProductos
**Descripción:** Gestión completa de productos (CRUD)

**Controles:**
- TextBox: Nombre del producto
- TextBox: Precio
- TextBox: Stock
- TextBox: Descripción (MultiLine)
- TextBox: Buscar producto
- DataGridView: Lista de productos

**Botones:**
- Nuevo → Limpia los campos
- Guardar → Inserta nuevo producto
- Editar → Carga los datos del producto seleccionado
- Actualizar → Actualiza el producto seleccionado
- Eliminar → Elimina el producto seleccionado (con confirmación)
- Buscar → Busca productos por nombre
- Limpiar → Limpia todos los campos
- Cerrar → Cierra el formulario

**Validaciones:**
- Campos no pueden estar vacíos
- Precio debe ser numérico y mayor a 0
- Stock debe ser numérico
- Confirmación al eliminar

---

## 6. frmVentas
**Descripción:** Registro de ventas y visualización del historial

**Controles:**
- ComboBox: Selección de producto
- TextBox: Cantidad de venta
- Label: Muestra precio del producto
- Label: Muestra stock disponible
- DataGridView: Historial de ventas

**Botones:**
- Registrar Venta → Registra la venta en la BD
- Actualizar → Recarga el listado de ventas
- Cerrar → Cierra el formulario

**Funcionalidades:**
- Al seleccionar un producto, muestra precio y stock disponible
- Valida que haya cantidad disponible
- Actualiza automáticamente el stock del producto
- Registra el usuario y fecha de la venta
- Calcula el total automáticamente

---

## 7. frmConsultas
**Descripción:** Consulta de productos disponibles (solo lectura)

**Controles:**
- TextBox: Buscar producto
- DataGridView: Lista de productos (ReadOnly)

**Botones:**
- Buscar → Busca productos por nombre
- Limpiar → Limpia búsqueda y recarga lista
- Cerrar → Cierra el formulario

**Funcionalidades:**
- Muestra nombre, precio y stock
- Al hacer doble clic en un producto, muestra detalles
- No permite edición de datos
- Disponible para todos los roles (diferente visibilidad)

---

## Diseño de Interfaz Recomendado

### frmLogin
```
╔════════════════════════════════╗
║  Sistema de Ventas - Login     ║
╠════════════════════════════════╣
║                                ║
║  Usuario:    [_______________] ║
║  Contraseña: [_______________] ║
║                                ║
║  [  Login  ]  [  Salir  ]      ║
║                                ║
╚════════════════════════════════╝
```

### frmProductos
```
╔═══════════════════════════════════╗
║  Gestión de Productos            ║
╠═══════════════════════════════════╣
║  Nombre:     [______________]    ║
║  Precio:     [______________]    ║
║  Stock:      [______________]    ║
║  Descripción:[______________]    ║
║                                   ║
║  [Nuevo] [Guardar] [Editar]      ║
║  [Actualizar] [Eliminar]         ║
║                                   ║
║  Buscar: [______________] [Buscar]║
║  ╔═════════════════════════════╗ ║
║  ║ ID │ Nombre │ Precio│Stock ║ ║
║  ╠═════════════════════════════╣ ║
║  ║    │        │       │      ║ ║
║  ║    │        │       │      ║ ║
║  ╚═════════════════════════════╝ ║
║                                   ║
║  [Limpiar] [Cerrar]              ║
╚═══════════════════════════════════╝
```

## Colores Sugeridos

- **Fondo principal:** Blanco o gris claro (#F0F0F0)
- **Botones:** Azul (#0078D4)
- **Botones de acción peligrosa (Eliminar):** Rojo (#D13438)
- **Texto:** Negro (#000000)
- **Encabezados:** Azul oscuro (#003366)

