<%@ Page Language="VB" AutoEventWireup="false" CodeFile="errores.aspx.vb" Inherits="_Default" Debug="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../../css/jquery-ui.css" />
    <script src="../../script/js/jquery-1.8.2.js"></script>
    <script src="../../script/js/jquery-ui.js"></script>
    <script type ="text/javascript" >
        $(document).ready(function() {$('<div title=\'¡ERROR!\'><p>Servicio interrumpido temporalmente. Disculpen las molestias.</p><p>Inténtelo más tarde.</p></div>').dialog({autoOpen:true,resizable:false,height:'auto',width:350, modal:true,closeOnEscape:false,draggable:false,open:function(event, ui) {$('.ui-dialog-titlebar-close', ui.dialog | ui).hide();},buttons: {'Continuar': function () {location.href = '../../login.aspx';}} });});
    </script>
</head>
<body>
    <form id="miform" runat="server">
    <div>
    </div>
    </form>
</body>
</html>
