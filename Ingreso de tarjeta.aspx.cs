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
using System.IO;


using System.Data.SqlClient;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
        
    }

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


    public void leerDatos(string numero)
    {
        Tarjeta _Tarjeta = new Tarjeta();
        Conectar();

        Abrir_cn();

        //escribe el codigo para poder biscar los datos de la tarjeta
        cmd = new SqlCommand(String.Format(
              "SELECT notarjeta, codcliente, estado, limite, pin FROM tarjetas  where notarjeta ='{0}'", numero), cn);

        //ejecuta un lector de datos
        SqlDataReader _reader = cmd.ExecuteReader();



        //ingresa lo leido en variables internas
        while (_reader.Read())
        {


            _Tarjeta.numero = _reader.GetString(0);
            _Tarjeta.CodCliente = _reader.GetInt32(1);
            _Tarjeta.estado = _reader.GetString(2);
            _Tarjeta.limite = _reader.GetInt32(3);
            _Tarjeta.pin = _reader.GetInt32(4);

        }



        Cerrar_cn();
    }


    protected void Entrar_Click(object sender, System.EventArgs e)
    {
        string numero = NoTarjeta.Text;

        Response.Redirect("Ingreso de pin.aspx?numero=" + numero);
        Server.Transfer("Ingreso de pin.aspx", true);
    }





    
}