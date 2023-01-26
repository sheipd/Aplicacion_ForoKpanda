<%@ Page Title="" Language="VB" MasterPageFile="~/basica.master" AutoEventWireup="false" CodeFile="activate.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
     <div>
         <asp:SqlDataSource ID="sqlDsActivar" runat="server" ConnectionString="<%$ ConnectionStrings:oretubeCnx %>" 
             UpdateCommand="UPDATE [Usuario] SET activado=1 WHERE [id] = @id">
            <UpdateParameters>
                <asp:Parameter Name="id" dbType="Guid" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="barra" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="endContenido" Runat="Server">
</asp:Content>

