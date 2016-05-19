using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Cien_Click(object sender, System.EventArgs e)
    {
        Server.Transfer("", true);
    }

    protected void Doscientos_Click(object sender, System.EventArgs e)
    {
        Server.Transfer("", true);
    }

    protected void Tresientos_Click(object sender, System.EventArgs e)
    {
        Server.Transfer("", true);
    }

    protected void Quinientos_Click(object sender, System.EventArgs e)
    {
        Server.Transfer("", true);
    }

    protected void Mil_Click(object sender, System.EventArgs e)
    {
        Server.Transfer("", true);
    }

    protected void MontoVariable_Click(object sender, System.EventArgs e)
    {
        Server.Transfer("Retiro Monto Variable.aspx", true);
    }

    protected void Cancelar_Click(object sender, System.EventArgs e)
    {
        Server.Transfer("Menu.aspx", true);
    }
}