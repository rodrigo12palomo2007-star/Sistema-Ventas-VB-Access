Public Class frmConsultas
    Private Sub frmConsultas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Consultas de Productos"
        Me.StartPosition = FormStartPosition.CenterScreen
        CargarProductos()
        dgvProductos.ReadOnly = True
    End Sub
    
    Private Sub CargarProductos()
        Try
            Dim tabla As DataTable = ObtenerProductos()
            If tabla IsNot Nothing Then
                dgvProductos.DataSource = tabla
                AjustarColumnas()
            End If
        Catch ex As Exception
            MsgBox("Error al cargar productos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    
    Private Sub AjustarColumnas()
        dgvProductos.Columns(0).HeaderText = "ID"
        dgvProductos.Columns(0).Width = 40
        dgvProductos.Columns(1).HeaderText = "Nombre"
        dgvProductos.Columns(1).Width = 150
        dgvProductos.Columns(2).HeaderText = "Precio"
        dgvProductos.Columns(2).Width = 80
        dgvProductos.Columns(3).HeaderText = "Stock"
        dgvProductos.Columns(3).Width = 80
        dgvProductos.Columns(4).HeaderText = "Descripción"
        dgvProductos.Columns(4).Width = 200
    End Sub
    
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim nombre As String = txtBuscar.Text
            If String.IsNullOrWhiteSpace(nombre) Then
                CargarProductos()
            Else
                Dim tabla As DataTable = BuscarProductos(nombre)
                If tabla IsNot Nothing Then
                    dgvProductos.DataSource = tabla
                    AjustarColumnas()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtBuscar.Clear()
        CargarProductos()
    End Sub
    
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    
    Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim nombre As String = dgvProductos.Rows(e.RowIndex).Cells(1).Value.ToString()
            Dim precio As String = dgvProductos.Rows(e.RowIndex).Cells(2).Value.ToString()
            Dim stock As String = dgvProductos.Rows(e.RowIndex).Cells(3).Value.ToString()
            
            MsgBox("Producto: " & nombre & vbCrLf & _
                   "Precio: $" & precio & vbCrLf & _
                   "Stock disponible: " & stock, _
                   MsgBoxStyle.Information, "Detalles del Producto")
        End If
    End Sub
End Class
