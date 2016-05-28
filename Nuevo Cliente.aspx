<%@ Page Title="Cajero" Language="C#" AutoEventWireup="true" CodeFile="Nuevo Cliente.aspx.cs" Inherits="Nuevo_Cliente" %>

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

        Codigo:<br/>
        <asp:TextBox ID="txtCodigo" runat="server" /> <br/>
        Nombre:<br/>
        <asp:TextBox ID="txtNombre" runat="server" /> <br/>
        Nit:<br/>  
        <asp:TextBox ID="txtNit" runat="server" /> <br/>
         Dirección:<br/>  
        <asp:TextBox ID="txtDireccion" runat="server" /> <br/>
         Telefono:<br/>  
        <asp:TextBox ID="txtTelefono" runat="server" /> <br/>
         Correo:<br/>  
        <asp:TextBox ID="txtCorreo" runat="server" /> <br/>

        <asp:Button ID="cmdGuardar" Text="Grabar" runat="server" onclick="cmdGuardar_Click"/>

    </div>
    </form>
</body>
</html>
