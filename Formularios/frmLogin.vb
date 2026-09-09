Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Sistema de Ventas - Login"
        Me.StartPosition = FormStartPosition.CenterScreen
        txtUsuario.Focus()
    End Sub
    
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim usuario As String = txtUsuario.Text
        Dim contrasena As String = txtContrasena.Text
        
        If ValidarCampo(usuario, "Usuario") AndAlso ValidarCampo(contrasena, "Contraseña") Then
            If ValidarLogin(usuario, contrasena) Then
                MsgBox("Bienvenido " & usuario & "!", MsgBoxStyle.Information, "Login Exitoso")
                AbrirMenuPrincipal()
            Else
                MsgBox("Usuario o contraseña incorrectos.", MsgBoxStyle.Critical, "Error de Autenticación")
                txtContrasena.Clear()
                txtUsuario.Focus()
            End If
        End If
    End Sub
    
    Private Sub AbrirMenuPrincipal()
        Select Case rolActual
            Case "Jefe"
                frmMenuJefe.Show()
            Case "Cliente"
                frmMenuCliente.Show()
            Case "Trabajador"
                frmMenuTrabajador.Show()
            Case Else
                MsgBox("Rol desconocido.", MsgBoxStyle.Critical, "Error")
                Return
        End Select
        Me.Hide()
    End Sub
    
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("¿Desea cerrar la aplicación?", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
            Application.Exit()
        End If
    End Sub
    
    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
            txtContrasena.Focus()
        End If
    End Sub
    
    Private Sub txtContrasena_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContrasena.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
            btnLogin.PerformClick()
        End If
    End Sub
End Class
