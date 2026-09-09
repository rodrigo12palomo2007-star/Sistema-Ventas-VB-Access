Imports System.Data.OleDb

Public Module ModuloUsuarios
    
    ''' <summary>
    ''' Valida el login del usuario
    ''' </summary>
    Public Function ValidarLogin(usuario As String, contrasena As String) As Boolean
        Try
            If Not ValidarCampo(usuario, "Usuario") Then Return False
            If Not ValidarCampo(contrasena, "Contraseña") Then Return False
            
            Dim sql As String = "SELECT * FROM Usuarios WHERE usuario = '" & usuario & "' AND contraseña = '" & contrasena & "' AND estado = TRUE"
            Dim tabla As DataTable = EjecutarConsulta(sql)
            
            If tabla.Rows.Count > 0 Then
                usuarioActual = usuario
                rolActual = tabla.Rows(0)("rol").ToString()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Error al validar login: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene el rol del usuario actual
    ''' </summary>
    Public Function ObtenerRolUsuario(usuario As String) As String
        Try
            Dim sql As String = "SELECT rol FROM Usuarios WHERE usuario = '" & usuario & "'"
            Dim tabla As DataTable = EjecutarConsulta(sql)
            
            If tabla.Rows.Count > 0 Then
                Return tabla.Rows(0)("rol").ToString()
            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox("Error al obtener rol: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return ""
        End Try
    End Function
    
    ''' <summary>
    ''' Cambia la contraseña de un usuario
    ''' </summary>
    Public Function CambiarContrasena(usuario As String, nuevaContrasena As String) As Boolean
        Try
            If Not ValidarCampo(nuevaContrasena, "Nueva contraseña") Then Return False
            
            Dim sql As String = "UPDATE Usuarios SET contraseña = '" & nuevaContrasena & "' WHERE usuario = '" & usuario & "'"
            Return EjecutarComando(sql)
        Catch ex As Exception
            MsgBox("Error al cambiar contraseña: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene la lista de todos los usuarios
    ''' </summary>
    Public Function ObtenerUsuarios() As DataTable
        Try
            Dim sql As String = "SELECT idUsuario, usuario, rol, estado FROM Usuarios ORDER BY usuario"
            Return EjecutarConsulta(sql)
        Catch ex As Exception
            MsgBox("Error al obtener usuarios: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function
End Module
