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
        if(!IsPostBack)
        {
            Response.Write(Request.QueryString["numero"]);
        }
       
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
    

    protected void Entrar_Click(object sender, System.EventArgs e)
    {

        pinInvalido.Text = "";
        pines.Text = "";
        string numero;
        int pin = 0;

        pinInvalido.Text = "";
        pin = Convert.ToInt32(pintext.Text);
        numero = Request.QueryString["numero"];
        int conteo = Convert.ToInt32(Request.QueryString["conteo"]);

        Tarjeta _Tarjeta = new Tarjeta();
        Conectar();

        string codigo = "SELECT notarjeta, codcliente, estado, limite, pin FROM tarjetas  where notarjeta=" + numero + ";";
        //escribe el codigo para poder biscar los datos de la tarjeta

        cmd = new SqlCommand(String.Format(codigo), cn);

        Abrir_cn();
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

        Response.Write("=" + _Tarjeta.numero + ", " + _Tarjeta.CodCliente + ", " + _Tarjeta.estado + ", " + _Tarjeta.limite + ", " + _Tarjeta.pin + ", " + pin + ", " + numero);

        pin = Convert.ToInt32(pintext.Text);
        int pin1 = Convert.ToInt32(Pin1.Text);
        int pin2 = Convert.ToInt32(Pin2.Text);


           

        //analiza el pin ingresado con el pin real de la tarjeta
        if (pin != _Tarjeta.pin)
         {
             pinInvalido.Text = "Pin Invalido";
         }

        if (pin1 != pin2)
        {
            pines.Text = "Los pines no coinciden";
        }

        if (pin == _Tarjeta.pin && pin1 == pin2)
        {

            //desde aca escribe datos
            Abrir_cn();

            //escribe el codigo para poder cambiar el limite confome a la cantidad
            cmd = new SqlCommand(String.Format(
                  "update tarjetas set pin = '{0}'  where notarjeta ='{1}'", pin1, numero), cn);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();

            Cerrar_cn();
            cmd.Dispose();


            string codcliente = Request.QueryString["codCliente"];

            Response.Redirect("Transaccion exitosa.aspx?numero=" + numero + "&conteo=" + conteo + "&codCliente=" + codcliente);
            Server.Transfer("Transaccion exitosa.aspx", true);

        }

    }

             
    protected void Cancelar_Click(object sender, System.EventArgs e)
    {
        int conteo = Convert.ToInt32(Request.QueryString["conteo"]);
        string numero = Request.QueryString["numero"];
        string codcliente = Request.QueryString["codCliente"];

        Response.Redirect("Menu.aspx?numero=" + numero + "&conteo=" + conteo + "&codCliente=" + codcliente);
        Server.Transfer("Menu.aspx", true);

    }


    
}