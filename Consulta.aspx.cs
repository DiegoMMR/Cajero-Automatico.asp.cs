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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Write(Request.QueryString["numero"]);
                Response.Write(Request.QueryString["conteo"]);
            }

            string numero;

            numero = Request.QueryString["numero"];
            

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

            LimiteDisponible.Text = "Limite actual...............Q." + _Tarjeta.limite + ".00";

        }



        //se transfiere a la pagina de menu al dar click en el boton
        protected void Cancelar_Click(object sender, System.EventArgs e)
        {
            string numero = Request.QueryString["numero"];
            int conteo = Convert.ToInt32(Request.QueryString["conteo"]);
            conteo++;

            if (conteo == 5)
            {

                Response.Write("<script>alert('No puede hacer mas de 5 transacciones')</script>");
                Server.Transfer("Ingreso de tarjeta.aspx", true);
            }
            else
            {
                Response.Redirect("Menu.aspx?numero=" + numero + "&conteo=" + conteo);
                Server.Transfer("Menu.aspx", true);
            }

            
        }

    }
