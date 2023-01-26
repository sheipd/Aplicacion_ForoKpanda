
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected WithEvents miMaster As _Basica

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        miMaster = Master

        ' Creación del menú de la maestra para esta página
        miMaster.miMenu.Items.Clear() ' Limpiamos el existente

        Dim opcion As New MenuItem
        opcion.Text = "Cerrar sesión"
        opcion.Value = "salir"

        miMaster.miMenu.Items.AddAt(0, opcion)
    End Sub
End Class
