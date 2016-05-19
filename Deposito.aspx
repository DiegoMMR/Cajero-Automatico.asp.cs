<%@ Page Title="Cajero" Language="C#" AutoEventWireup="true" CodeFile="Deposito.aspx.cs" Inherits="_Default" %>

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
        <form id="Deposito" runat="server">

		<!--este es in div para el fondo -->
		<div id="fondo">
			<img src="img/fondo.jpg">
		</div>


		<!--en este div se le pone la posicion para que este quede sobre el fondo -->
		<div id="menu-retiro" style="position:absolute; top:36px; left:381px; visibility:visible">


			<br/> <br/>

            <asp:ImageButton id="Cien" runat="server" ImageUrl="img/100.png"  onclick="Cien_Click"/>
		    <asp:ImageButton id="Docientos" runat="server" ImageUrl="img/200.png"  onclick="Doscientos_Click"/>
			    
			<br/>

            <asp:ImageButton id="Tresientos" runat="server" ImageUrl="img/300.png"  onclick="Tresientos_Click"/>
            <asp:ImageButton id="Quinientos" runat="server" ImageUrl="img/500.png"  onclick="Quinientos_Click"/>
			
			<br/>

            <asp:ImageButton id="Mil" runat="server" ImageUrl="img/1000.png"  onclick="Mil_Click"/>
			<img src="img/blanco.png">

			<br/> <br/>

            <asp:ImageButton id="MontoVariable" runat="server" ImageUrl="img/monto variable.png"  onclick="MontoVariable_Click"/>
            <asp:ImageButton id="Cancelar" runat="server" ImageUrl="img/cancelar.png"  onclick="Cancelar_Click"/>

			
			
		</div>

             </form>
</body>
</html>