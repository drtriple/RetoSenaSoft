using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROYECTOSENA.Views.interaz
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void validar(object sender, EventArgs e)
        {
            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlconectar = new SqlConnection(conectar);
            SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", sqlconectar);
            {
                cmd.CommandType = CommandType.StoredProcedure;

            }
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@user", TextBox1.Text);
            cmd.Parameters.AddWithValue("@pass", TextBox2.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session["usuarioLogin"] = TextBox1.Text;
                Response.Redirect("cpanel.aspx");

            }
            else
            {
                lblError.Text = "Error de Usuario o contraseña";
            }
            cmd.Connection.Close();
        }
    }
}