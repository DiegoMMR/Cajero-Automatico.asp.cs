using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transaccion_exitosa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Write(Request.QueryString["numero"]);
            Response.Write(Request.QueryString["conteo"]);
        }
    }

    protected void Cancelar_Click(object sender, System.EventArgs e)
    {
        string numero = Request.QueryString["numero"];
        int conteo = Convert.ToInt32(Request.QueryString["conteo"]);
        conteo++;

        if (conteo == 3)
        {
            Response.Write("<script>alert('No puede hacer mas de 3 transacciones')</script>");
            Server.Transfer("Ingreso de tarjeta.aspx", true);
        }
        else
        {
            Response.Redirect("Menu.aspx?numero=" + numero + "&conteo=" + conteo);
            Server.Transfer("Menu.aspx", true);
        }
    }
}