# Guía de Desarrollo y Personalización

## 🔧 Modificar la Cadena de Conexión

En `ModuloConexion.vb`:

```vb
Public connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\BaseDatos\VentasDB.accdb"
```

Para usar una ruta diferente:

```vb
Public connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\MiRuta\VentasDB.accdb"
```

## 🔐 Mejorar Seguridad de Contraseñas

### Implementar Hash SHA256

```vb
Imports System.Security.Cryptography
Imports System.Text

Public Function EncriptarContraseña(contrasena As String) As String
    Using sha256 = SHA256.Create()
        Dim hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contrasena))
        Return Convert.ToBase64String(hashedBytes)
    End Using
End Function
```

## 📊 Agregar Reportes

### Crear un nuevo formulario frmReportes

```vb
Public Class frmReportes
    Private Sub btnVentasPorFecha_Click(sender As Object, e As EventArgs)
        Dim fechaInicio = dtpFechaInicio.Value
        Dim fechaFin = dtpFechaFin.Value
        Dim tabla = ObtenerVentasPorFecha(fechaInicio, fechaFin)
        dgvReporte.DataSource = tabla
    End Sub
End Class
```

## 🎨 Personalizar Estilos

### Cambiar tema de la aplicación

En `Application Events.vb`:

```vb
Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
    ' Configurar estilo visual
    Application.EnableVisualStyles()
    Application.SetHighDpiMode(HighDpiMode.SystemAware)
End Sub
```

## 🔄 Agregar Más Roles

### En la tabla Usuarios, agregar nuevo rol:

```sql
INSERT INTO Usuarios VALUES ('gerente', 'gerente123', 'Gerente', TRUE);
```

### En frmLogin, agregar nuevo menú:

```vb
Case "Gerente"
    frmMenuGerente.Show()
```

## 📱 Agregar Más Funcionalidades

### Devoluciones de Productos

```vb
Public Module ModuloDevoluciones
    Public Function RegistrarDevolucion(idVenta As Integer, cantidad As Integer) As Boolean
        ' Código para registrar devolución
        ' Aumentar stock del producto
        ' Crear registro en tabla Devoluciones
    End Function
End Module
```

## 🧪 Testing

### Crear formulario de pruebas

```vb
Public Class frmPruebas
    Private Sub btnPruebaConexion_Click(sender As Object, e As EventArgs)
        Dim conexion = ObtenerConexion()
        If conexion IsNot Nothing Then
            MsgBox("Conexión exitosa", MsgBoxStyle.Information)
            conexion.Close()
        End If
    End Sub
End Class
```

## 🚀 Compilar como Ejecutable

1. En Visual Studio: **Build > Publish**
2. Configura la carpeta de publicación
3. Se generará un archivo `.exe` que puedes distribuir
4. Incluye la carpeta `BaseDatos` junto con el ejecutable

## 📝 Control de Versiones

### Estructura de commits recomendada

```bash
git commit -m "feat: Agregar nueva funcionalidad"
git commit -m "fix: Corregir error en validación"
git commit -m "docs: Actualizar documentación"
git commit -m "refactor: Mejorar código existente"
```

## 🐛 Debugging

### Activar modo Debug

En Visual Studio:
1. **Debug > Windows > Output**
2. Agrega Console.WriteLine() en el código para ver mensajes

### Puntos de Quiebre

1. Haz clic en el margen izquierdo de una línea
2. Presiona **F5** para iniciar en modo Debug
3. El programa se pausará en ese punto

## 📈 Optimizaciones

### Cachear datos para mejor rendimiento

```vb
Private productosCache As DataTable = Nothing

Public Function ObtenerProductosOptimizado() As DataTable
    If productosCache Is Nothing Then
        productosCache = ObtenerProductos()
    End If
    Return productosCache
End Function
```

### Usar PreparedStatements para seguridad

```vb
Public Function RegistrarVentaSegura(idProducto As Integer, cantidad As Integer) As Boolean
    Dim conexion = ObtenerConexion()
    Dim comando = New OleDbCommand("INSERT INTO Ventas VALUES(?,?,?,?,?)", conexion)
    
    comando.Parameters.AddWithValue("@idProducto", idProducto)
    comando.Parameters.AddWithValue("@cantidad", cantidad)
    comando.Parameters.AddWithValue("@fecha", Now())
    comando.Parameters.AddWithValue("@usuario", usuarioActual)
    comando.Parameters.AddWithValue("@total", precioTotal)
    
    comando.ExecuteNonQuery()
    conexion.Close()
    Return True
End Function
```

## 🔗 Recursos útiles

- [Documentación de Visual Basic .NET](https://docs.microsoft.com/en-us/dotnet/visual-basic/)
- [Tutorial de ADO.NET](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/)
- [Seguridad en aplicaciones .NET](https://owasp.org/www-project-web-security-testing-guide/)

