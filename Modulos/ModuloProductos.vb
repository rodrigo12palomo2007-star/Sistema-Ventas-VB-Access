Imports System.Data.OleDb

Public Module ModuloProductos
    
    ''' <summary>
    ''' Obtiene todos los productos
    ''' </summary>
    Public Function ObtenerProductos() As DataTable
        Try
            Dim sql As String = "SELECT idProducto, nombre, precio, stock, descripcion FROM Productos ORDER BY nombre"
            Return EjecutarConsulta(sql)
        Catch ex As Exception
            MsgBox("Error al obtener productos: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function
    
    ''' <summary>
    ''' Busca productos por nombre
    ''' </summary>
    Public Function BuscarProductos(nombre As String) As DataTable
        Try
            Dim sql As String = "SELECT idProducto, nombre, precio, stock, descripcion FROM Productos WHERE nombre LIKE '%" & nombre & "%' ORDER BY nombre"
            Return EjecutarConsulta(sql)
        Catch ex As Exception
            MsgBox("Error al buscar productos: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function
    
    ''' <summary>
    ''' Inserta un nuevo producto
    ''' </summary>
    Public Function InsertarProducto(nombre As String, precio As Decimal, stock As Integer, descripcion As String) As Boolean
        Try
            If Not ValidarCampo(nombre, "Nombre") Then Return False
            If Not ValidarNumero(precio.ToString(), "Precio") Then Return False
            If precio <= 0 Then
                MsgBox("El precio debe ser mayor a 0.", MsgBoxStyle.Exclamation, "Validación")
                Return False
            End If
            If Not ValidarNumero(stock.ToString(), "Stock") Then Return False
            
            Dim sql As String = "INSERT INTO Productos (nombre, precio, stock, descripcion, fechaCreacion) " & _
                              "VALUES ('" & nombre & "', " & precio & ", " & stock & ", '" & descripcion & "', NOW())"
            Return EjecutarComando(sql)
        Catch ex As Exception
            MsgBox("Error al insertar producto: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Actualiza un producto existente
    ''' </summary>
    Public Function ActualizarProducto(idProducto As Integer, nombre As String, precio As Decimal, stock As Integer, descripcion As String) As Boolean
        Try
            If Not ValidarCampo(nombre, "Nombre") Then Return False
            If Not ValidarNumero(precio.ToString(), "Precio") Then Return False
            If precio <= 0 Then
                MsgBox("El precio debe ser mayor a 0.", MsgBoxStyle.Exclamation, "Validación")
                Return False
            End If
            If Not ValidarNumero(stock.ToString(), "Stock") Then Return False
            
            Dim sql As String = "UPDATE Productos SET nombre = '" & nombre & "', precio = " & precio & ", stock = " & stock & ", descripcion = '" & descripcion & "' WHERE idProducto = " & idProducto
            Return EjecutarComando(sql)
        Catch ex As Exception
            MsgBox("Error al actualizar producto: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Elimina un producto
    ''' </summary>
    Public Function EliminarProducto(idProducto As Integer) As Boolean
        Try
            If MsgBox("¿Está seguro de que desea eliminar este producto?", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then
                Return False
            End If
            
            Dim sql As String = "DELETE FROM Productos WHERE idProducto = " & idProducto
            Return EjecutarComando(sql)
        Catch ex As Exception
            MsgBox("Error al eliminar producto: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene un producto por ID
    ''' </summary>
    Public Function ObtenerProductoPorId(idProducto As Integer) As DataTable
        Try
            Dim sql As String = "SELECT * FROM Productos WHERE idProducto = " & idProducto
            Return EjecutarConsulta(sql)
        Catch ex As Exception
            MsgBox("Error al obtener producto: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene productos disponibles (stock > 0)
    ''' </summary>
    Public Function ObtenerProductosDisponibles() As DataTable
        Try
            Dim sql As String = "SELECT idProducto, nombre, precio, stock FROM Productos WHERE stock > 0 ORDER BY nombre"
            Return EjecutarConsulta(sql)
        Catch ex As Exception
            MsgBox("Error al obtener productos disponibles: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function
End Module
