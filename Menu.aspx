<%@ Page Title="Cajero" Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
	 
	<title>Cajero Automatico</title>

<!--Este es el estiro de la pagina-->
	<style type="text/css">
	body
	{
		background: black;
		color: black;
		font: 150% arial;
		text-align: center;
	}	
	</style>
	
</head>

	<body>

        <form id="Menu" runat="server">

		<!--este es in div para el fondo -->
		<div id="fondo">
			<img src="img/fondo.jpg">
		</div>


		<!--en este div se le pone la posicion para que este quede sobre el fondo -->
		<div id="menu" style="position:absolute; top:36px; left:381px; visibility:visible">

			<h1>Bienvenido</h1>

			<br/> <br/>

            <asp:ImageButton id="Consultar" runat="server" ImageUrl="img/consultar.png"  onclick="Consultar_Click"/>
		    <asp:ImageButton id="Depositar" runat="server" ImageUrl="img/depositar.png"  onclick="Depositar_Click"/>
		

			<br/>

            <asp:ImageButton id="Retirar" runat="server" ImageUrl="img/retirar.png"  onclick="Retirar_Click"/>
			<asp:ImageButton id="CambioDePin" runat="server" ImageUrl="img/cambio de pin.png"  onclick="CambioDePin_Click"/>
			

			<br/> <br/>

			<img src="img/blanco.png">
            <asp:ImageButton id="Cancelar" runat="server" ImageUrl="img/cancelar.png"  onclick="Cancelar_Click"/>



		</div>
            </form>
</body>
</html>