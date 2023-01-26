
Partial Class _Default
    Inherits System.Web.UI.Page
    Private Sub Login_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Request.IsAuthenticated Then ' Se recibe la cookie de validación permanente, previamente almacenada en el cliente.
            Response.Redirect("~/contenidos/Default.aspx")
        End If
    End Sub

    Private Sub oLogin_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles oLogin.Authenticate
        If FormsAuthentication.Authenticate(oLogin.UserName, oLogin.Password) Then
            e.Authenticated = True
        End If
    End Sub

    Private Sub Login_Error(sender As Object, e As EventArgs) Handles Me.[Error]
        Server.ClearError()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

End Class
