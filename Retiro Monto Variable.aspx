<%@ Page Title="Cajero" Language="C#" AutoEventWireup="true" CodeFile="Retiro Monto Variable.aspx.cs" Inherits="_Default" %>

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
        <form id="RetiroMontoVariable" runat="server">

		<!--este es in div para el fondo -->
		<div id="fondo">
			<img src="img/fondo.jpg">
		</div>


		<!--en este div se le pone la posicion para que este quede sobre el fondo -->
		<div id="retiro-monto-var" style="position:absolute; top:36px; left:381px; visibility:visible">

			<h1>¿Cuanto desea retirar?</h1>

			<br/> <br/>

            <asp:TextBox ID="Retiro" runat=server />

            <br/>

            <asp:Label ID="MontoInvalido"  backcolor="Red" Text="" runat="server"></asp:Label>
			
			<br/> <br/> <br/> <br/> <br/> <br/>

            <asp:ImageButton id="Entrar" runat="server" ImageUrl="img/entrar.png"  onclick="Entrar_Click"/>
            <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="img/cancelar.png"  onclick="Cancelar_Click"/>
            			
		

			
		</div>
            </form>
</body>
</html>