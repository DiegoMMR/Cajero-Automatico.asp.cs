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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Write(Request.QueryString["numero"]);
        }
    }

    public SqlCommand cmd;
    public DataTable dt;
    public SqlDataAdapter da;
    public SqlConnection cn;
    int cantidad = 0;


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

       
    public void depositar(int cantidad)
    {
        Tarjeta _Tarjeta = new Tarjeta();
        string numero = Request.QueryString["numero"];

        Conectar();

        //desde aca lee los datos
        Abrir_cn();

        //escribe el codigo para poder buscar los datos de la tarjeta
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

        int nuevoLimite = _Tarjeta.limite + cantidad;

        Cerrar_cn();

        //desde aca escribe datos
        Abrir_cn();

        //escribe el codigo para poder cambiar el limite confome a la cantidad
        cmd = new SqlCommand(String.Format(
              "update tarjetas set limite = '{0}'  where notarjeta ='{1}'", nuevoLimite, numero ), cn);
        cmd.CommandType = CommandType.Text;

        cmd.ExecuteNonQuery();

        Cerrar_cn();
        cmd.Dispose();

        //desde aca comienza la creacion de la transaccion
        Abrir_cn();

        //escribe el codigo para poder crear una transaccion
        DateTime hoy = DateTime.Now;

        Random r = new Random(DateTime.Now.Millisecond);
        string tipo = "deposito";
        string codTransaccion = "";
        string fecha = hoy.ToShortDateString();

        int aleatorio = r.Next(100, 999999);
        codTransaccion = aleatorio + "" + cantidad;

        //inserta los datos dentro de la base
        cmd = new SqlCommand(String.Format(
              "insert into transacciones (codtransaccion, notarjeta, tipo, monto, fecha) values ('{0}','{1}','{2}','{3}','{4}');",codTransaccion,numero,tipo,cantidad,fecha), cn);
        cmd.CommandType = CommandType.Text;

        cmd.ExecuteNonQuery();

        Cerrar_cn();
        cmd.Dispose();


        int conteo = Convert.ToInt32(Request.QueryString["conteo"]);
        string codcliente = Request.QueryString["codCliente"];

        Response.Redirect("Transaccion exitosa.aspx?numero=" + numero + "&conteo=" + conteo + "&codCliente=" + codcliente);
        Server.Transfer("Transaccion exitosa.aspx", true);


    }


    protected void Cien_Click(object sender, System.EventArgs e)
    {
        cantidad = 100;
        depositar(cantidad);
        
    }

    protected void Doscientos_Click(object sender, System.EventArgs e)
    {
        cantidad = 200;
        depositar(cantidad);
    }

    protected void Tresientos_Click(object sender, System.EventArgs e)
    {
        cantidad = 300;
        depositar(cantidad);
    }

    protected void Quinientos_Click(object sender, System.EventArgs e)
    {
        cantidad = 500;
        depositar(cantidad);
    }

    protected void Mil_Click(object sender, System.EventArgs e)
    {
        cantidad = 1000;
        depositar(cantidad);
    }

    protected void MontoVariable_Click(object sender, System.EventArgs e)
    {
        string numero = Request.QueryString["numero"];
        int conteo = Convert.ToInt32(Request.QueryString["conteo"]);
        string codcliente = Request.QueryString["codCliente"];

        Response.Redirect("Deposito Monto Variable.aspx?numero=" + numero + "&conteo=" + conteo + "&codCliente=" + codcliente);
        Server.Transfer("Deposito Monto Variable.aspx", true);
    }

    protected void Cancelar_Click(object sender, System.EventArgs e)
    {
        string numero = Request.QueryString["numero"];
        int conteo = Convert.ToInt32(Request.QueryString["conteo"]);
        string codcliente = Request.QueryString["codCliente"];

        Response.Redirect("Menu.aspx?numero=" + numero + "&conteo=" + conteo + "&codCliente=" + codcliente);
        Server.Transfer("Menu.aspx", true);
    }
}