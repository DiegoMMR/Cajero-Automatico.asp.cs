using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


using System.Data.SqlClient;


public class Transaccion
{
    public int codigo
    {
        get;
        set;
    }

    public int NoTarjeta
    {
        get;
        set;
    }

    public string tipo
    {
        get;
        set;
    }

    public int monto
    {
        get;
        set;
    }

    public string ubicacion
    {
        get;
        set;
    }

    
    public string fecha
    {
        get;
        set;
    }



    public Transaccion()
	{
        DateTime hoy = DateTime.Today;

        codigo = 0;
        NoTarjeta = 0;
        tipo = "";
        monto = 0;
        ubicacion = "";
        fecha = hoy.ToString();
	}
}