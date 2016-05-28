<%@ Page Title="Cajero" Language="C#" AutoEventWireup="true" CodeFile="Ingreso de tarjeta.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
	
	<title>Cajero Automatico</title>

<!--Este es el estilo de la pagina-->
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
        

		<!--este es in div para el fondo -->
		<div id="fondo">
			<img src="img/fondo.jpg">
		</div>

        <form id="IngresoTarjeta" runat="server">

		<!--en este div se le pone la posicion para que este quede sobre el fondo -->
		<div id="inicio-de-secion" style="position:absolute; top:36px; left:381px; visibility:visible">

			<h1>Ingrese su Tarjeta</h1>

			<br/> <br/>

			<asp:TextBox ID="NoTarjeta" runat=server />
			
			<br/> <br/> <br/> <br/> <br/> <br/>

            <asp:ImageButton id="Entrar" runat="server" ImageUrl="img/entrar.png"  onclick="Entrar_Click"/>
            <img src="img/blanco.png">
	

			
		</div>
             </form>
</body>
</html>