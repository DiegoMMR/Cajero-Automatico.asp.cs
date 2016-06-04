<%@ Page Title="Cajero" Language="C#" AutoEventWireup="true" CodeFile="Nueva Tarjeta.aspx.cs" Inherits="Nueva_Tarjeta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <style type="text/css">
	body
	{
		background: black;
		color: white;
		font: 150% arial;
		text-align: center;
	}	
	</style>
</head>

<body>
    <form id="form1" runat="server">
    <div>

        Numero de Tarjeta:<br/>
        <asp:TextBox ID="txtTarjeta" runat="server" /> <asp:Button ID="GenerarNumero" Text="Generar" runat="server" onclick="Generar_Click"/>  <br/>
        Codigo de Cliente<br/>
        <asp:TextBox ID="txtCodCliente" runat="server" /> <br/>
        Estado:<br/>  
        <asp:TextBox ID="txtEstado" runat="server" /> <br/>
         Limite:<br/>  
        <asp:TextBox ID="txtLimite" runat="server" /> <br/>
         Pin:<br/>  
        <asp:TextBox ID="txtPin" runat="server" /> <br/>


        <asp:Button ID="cmdGuardar" Text="Grabar" runat="server" onclick="cmdGuardar_Click"/>

    </div>
    </form>
</body>
</html>
