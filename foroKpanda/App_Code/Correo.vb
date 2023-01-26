Imports System.Net.Mail
Public Class Correo

    Public Shared Function EnviarEmail(ByVal o_email As String, ByVal asunto As String, ByVal texto As String) As Boolean
        Dim ok As Boolean = False
        Dim origen As MailAddress = New MailAddress("2daw@iesoretania.es", "OreTube") ' La cuenta de correo no tiene que ser la misma que es utilizada en el cliente SMTP.
        Dim destino As MailAddress = New MailAddress(o_email)

        Dim email As New MailMessage(origen, destino)
        email.Subject = asunto
        email.Body = texto
        Try
            Dim clienteSMTP As SmtpClient = New SmtpClient("smtp.gmail.com")
            ' Las credenciales del servidor de correo están almacenadas en la sección appSettings del Web.config
            clienteSMTP.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings("emailServiceUserName"), ConfigurationManager.AppSettings("emailServicePassword"))
            clienteSMTP.Port = 587
            clienteSMTP.EnableSsl = True
            'clienteSMTP.Send(email)
            ok = True
        Catch ex As Exception
            HttpContext.Current.Server.ClearError()
        End Try
        Return ok
    End Function

End Class
