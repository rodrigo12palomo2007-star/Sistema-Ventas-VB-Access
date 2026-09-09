Imports System.Data.OleDb

Public Module ModuloConexion
    ' Ruta de la base de datos Access
    Public connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\BaseDatos\VentasDB.accdb"
    
    ' Variable global para el usuario actual
    Public usuarioActual As String = ""
    Public rolActual As String = ""
    
    ''' <summary>
    ''' Obtiene una conexión a la base de datos
    ''' </summary>
    Public Function ObtenerConexion() As OleDbConnection
        Try
            Dim conexion As New OleDbConnection(connectionString)
            conexion.Open()
            Return conexion
        Catch ex As Exception
            MsgBox("Error al conectar a la base de datos: " & ex.Message, MsgBoxStyle.Critical, "Error de Conexión")
            Return Nothing
        End Try
    End Function
    
    ''' <summary>
    ''' Ejecuta una consulta SELECT y retorna un DataTable
    ''' </summary>
    Public Function EjecutarConsulta(sql As String) As DataTable
        Try
            Dim conexion As OleDbConnection = ObtenerConexion()
            If conexion Is Nothing Then Return Nothing
            
            Dim comando As New OleDbCommand(sql, conexion)
            Dim adaptador As New OleDbDataAdapter(comando)
            Dim tabla As New DataTable()
            adaptador.Fill(tabla)
            conexion.Close()
            Return tabla
        Catch ex As Exception
            MsgBox("Error en la consulta: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function
    
    ''' <summary>
    ''' Ejecuta un comando INSERT, UPDATE o DELETE
    ''' </summary>
    Public Function EjecutarComando(sql As String) As Boolean
        Try
            Dim conexion As OleDbConnection = ObtenerConexion()
            If conexion Is Nothing Then Return False
            
            Dim comando As New OleDbCommand(sql, conexion)
            comando.ExecuteNonQuery()
            conexion.Close()
            Return True
        Catch ex As Exception
            MsgBox("Error al ejecutar comando: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Valida que una cadena no esté vacía
    ''' </summary>
    Public Function ValidarCampo(campo As String, nombreCampo As String) As Boolean
        If String.IsNullOrWhiteSpace(campo) Then
            MsgBox("El campo " & nombreCampo & " no puede estar vacío.", MsgBoxStyle.Exclamation, "Validación")
            Return False
        End If
        Return True
    End Function
    
    ''' <summary>
    ''' Valida que un número sea válido
    ''' </summary>
    Public Function ValidarNumero(valor As String, nombreCampo As String) As Boolean
        If Not IsNumeric(valor) Then
            MsgBox("El campo " & nombreCampo & " debe contener un número válido.", MsgBoxStyle.Exclamation, "Validación")
            Return False
        End If
        Return True
    End Function
    
    ''' <summary>
    ''' Encripta una contraseña básicamente (para producción usar algoritmos más seguros)
    ''' </summary>
    Public Function EncriptarContrasena(contrasena As String) As String
        ' Esta es una encriptación muy básica. En producción usar métodos más seguros
        Dim bytes As Byte() = Text.Encoding.UTF8.GetBytes(contrasena)
        Return Convert.ToBase64String(bytes)
    End Function
    
    ''' <summary>
    ''' Desencripta una contraseña
    ''' </summary>
    Public Function DesencriptarContrasena(contrasena As String) As String
        Try
            Dim bytes As Byte() = Convert.FromBase64String(contrasena)
            Return Text.Encoding.UTF8.GetString(bytes)
        Catch
            Return contrasena
        End Try
    End Function
End Module
