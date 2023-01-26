Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim idUsuario As Object

    Private Sub _Default_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Request.IsAuthenticated Then ' Se recibe la cookie de validación permanente, previamente almacenada en el cliente.
            Response.Redirect("~/contenidos/Default.aspx")
        End If
    End Sub

    Private Sub _register_Load(sender As Object, e As EventArgs) Handles Me.Load
        fvRegistro.ChangeMode(FormViewMode.Insert)
    End Sub

    Private Sub sqlDSregistro_Deleting(sender As Object, e As SqlDataSourceCommandEventArgs) Handles sqlDsRegistro.Deleting
        e.Command.Parameters("@id").Value = New Guid(idUsuario.ToString)
    End Sub

    ' Observar el marcado. El parámetro k (Direction="output") es añadido para recuperar el id del usuario asignado por el SGBD
    ' tras la inserción y que es devuelto por el SP. Valor del id de usuario que es utilizado para montar la url de activación.
    Private Sub sqlDSregistro_Inserted(sender As Object, e As SqlDataSourceStatusEventArgs) Handles sqlDsRegistro.Inserted
        If (e.Exception Is Nothing) Then
            ' Si el valor clave asignado a id usuario es distinto de cero, se lanza el correo de confirmación.
            ' Recuperamos el valor del parámetro de salida K
            idUsuario = e.Command.Parameters("@k").Value
            ' Recuperamos la dirección de correo del usuario.
            Dim email = e.Command.Parameters("@email").Value
            If Not DBNull.Value.Equals(idUsuario) Then
                Dim _key As New seguridadDLL.Seguridad
                If Correo.EnviarEmail(email, "Confirmación del registro de usuario", "http://localhost/contenidos/anonimo/activate.aspx?uk=" & _key.EncriptarVB(idUsuario.ToString, "t#$b5r?9")) Then
                    AvisoCorreo()
                Else
                    ' No se ha podido enviar el correo. Borrar el registro insertado y avisar del error.
                    sqlDsRegistro.Delete()
                    AvisoError()
                End If
            Else
                AvisoError()
            End If
        Else
            AvisoError()
        End If
    End Sub

    ' Método Web para comprobar, a través de AJAX, que el login de usuario está libre.
    <System.Web.Services.WebMethod>
    Public Shared Function EstaLibre(ByVal login As String) As Boolean
        Dim ok = True
        Dim conexion As String = "Data Source=(local);Initial Catalog=oretube;Integrated security=SSPI;"
        Dim sentencia As String = "select login from Usuario where login=@login"
        Dim miCnx As New SqlConnection(conexion)
        Dim miCmd As New SqlCommand(sentencia, miCnx)
        miCmd.Parameters.AddWithValue("@login", login)
        Try
            miCnx.Open()
            Dim respuesta = miCmd.ExecuteScalar()
            If Not String.IsNullOrWhiteSpace(respuesta) Then Ok = False
        Catch
        Finally
            miCnx.Close()
        End Try
        Return ok
    End Function

    ' Tratamiento genérico de errores. Generalmente asociados al acceso a la BBDD
    Private Sub _register_Error(sender As Object, e As EventArgs) Handles Me.[Error]
        Server.ClearError()
        Response.Redirect("~/contenidos/anonimo/errores.aspx")
    End Sub

    ' Permite ir hacia atrás o reintentar la inserción
    Private Sub AvisoError()
        Dim script As String = "$(document).ready(function() {$('<div title=\'REGISTRO\'><p>¡ERROR! No ha sido posible el registro.</p><p>Revise su login o dirección de correo, puede que ya existan en nuestra base de datos.</p></div>').dialog({autoOpen:true,resizable:false,height:'auto',width:350, modal:true,closeOnEscape:false,draggable:false,open:function(event, ui) {$('.ui-dialog-titlebar-close', ui.dialog | ui).hide();},buttons: {'Intentar de nuevo': function () {parent.history.back();return false;},'Salir': function () {location.href = '../../login.aspx';}} });});"

        Dim cs As ClientScriptManager = Page.ClientScript
        cs.RegisterStartupScript(Me.GetType(), "aviso", script, True)
    End Sub

    ' Continuar
    Private Sub AvisoCorreo()
        Dim script As String = "$(document).ready(function() {$('<div title=\'REGISTRO\'><p>¡OK! Se le ha enviado un correo de activación. Haga clic en el enlace que aparece en el texto para activar su acceso.</p></div>').dialog({autoOpen:true,resizable:false,height:'auto',width:350, modal:true,closeOnEscape:false,draggable:false,open:function(event, ui) {$('.ui-dialog-titlebar-close', ui.dialog | ui).hide();},buttons: {'Continuar': function () {location.href = '../../login.aspx';}} });});"

        Dim cs As ClientScriptManager = Page.ClientScript
        cs.RegisterStartupScript(Me.GetType(), "aviso", script, True)
    End Sub


End Class
