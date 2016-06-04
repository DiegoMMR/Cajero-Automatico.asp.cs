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



public partial class Nueva_Tarjeta : System.Web.UI.Page
{
    Tarjeta _Tarjeta = new Tarjeta();

    public SqlCommand cmd;
    public DataTable dt;
    public SqlDataAdapter da;
    public SqlConnection cn;
 

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
       
    }

    protected void Generar_Click(object sender, EventArgs e)
    {
        Random r = new Random(DateTime.Now.Millisecond);
        Random r2 = new Random();

        string aux1 = Convert.ToString(r.Next(10000, 99999));
        string aux2 = Convert.ToString(r2.Next(10000, 99999));

        string aleatorio = aux1 + aux2;

        txtTarjeta.Text = aleatorio;
    }

    protected void cmdGuardar_Click(object sender, EventArgs e)
    {
        _Tarjeta.numero = txtTarjeta.Text;
        _Tarjeta.CodCliente =Convert.ToInt32(txtCodCliente.Text);
        _Tarjeta.estado = txtEstado.Text;
        _Tarjeta.limite = Convert.ToInt32(txtLimite.Text);
        _Tarjeta.pin = Convert.ToInt32(txtPin.Text);
       
        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConeccion"].ConnectionString);

        Abrir_cn();

        //ejecuta el codigo de sql para poder escibir datos dentro de la base de datos
        cmd = new SqlCommand(String.Format(
              "insert into tarjetas (notarjeta, codcliente, estado, limite, pin) values ('{0}','{1}','{2}','{3}','{4}');", _Tarjeta.numero, _Tarjeta.CodCliente, _Tarjeta.estado, _Tarjeta.limite, _Tarjeta.pin), cn);
        cmd.CommandType = CommandType.Text;

        //prueba escribir los datos y si da error no completa el proceso
        try
        {
            Abrir_cn();
            cmd.ExecuteNonQuery();
        }

        catch (Exception a)
        {
            throw a;
        }

        finally
        {
            Cerrar_cn();            
            cmd.Dispose();
            Response.Write("<script>alert('Tarjeta guardada exitosamente')</script>");

            txtCodCliente.Text = "";
            txtEstado.Text = "";
            txtLimite.Text = "";
            txtPin.Text = "";
            txtTarjeta.Text = "";

        }

    

    }
}