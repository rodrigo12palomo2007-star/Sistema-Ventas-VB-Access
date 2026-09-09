Public Class frmProductos
    Private Sub frmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gestión de Productos"
        Me.StartPosition = FormStartPosition.CenterScreen
        CargarProductos()
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
    
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarCampos()
        txtNombre.Focus()
    End Sub
    
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If Not ValidarCampos() Then Return
            
            Dim nombre As String = txtNombre.Text
            Dim precio As Decimal = CDec(txtPrecio.Text)
            Dim stock As Integer = CInt(txtStock.Text)
            Dim descripcion As String = txtDescripcion.Text
            
            If InsertarProducto(nombre, precio, stock, descripcion) Then
                MsgBox("Producto guardado exitosamente.", MsgBoxStyle.Information, "Éxito")
                LimpiarCampos()
                CargarProductos()
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If dgvProductos.SelectedRows.Count = 0 Then
                MsgBox("Seleccione un producto para editar.", MsgBoxStyle.Exclamation, "Selección")
                Return
            End If
            
            Dim idProducto As Integer = CInt(dgvProductos.SelectedRows(0).Cells(0).Value)
            Dim nombre As String = dgvProductos.SelectedRows(0).Cells(1).Value.ToString()
            Dim precio As Decimal = CDec(dgvProductos.SelectedRows(0).Cells(2).Value)
            Dim stock As Integer = CInt(dgvProductos.SelectedRows(0).Cells(3).Value)
            Dim descripcion As String = dgvProductos.SelectedRows(0).Cells(4).Value.ToString()
            
            txtNombre.Text = nombre
            txtPrecio.Text = precio.ToString()
            txtStock.Text = stock.ToString()
            txtDescripcion.Text = descripcion
            
            btnGuardar.Text = "Actualizar"
            btnGuardar.Tag = idProducto
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvProductos.SelectedRows.Count = 0 Then
                MsgBox("Seleccione un producto para eliminar.", MsgBoxStyle.Exclamation, "Selección")
                Return
            End If
            
            Dim idProducto As Integer = CInt(dgvProductos.SelectedRows(0).Cells(0).Value)
            If EliminarProducto(idProducto) Then
                MsgBox("Producto eliminado exitosamente.", MsgBoxStyle.Information, "Éxito")
                CargarProductos()
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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
        LimpiarCampos()
        txtBuscar.Clear()
        CargarProductos()
        btnGuardar.Text = "Guardar"
        btnGuardar.Tag = Nothing
    End Sub
    
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    
    Private Sub LimpiarCampos()
        txtNombre.Clear()
        txtPrecio.Clear()
        txtStock.Clear()
        txtDescripcion.Clear()
        btnGuardar.Text = "Guardar"
        btnGuardar.Tag = Nothing
    End Sub
    
    Private Function ValidarCampos() As Boolean
        If Not ValidarCampo(txtNombre.Text, "Nombre") Then Return False
        If Not ValidarCampo(txtPrecio.Text, "Precio") Then Return False
        If Not ValidarCampo(txtStock.Text, "Stock") Then Return False
        If Not ValidarNumero(txtPrecio.Text, "Precio") Then Return False
        If Not ValidarNumero(txtStock.Text, "Stock") Then Return False
        Return True
    End Function
    
    Private Sub dgvProductos_DoubleClick(sender As Object, e As EventArgs) Handles dgvProductos.DoubleClick
        btnEditar.PerformClick()
    End Sub
End Class
