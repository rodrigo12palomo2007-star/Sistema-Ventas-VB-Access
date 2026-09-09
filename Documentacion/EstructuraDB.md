# Estructura de la Base de Datos

## Tablas necesarias en Access

### 1. Tabla: Usuarios
```
Campo          | Tipo       | Descripción
---------------|-----------|------------------
idUsuario      | Entero     | Clave primaria
usuario        | Texto      | Nombre de usuario único
contraseña     | Texto      | Contraseña del usuario
rol            | Texto      | Jefe/Cliente/Trabajador
estado         | Lógico     | Activo/Inactivo
```

### 2. Tabla: Productos
```
Campo          | Tipo       | Descripción
---------------|-----------|------------------
idProducto     | Entero     | Clave primaria
nombre         | Texto      | Nombre del producto
precio         | Moneda     | Precio unitario
stock          | Entero     | Cantidad disponible
descripcion    | Memo       | Descripción (opcional)
fechaCreacion  | Fecha      | Fecha de creación
```

### 3. Tabla: Ventas
```
Campo          | Tipo       | Descripción
---------------|-----------|------------------
idVenta        | Entero     | Clave primaria
idProducto     | Entero     | FK a Productos
cantidad       | Entero     | Cantidad vendida
fecha          | Fecha      | Fecha de la venta
usuario        | Texto      | Usuario que registró
total          | Moneda     | Total de la venta
```

## Scripts SQL para crear las tablas

```sql
-- Tabla Usuarios
CREATE TABLE Usuarios (
    idUsuario AUTOINCREMENT PRIMARY KEY,
    usuario TEXT NOT NULL UNIQUE,
    contraseña TEXT NOT NULL,
    rol TEXT NOT NULL,
    estado YESNO DEFAULT TRUE
);

-- Tabla Productos
CREATE TABLE Productos (
    idProducto AUTOINCREMENT PRIMARY KEY,
    nombre TEXT NOT NULL,
    precio CURRENCY NOT NULL,
    stock INTEGER NOT NULL,
    descripcion MEMO,
    fechaCreacion DATETIME DEFAULT NOW()
);

-- Tabla Ventas
CREATE TABLE Ventas (
    idVenta AUTOINCREMENT PRIMARY KEY,
    idProducto INTEGER NOT NULL,
    cantidad INTEGER NOT NULL,
    fecha DATETIME DEFAULT NOW(),
    usuario TEXT NOT NULL,
    total CURRENCY NOT NULL,
    FOREIGN KEY (idProducto) REFERENCES Productos(idProducto)
);
```

## Datos de prueba

### Usuarios iniciales
```
Usuario: admin      | Contraseña: admin123    | Rol: Jefe
Usuario: cliente1   | Contraseña: cliente123  | Rol: Cliente
Usuario: trabajador | Contraseña: trabajo123  | Rol: Trabajador
```

### Productos de ejemplo
```
Laptop HP          | Precio: $800   | Stock: 10
Mouse Logitech     | Precio: $25    | Stock: 50
Teclado Mecánico   | Precio: $120   | Stock: 15
Monitor 24"        | Precio: $200   | Stock: 8
```
