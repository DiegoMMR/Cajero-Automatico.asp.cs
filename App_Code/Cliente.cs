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
/// <summary>
/// Descripción breve de Cliente
/// </summary>
public class Cliente
{
    public int codigo
    {
        get;
        set;
    }

    public string nombre
    {
        get;
        set;
    }

    public string nit
    {
        get;
        set;
    }

    public string direccion
    {
        get;
        set;
    }

    public int telefono
    {
        get;
        set;
    }

    public string correo
    {
        get;
        set;
    }

	public Cliente()
	{
        codigo = 0;
        nombre = "";
        nit = "";
        direccion = "";
        telefono = 0;
        correo = "";
	}
}