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

    protected void Entrar_Click(object sender, System.EventArgs e)
    {
        Server.Transfer("", true);
    }



    protected void Cancelar_Click(object sender, System.EventArgs e)
    {
        Server.Transfer("Deposito.aspx", true);
    }
    
}