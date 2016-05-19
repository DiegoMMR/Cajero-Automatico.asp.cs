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

        //se transfiere a la pagina de menu al dar click en el boton
        protected void Cancelar_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("Menu.aspx", true);
        }

    }
