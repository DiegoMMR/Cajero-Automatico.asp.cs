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
public class Tarjeta
{
    public string numero { get; set; }
    public int CodCliente { get; set; }
    public string estado { get; set; }
    public int limite { get; set; }
    public int pin { get; set; }

	public Tarjeta()
	{
        numero = "";
        CodCliente = 0;
        estado = "vigente";
        limite = 0;
        pin = 0;        
	}
}