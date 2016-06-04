using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    string pagina = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Write(Request.QueryString["numero"]);
            Response.Write(Request.QueryString["conteo"]);
        }
    }

    public void PasarDatos(string pagina)
    {
        int conteo = Convert.ToInt32(Request.QueryString["conteo"]);
        string numero = Request.QueryString["numero"];

        Response.Redirect(pagina + "?numero=" + numero + "&conteo=" + conteo);
        Server.Transfer(pagina, true);
    }

    protected void Consultar_Click(object sender, System.EventArgs e)
    {
        pagina = "Consulta.aspx";
        PasarDatos(pagina);
    }

    protected void Depositar_Click(object sender, System.EventArgs e)
    {
        pagina = "Deposito.aspx";
        PasarDatos(pagina);      
    }

    protected void Retirar_Click(object sender, System.EventArgs e)
    {
        pagina = "Retiro.aspx";
        PasarDatos(pagina);
    }

    protected void CambioDePin_Click(object sender, System.EventArgs e)
    {
        Server.Transfer("Cambio de pin.aspx", true);
    }

    protected void Cancelar_Click(object sender, System.EventArgs e)
    {
        pagina = "Ingreso de tarjeta.aspx";
        PasarDatos(pagina);       
    }
}