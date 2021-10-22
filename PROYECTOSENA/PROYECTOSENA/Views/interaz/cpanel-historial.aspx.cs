using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROYECTOSENA.Views.interaz
{
    public partial class cpanel_historial : System.Web.UI.Page
    {

        String contadorFactura = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Factura\";
        String contadorCedula = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Cedula\";
        String contadorCuenta = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Cuentadecobro\";
        String contadorRegistro = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Registrocivil\";
        String contadorOtros = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Otros\";

        protected void Page_Load(object sender, EventArgs e)
        {
            //html contador archivos
            lblPrueba.Text = GetFiles();


            //establecemos la conecion a la base de datos
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-OI5HJE3;initial catalog=cdem;integrated security=true");
            SqlConnection sqlc = new SqlConnection();
            DataTable dtTp = new DataTable();

            //Traemos los datos con un sp
                sqlc = cn;
                sqlc.Open();
                String strTp = "[dbo].[spMostrarHistorial]";

                SqlDataAdapter datTp = new SqlDataAdapter(strTp, sqlc);
                datTp.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                datTp.Fill(dtTp);

            //almacenamos los datos en un data grid view
            this.GridView1.DataSource = (dtTp);
            GridView1.DataBind();

            sqlc.Close();
            sqlc.Dispose();



            if (Session["usuarioLogin"] != null)
            {

                String usuarioLogueado = Session["usuarioLogin"].ToString();
                lblUser.Text = usuarioLogueado;

            }
            else
            {
                Response.Redirect("WebForm1.aspx");
            }
        }
        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("usuarioLogin");
            Response.Redirect("WebForm1.aspx");
        }

        private string GetFiles()
        {

            string[] lst1 = Directory.GetFiles(contadorFactura);
            string[] lst2 = Directory.GetFiles(contadorCedula);
            string[] lst3 = Directory.GetFiles(contadorCuenta);
            string[] lst4 = Directory.GetFiles(contadorRegistro);
            string[] lst5 = Directory.GetFiles(contadorOtros);

            int i = 0;
            string retornar = i + " archivos creados";
            foreach (var sFile in lst1)
            {
                i++;
            }

            foreach (var sFile in lst2)
            {
                i++;
            }

            foreach (var sFile in lst3)
            {
                i++;
            }

            foreach (var sFile in lst4)
            {
                i++;
            }

            foreach (var sFile in lst5)
            {
                i++;

            }
            retornar = i + " archivos creados";
            return retornar;
        }

      

    }
}