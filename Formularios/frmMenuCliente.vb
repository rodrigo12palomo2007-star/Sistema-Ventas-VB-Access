Public Class frmMenuCliente
    Private Sub frmMenuCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Menú Principal - Cliente"
        Me.StartPosition = FormStartPosition.CenterScreen
        lblUsuario.Text = "Usuario: " & usuarioActual
    End Sub
    
    Private Sub btnConsultas_Click(sender As Object, e As EventArgs) Handles btnConsultas.Click
        frmConsultas.Show()
    End Sub
    
    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        usuarioActual = ""
        rolActual = ""
        Me.Close()
        frmLogin.Show()
    End Sub
    
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("¿Desea cerrar la aplicación?", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class
