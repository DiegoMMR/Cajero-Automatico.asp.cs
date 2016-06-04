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
using System.Collections.Specialized;

using System.Data.SqlClient;

public partial class _Default : Page
{
    string pagina = "";
    public SqlCommand cmd;
    public DataTable dt;
    public SqlDataAdapter da;
    public SqlConnection cn;

    public void Conectar()
    {
        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConeccion"].ConnectionString);
    }

    public void Abrir_cn()
    {
        try
        {
            if (cn.State == ConnectionState.Broken || cn.State == ConnectionState.Closed)
                cn.Open();
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    public void Cerrar_cn()
    {
        try
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }
        catch (Exception e)
        {
            throw (e);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Write(Request.QueryString["numero"]);
            Response.Write(Request.QueryString["conteo"]);
            Response.Write(Request.QueryString["codCliente"]);
        }

        string codcliente = Request.QueryString["codCliente"];

        Cliente _Cliente = new Cliente();

        Conectar();

        string codigo = "SELECT nombre FROM clientes  where codcliente=" + codcliente + ";";
        //escribe el codigo para poder biscar los datos de la tarjeta

        cmd = new SqlCommand(String.Format(codigo), cn);

        Abrir_cn();
        //ejecuta un lector de datos
        SqlDataReader _reader = cmd.ExecuteReader();



        //ingresa lo leido en variables internas
        while (_reader.Read())
        {
            _Cliente.nombre = _reader.GetString(0);
           
        }
        Cerrar_cn();

        txtNombre.Text = _Cliente.nombre;
    }

    public void PasarDatos(string pagina)
    {
        int conteo = Convert.ToInt32(Request.QueryString["conteo"]);
        string numero = Request.QueryString["numero"];
        string codcliente = Request.QueryString["codCliente"];

        Response.Redirect(pagina + "?numero=" + numero + "&conteo=" + conteo + "&codCliente=" + codcliente);
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