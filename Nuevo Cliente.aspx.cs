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



public partial class Nuevo_Cliente : System.Web.UI.Page
{
    
    Guardar_cliente _Guardar = new Guardar_cliente();
    Cliente _Cliente = new Cliente();

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

    protected void cmdGuardar_Click(object sender, EventArgs e)
    {
        _Cliente.codigo = Convert.ToInt32(txtCodigo.Text);
        _Cliente.nombre = txtNombre.Text;
        _Cliente.nit = txtNit.Text;
        _Cliente.direccion = txtDireccion.Text;
        _Cliente.telefono = int.Parse(txtTelefono.Text);
        _Cliente.correo = txtCorreo.Text;

        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConeccion"].ConnectionString);

        Abrir_cn();

        //ejecuta el codigo de sql para poder escibir datos dentro de la base de datos
        cmd = new SqlCommand(@"INSERT INTO Clientes (codcliente, nombre, nit, direccion, telefono, correo) values ('" + _Cliente.codigo +
            "','" + _Cliente.nombre + "','" + _Cliente.nit + "','" + _Cliente.direccion + "','" + _Cliente.telefono + "','" +_Cliente.correo + " ')", cn);
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
        }

     

    }
}