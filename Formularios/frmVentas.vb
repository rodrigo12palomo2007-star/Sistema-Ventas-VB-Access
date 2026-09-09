Public Class frmVentas
    Private Sub frmVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Registro de Ventas"
        Me.StartPosition = FormStartPosition.CenterScreen
        CargarProductos()
        CargarVentas()
    End Sub
    
    Private Sub CargarProductos()
        Try
            Dim tabla As DataTable = ObtenerProductosDisponibles()
            If tabla IsNot Nothing Then
                cmbProducto.DataSource = tabla
                cmbProducto.DisplayMember = "nombre"
                cmbProducto.ValueMember = "idProducto"
            End If
        Catch ex As Exception
            MsgBox("Error al cargar productos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    
    Private Sub CargarVentas()
        Try
            Dim tabla As DataTable = ObtenerVentas()
            If tabla IsNot Nothing Then
                dgvVentas.DataSource = tabla
                AjustarColumnas()
            End If
        Catch ex As Exception
            MsgBox("Error al cargar ventas: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    
    Private Sub AjustarColumnas()
        dgvVentas.Columns(0).HeaderText = "ID Venta"
        dgvVentas.Columns(0).Width = 50
        dgvVentas.Columns(1).HeaderText = "ID Producto"
        dgvVentas.Columns(1).Width = 70
        dgvVentas.Columns(2).HeaderText = "Producto"
        dgvVentas.Columns(2).Width = 150
        dgvVentas.Columns(3).HeaderText = "Cantidad"
        dgvVentas.Columns(3).Width = 70
        dgvVentas.Columns(4).HeaderText = "Fecha"
        dgvVentas.Columns(4).Width = 120
        dgvVentas.Columns(5).HeaderText = "Usuario"
        dgvVentas.Columns(5).Width = 100
        dgvVentas.Columns(6).HeaderText = "Total"
        dgvVentas.Columns(6).Width = 80
    End Sub
    
    Private Sub btnRegistrarVenta_Click(sender As Object, e As EventArgs) Handles btnRegistrarVenta.Click
        Try
            If cmbProducto.SelectedValue Is Nothing Then
                MsgBox("Seleccione un producto.", MsgBoxStyle.Exclamation, "Validación")
                Return
            End If
            
            If Not ValidarCampo(txtCantidad.Text, "Cantidad") Then Return
            If Not ValidarNumero(txtCantidad.Text, "Cantidad") Then Return
            
            Dim idProducto As Integer = CInt(cmbProducto.SelectedValue)
            Dim cantidad As Integer = CInt(txtCantidad.Text)
            
            If RegistrarVenta(idProducto, cantidad) Then
                MsgBox("Venta registrada exitosamente.", MsgBoxStyle.Information, "Éxito")
                txtCantidad.Clear()
                CargarProductos()
                CargarVentas()
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    
    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        CargarVentas()
    End Sub
    
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    
    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        Try
            If cmbProducto.SelectedValue IsNot Nothing Then
                Dim idProducto As Integer = CInt(cmbProducto.SelectedValue)
                Dim tabla As DataTable = ObtenerProductoPorId(idProducto)
                If tabla.Rows.Count > 0 Then
                    Dim precio As Decimal = CDec(tabla.Rows(0)("precio"))
                    Dim stock As Integer = CInt(tabla.Rows(0)("stock"))
                    lblPrecio.Text = "Precio: $" & precio.ToString("0.00")
                    lblStock.Text = "Stock disponible: " & stock.ToString()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
