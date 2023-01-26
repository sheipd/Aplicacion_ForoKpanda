Public Class Codigo
    Public Shared Sub Salir()
        ' Se ejecuta al hacer clic sobre los botones "Cerrar Sesión" en las distintas páginas.

        ' Se elimina el tique de validación.
        FormsAuthentication.SignOut()
        ' Se cancela la sesión actual.
        HttpContext.Current.Session.Clear()
        HttpContext.Current.Session.Abandon()

        ' A la página que contiene el formulario de inicio de sesión.
        ' HttpContext.Current.Response.Redirect("~/login.aspx")
        FormsAuthentication.RedirectToLoginPage()
    End Sub

End Class
