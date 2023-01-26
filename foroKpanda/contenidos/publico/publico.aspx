<%@ Page Title="" Language="VB" MasterPageFile="~/basica.master" AutoEventWireup="false" CodeFile="publico.aspx.vb" Inherits="_Default" %>
<%@ MasterType VirtualPath="~/basica.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="id" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <asp:ImageButton ID="imgArticulo" runat="server" ImageUrl='<%# Eval("imagen") %>' Width="300px" height="300px" PostBackUrl="~/contenidos/publico/articulo.aspx?pasaridArticulo=<%# Eval("id") %>" />
            <br />
            <br />
            <asp:Label ID="nombreLabel" runat="server" Text='<%# Bind("nombre") %>' style="font-weight: bold;"/>
            <br />
            Descripción:
            <asp:Label ID="descripcionLabel" runat="server" Text='<%# Bind("descripcion") %>' />
            <br />
            Fecha de publicación del artículo:
            <asp:Label ID="fechaLabel" runat="server" Text='<%# Bind("fecha") %>' />
            <br /><br /><br /><br />
        </ItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:foroCnx %>" SelectCommand="SELECT * FROM [articulo]"></asp:SqlDataSource>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="barra" Runat="Server">
    MENÚ LATERAL
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="endContenido" Runat="Server">
    ZONA FINAL 
</asp:Content>

