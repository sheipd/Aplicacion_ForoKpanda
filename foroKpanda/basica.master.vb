
Partial Class _Basica
    Inherits System.Web.UI.MasterPage


    Public ReadOnly Property miMenu As Menu
        Get
            Return menuNav
        End Get
    End Property

    Private Sub menuNav_MenuItemClick(sender As Object, e As MenuEventArgs) Handles menuNav.MenuItemClick
        If e.Item.Value = "salir" Then
            Codigo.Salir()
        End If
    End Sub

End Class

