using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROYECTOSENA.Views.interaz
{
    public partial class cpanel_carpetas : System.Web.UI.Page
    {
        ///Array donde se almacenan el nombre de los archivos

        protected List<string> myList1 = null;
        protected List<string> myList2 = null;
        protected List<string> myList3 = null;
        protected List<string> myList4 = null;
        protected List<string> myList5 = null;

        // Dirreciones de las carpetas para contar el total de archivos
        String contadorFactura = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Factura\";
        String contadorCedula = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Cedula\";
        String contadorCuenta = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Cuentadecobro\";
        String contadorRegistro = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Registrocivil\";
        String contadorOtros = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Otros\";


        protected void Page_Load(object sender, EventArgs e)
        {
            //html contador archivos
            lblPrueba.Text = GetFiles();

            // llamamos los arrays 
            myList1 = new List<string>();
            myList2 = new List<string>();
            myList3 = new List<string>();
            myList4 = new List<string>();
            myList5 = new List<string>();


            //creamos un array con los nombres de los archivos
            var dir1 = new System.IO.DirectoryInfo(Server.MapPath("~/Documentos/Cedula"));
            System.IO.FileInfo[] fileNames1 = dir1.GetFiles("*.*");

            //los valores del array los almacenamos en el array de string
            foreach (var file in fileNames1)
            {
                myList1.Add(file.Name);
            }

            //generamos html dependiendo de la cantidad de archivos 
            this.Repeater1.DataSource = myList1;
            this.Repeater1.DataBind();

            var dir2 = new System.IO.DirectoryInfo(Server.MapPath("~/Documentos/Cuentadecobro"));
            System.IO.FileInfo[] fileNames2 = dir2.GetFiles("*.*");

            foreach (var file in fileNames2)
            {
                myList2.Add(file.Name);
            }

            //se repite lo mismo para las otras carpetas
            this.Repeater2.DataSource = myList2;
            this.Repeater2.DataBind();

            var dir3 = new System.IO.DirectoryInfo(Server.MapPath("~/Documentos/Factura"));
            System.IO.FileInfo[] fileNames3 = dir3.GetFiles("*.*");

            foreach (var file in fileNames3)
            {
                myList3.Add(file.Name);
            }


            this.Repeater3.DataSource = myList3;
            this.Repeater3.DataBind();

            var dir4 = new System.IO.DirectoryInfo(Server.MapPath("~/Documentos/Otros"));
            System.IO.FileInfo[] fileNames4 = dir4.GetFiles("*.*");

            foreach (var file in fileNames4)
            {
                myList4.Add(file.Name);
            }


            this.Repeater4.DataSource = myList4;
            this.Repeater4.DataBind();

            var dir5 = new System.IO.DirectoryInfo(Server.MapPath("~/Documentos/Registrocivil"));
            System.IO.FileInfo[] fileNames5 = dir5.GetFiles("*.*");

            foreach (var file in fileNames5)
            {
                myList5.Add(file.Name);
            }


            this.Repeater5.DataSource = myList5;
            this.Repeater5.DataBind();



            //Guardamos las sesiones en la variable para acceder mantener sesion abierta
            //manejo de sesiones 
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

        private string GetFilesCantidad()
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
            retornar = i + "";
            return retornar;
        }


    }
}