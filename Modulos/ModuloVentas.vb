Imports System.Data.OleDb

Public Module ModuloVentas
    
    ''' <summary>
    ''' Obtiene todas las ventas
    ''' </summary>
    Public Function ObtenerVentas() As DataTable
        Try
            Dim sql As String = "SELECT v.idVenta, v.idProducto, p.nombre, v.cantidad, v.fecha, v.usuario, v.total " & _
                              "FROM Ventas v INNER JOIN Productos p ON v.idProducto = p.idProducto " & _
                              "ORDER BY v.fecha DESC"
            Return EjecutarConsulta(sql)
        Catch ex As Exception
            MsgBox("Error al obtener ventas: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function
    
    ''' <summary>
    ''' Registra una nueva venta
    ''' </summary>
    Public Function RegistrarVenta(idProducto As Integer, cantidad As Integer) As Boolean
        Try
            If Not ValidarNumero(idProducto.ToString(), "Producto") Then Return False
            If Not ValidarNumero(cantidad.ToString(), "Cantidad") Then Return False
            If cantidad <= 0 Then
                MsgBox("La cantidad debe ser mayor a 0.", MsgBoxStyle.Exclamation, "Validación")
                Return False
            End If
            
            ' Obtener el producto
            Dim sqlProducto As String = "SELECT precio, stock FROM Productos WHERE idProducto = " & idProducto
            Dim tablaProducto As DataTable = EjecutarConsulta(sqlProducto)
            
            If tablaProducto.Rows.Count = 0 Then
                MsgBox("El producto no existe.", MsgBoxStyle.Exclamation, "Error")
                Return False
            End If
            
            Dim precio As Decimal = CDec(tablaProducto.Rows(0)("precio"))
            Dim stockActual As Integer = CInt(tablaProducto.Rows(0)("stock"))
            
            If cantidad > stockActual Then
                MsgBox("No hay suficiente stock. Stock disponible: " & stockActual, MsgBoxStyle.Exclamation, "Error")
                Return False
            End If
            
            Dim total As Decimal = precio * cantidad
            
            ' Registrar venta
            Dim sqlVenta As String = "INSERT INTO Ventas (idProducto, cantidad, fecha, usuario, total) " & _
                                   "VALUES (" & idProducto & ", " & cantidad & ", NOW(), '" & usuarioActual & "', " & total & ")"
            
            If Not EjecutarComando(sqlVenta) Then Return False
            
            ' Actualizar stock
            Dim nuevoStock As Integer = stockActual - cantidad
            Dim sqlActualizar As String = "UPDATE Productos SET stock = " & nuevoStock & " WHERE idProducto = " & idProducto
            
            Return EjecutarComando(sqlActualizar)
        Catch ex As Exception
            MsgBox("Error al registrar venta: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene ventas por rango de fechas
    ''' </summary>
    Public Function ObtenerVentasPorFecha(fechaInicio As Date, fechaFin As Date) As DataTable
        Try
            Dim sql As String = "SELECT v.idVenta, v.idProducto, p.nombre, v.cantidad, v.fecha, v.usuario, v.total " & _
                              "FROM Ventas v INNER JOIN Productos p ON v.idProducto = p.idProducto " & _
                              "WHERE v.fecha BETWEEN #" & fechaInicio.ToString("MM/dd/yyyy") & "# AND #" & fechaFin.ToString("MM/dd/yyyy") & "# " & _
                              "ORDER BY v.fecha DESC"
            Return EjecutarConsulta(sql)
        Catch ex As Exception
            MsgBox("Error al obtener ventas: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene ventas por usuario
    ''' </summary>
    Public Function ObtenerVentasPorUsuario(usuario As String) As DataTable
        Try
            Dim sql As String = "SELECT v.idVenta, v.idProducto, p.nombre, v.cantidad, v.fecha, v.usuario, v.total " & _
                              "FROM Ventas v INNER JOIN Productos p ON v.idProducto = p.idProducto " & _
                              "WHERE v.usuario = '" & usuario & "' " & _
                              "ORDER BY v.fecha DESC"
            Return EjecutarConsulta(sql)
        Catch ex As Exception
            MsgBox("Error al obtener ventas: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function
    
    ''' <summary>
    ''' Calcula el total de ventas
    ''' </summary>
    Public Function ObtenerTotalVentas() As Decimal
        Try
            Dim sql As String = "SELECT SUM(total) as totalVentas FROM Ventas"
            Dim tabla As DataTable = EjecutarConsulta(sql)
            
            If tabla.Rows.Count > 0 And Not IsDBNull(tabla.Rows(0)("totalVentas")) Then
                Return CDec(tabla.Rows(0)("totalVentas"))
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox("Error al calcular total: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return 0
        End Try
    End Function
    
    ''' <summary>
    ''' Elimina una venta (solo para administrador)
    ''' </summary>
    Public Function EliminarVenta(idVenta As Integer) As Boolean
        Try
            If rolActual <> "Jefe" Then
                MsgBox("No tiene permisos para eliminar ventas.", MsgBoxStyle.Exclamation, "Acceso Denegado")
                Return False
            End If
            
            If MsgBox("¿Está seguro de que desea eliminar esta venta?", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then
                Return False
            End If
            
            Dim sql As String = "DELETE FROM Ventas WHERE idVenta = " & idVenta
            Return EjecutarComando(sql)
        Catch ex As Exception
            MsgBox("Error al eliminar venta: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function
End Module
