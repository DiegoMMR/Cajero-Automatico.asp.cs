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




    public class Guardar_cliente : Conectar
    {

        public SqlCommand cmd;
        public DataTable dt;
        public SqlDataAdapter da;
        int res;


      
        public int Inserta_Cliente(Cliente _Cliente)
        {

            res = 0;
            cmd = new SqlCommand(@"INSERT INTO Clientes (codcliente, nombre, nit, direccion, telefono, correo) values ('" + _Cliente.codigo +
            "','" + _Cliente.nombre + "','" + _Cliente.nit + "','" + _Cliente.direccion + "','" + _Cliente.telefono + "','" + _Cliente.correo + " ')", cn);
            cmd.CommandType = CommandType.Text;

            try
            {
                Abrir_cn();
                res = cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw e;
            }

            finally
            {
                Cerrar_cn();
                cmd.Dispose();
            }
            return res;
        }

    }

