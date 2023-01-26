' Esta página es llamada con la URL de activación que se le envía por correo al usuario después de su registro 
' y tiene como objetivo activar su acceso a la aplicación.
'
' El aspecto de la URL es similiar a:
'    http://localhost/contenidos/anonimo/activate.aspx?uk=J6ktqOHUPaXWopIbmbeKIna+f/Z6S5p8dCm5NhipzzOteD3ubKytDA==
'
' Que se corresponde con un idUsuario:

' 5EA1B54F-92D4-4208-BFF6-D4307C147AB8
'
'
' El parámetro uk es el valor cifrado de la columna idUsuario asignado durante su registro.
'
' Si la activación se realiza correctamente, la columna activado de la fila correspondiente al usuario se carga con true.
Partial Class _Default
    Inherits System.Web.UI.Page

    Dim idUsuario As New Guid
    Private Sub sqlDsActivar_Load(sender As Object, e As EventArgs) Handles sqlDsActivar.Load
        ' La página solo debe ser accesible a traves de la URL original. 
        If String.IsNullOrWhiteSpace(Request.QueryString("uk")) Then
            'La URL no tiene uk.
            AvisoError()
        Else
            Dim _key As New seguridadDLL.Seguridad
            Dim k As String = _key.DesencriptarVB(Request.QueryString("uk"), "t#$b5r?9")

            If Guid.TryParse(k, idUsuario) Then ' Se genera el idUsuario a partir del valor de k recuperado
                ' La URL tiene uk y presenta el formato adecuado.
                sqlDsActivar.Update()
            Else
                ' La URL tiene uk pero está corrupto.
                AvisoError()
            End If
        End If
    End Sub

    Private Sub sqlDsActivar_Updating(sender As Object, e As SqlDataSourceCommandEventArgs) Handles sqlDsActivar.Updating
        e.Command.Parameters("@idusuario").Value = idUsuario
    End Sub

    Private Sub _activate_Error(sender As Object, e As EventArgs) Handles Me.[Error]
        Server.ClearError()
        Response.Redirect("~/contenidos/anonimo/errores.aspx")
    End Sub

    Private Sub AvisoError()
        Dim script As String = "$(document).ready(function() {$('<div title=\'ACTIVACIÓN REGISTRO\'><p>¡ERROR! No ha sido posible la activación. Inténtelo más tarde.</p></div>').dialog({autoOpen:true,resizable:false,height:'auto',width:'auto', modal:true,closeOnEscape:false,draggable:false,open:function(event, ui) {$('.ui-dialog-titlebar-close', ui.dialog | ui).hide();},buttons: {'Salir': function () {location.href = '../../login.aspx';}} });});"

        Dim cs As ClientScriptManager = Page.ClientScript
        cs.RegisterStartupScript(Me.GetType(), "aviso", script, True)
    End Sub


    ' QUEDA PENDIENTE UD06... 
    ' DETECTAR QUE HA SIDO POSIBLE LA ACTIVACIÓN, RECUPERAR DATOS DEL USUARIO E INICIAR SESIÓN.

End Class
