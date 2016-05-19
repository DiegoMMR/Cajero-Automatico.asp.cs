<%@ Page Title="Cajero" Language="C#" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>

<html>
<head runat="server">
   
    <title>Cajero Automatico</title>

    <!--Este es el estilo de la pagina-->
    <style type="text/css">
        body {
            background: black;
            color: black;
            font: 150% arial;
            text-align: center;
        }
    </style>

</head>

<body>
    <form id="Form1" runat="server">

    <!--este es in div para el fondo -->
    <div id="fondo">
        <img src="img/fondo.jpg">
    </div>


    <!--en este div se le pone la posicion para que este quede sobre el fondo -->
    <div class="row" style="position:absolute; top:36px; left:381px; visibility:visible">

        <h1>Saldo de cuenta</h1>

        <br /> <br />
       
        <asp:Label ID="LimiteDisponible" Text="Limite actual...............Q." runat="server"></asp:Label>
       
        <br /> <br />

        <img src="img/blanco.png">

       
            
            <asp:ImageButton id="Cancelar" runat="server" ImageUrl="img/cancelar.png"  onclick="Cancelar_Click"/>
            

       
    </div>
        </form>
</body>
</html>

