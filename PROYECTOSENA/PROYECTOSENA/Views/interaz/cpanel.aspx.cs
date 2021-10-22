using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Windows.Shapes;
using IronOcr;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.Devices;
using System.Data.SqlClient;

namespace PROYECTOSENA.Views.interaz
{
    public partial class cpanel : System.Web.UI.Page
    {

       String contadorFactura = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Factura\";
       String contadorCedula = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Cedula\";
       String contadorCuenta = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Cuentadecobro\";
       String contadorRegistro = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Registrocivil\";
       String contadorOtros = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Otros\";

       

        protected void Page_Load(object sender, EventArgs e)
        {

            lblPrueba.Text = GetFiles();
            LabelCantidadArchivos.Text = GetFilesCantidad();
            //Gurdamos la sesion
            if (Session["usuarioLogin"] != null)
            {

                String usuarioLogueado = Session["usuarioLogin"].ToString();
                lblUsuario.Text = usuarioLogueado;
            }
            else
            {
                Response.Redirect("WebForm1.aspx");
            }


        }

        private string GetFiles()
        {
            //Contadores de archivos en las carpetas
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




        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("usuarioLogin");
            Response.Redirect("WebForm1.aspx");
        }
        //SUBIR UN  SOLO ARCHIVO 
        protected void SubirArchivo_Click(object sender, EventArgs e)
        {
            //Sacamos la extensión del archivo que se sube y sacamos el nombre 
            string extension = System.IO.Path.GetExtension(FileUpload1.FileName);

            Computer mycomputer = new Computer();
            string urlFact;
            string urlCed;
            string urlRegisC;
            string urlCuC;
            string urlOtros;
            string UrlSaveFact;
            string UrlSaveCuC;
            string UrlSaveCed;
            string UrlSaveRegisC;
            string UrlSaveOtros;


           //Validamos de que si sea un archivo
            if (FileUpload1.HasFile)
            {
                //Validamos la extension de pdf

                if (extension == ".pdf")
                {
                    //Validamos la existencia del archivo
                    if (!File.Exists((Server.MapPath("~/Documentos/" + FileUpload1.FileName))))
                    {
                        //Guardamos los archivos 
                        FileUpload1.SaveAs(Server.MapPath("~/Documentos/" + FileUpload1.FileName));
                        //Instanciamos el objeto iron de la libreía que nos permite leer los documentos
                        var Ocr = new IronTesseract();

                        
                        //Le especificamos el idioma y optimizamos la lectura
                        Ocr.Language = OcrLanguage.SpanishFast;
                        Ocr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;
                        Ocr.Configuration.EngineMode = TesseractEngineMode.LstmOnly;
                        Ocr.Configuration.ReadBarCodes = false;
                        Ocr.Configuration.RenderSearchablePdfsAndHocr = false;
                        Ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;
                     
                        //Traemos el nombre del archivo
                        string path = Server.MapPath("~/Documentos/" + FileUpload1.FileName);
                        // Creamos un objeto OCRInput para leer pdf e imagenes más fáciles
                        using (var Input = new OcrInput(path))
                        {

                            Input.Deskew();
                            //Tornamos lo pixeles a blanco y negro y escala de grises y mejoramos resolucion
                            Input.Binarize();
                            Input.EnhanceResolution();



                            //Acá le decimos al ocr que lea el archivo
                            var resp = Ocr.Read(Input);
                            //Almacenar la respuesta en una variable string//
                            string txt = resp.Text;
                            //Mostrar string de la extraccion de txt//
                            string txtPdf = resp.Text;


                            //Expresiones regulares permitidas para cada tipo de doc//
                            string Factura = @"(\w*factura\w*)|(\w*FACTURA\w*)|(\w*Factura\w*)";
                            string CuentaC = @"(\w*CUENTA COBRO\w*)|(\w*Cuenta Cobro\w*)|(\w*CUENTA DE COBRO\w*)|(\w*Cuenta De Cobro\w*)|(\w*cuenta de cobro\w*)|(\w*Cuenta de Cobro\w*)";
                            string Ced = @"(\w*EXPEDICION\w*)|(\w*LUGAR\w*)|(\w*CEDULA\w*)|(\w*NACIMIENTO\w*)|(\w*CIUDADANIA\w*)";
                            string RegisC = @"(\w*REGISTRO CIVIL\w*)|(\w*registro civil\w*)";
                            string Otros = @"^(?!.\w*FACTURA\w*)|^(?!.\wFACTURA\w*)|^(?!.\wFactura\w*)|^(?!.\w*REGISTRO CIVIL\w*)|^(?!.\w*registro civil\w*)|^(?!.\w*EXPEDICION\w*)|^(?!.\w*LUGAR\w*)|^(?!.\w*CEDULA\w*)|^(?!.\w*NACIMIENTO\w*)|^(?!.\w*CIUDADANIA\w*)|^(?!.\w*CUENTA COBRO\w*)|^(?!.\w*Cuenta Cobro\w*)|^(?!.\w*CUENTA DE COBRO\w*)|^(?!.\w*Cuenta De Cobro\w*)|^(?!.\w*cuenta de cobro\w*)|^(?!.\w*Cuenta de Cobro\w*)|^(?!.\w*COBRO\w*)|^(?!.\w*Cobro\w*)|^(?!.\w*cobro\w*)";


                            //Expresiones regulares inmutables//

                            Regex regFact = new Regex(Factura);
                            Regex regCuC = new Regex(CuentaC);
                            Regex regCed = new Regex(Ced);
                            Regex regRegisC = new Regex(RegisC);
                            Regex regOtros = new Regex(Otros);


                            //Coincidencias//

                            MatchCollection matchFact = regFact.Matches(txt);
                            MatchCollection matchCuc = regCuC.Matches(txt);
                            MatchCollection matchCed = regCed.Matches(txt);
                            MatchCollection matchRegiC = regRegisC.Matches(txt);
                            MatchCollection matchOtros = regOtros.Matches(txt);
                            //Ubicacion de las carpetas //

                            urlFact = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Factura\";
                            urlCed = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Cedula\";
                            urlCuC = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Cuentadecobro\";
                            urlRegisC = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Registrocivil\";
                            urlOtros = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Otros\";

                            //Concatenacion de la ubicacion de archivos y su nombre para su guardado//

                            UrlSaveFact = string.Concat(urlFact, FileUpload1.FileName);
                            UrlSaveCed = string.Concat(urlCed, FileUpload1.FileName);
                            UrlSaveCuC = string.Concat(urlCuC, FileUpload1.FileName);
                            UrlSaveRegisC = string.Concat(urlRegisC, FileUpload1.FileName);
                            UrlSaveOtros = string.Concat(urlOtros, FileUpload1.FileName);

                            //Decision de guardado dependiendo tipo de doc//

                            if (matchFact.Count > 0)
                            {
                                SqlConnection sqlc = new SqlConnection();
                                SqlConnection cn = new SqlConnection();
                                cn.ConnectionString = "Data Source=DESKTOP-OI5HJE3;initial catalog=cdem;integrated security=true";
                                sqlc = cn;
                                sqlc.Open();
                                String db = "[dbo].[spInsertar]";

                                SqlCommand cmTP = new SqlCommand(db, sqlc);
                                cmTP.CommandType = System.Data.CommandType.StoredProcedure;

                                cmTP.Parameters.AddWithValue("@nombreDocumento", FileUpload1.FileName);
                                cmTP.Parameters.AddWithValue("@extension", extension);
                                cmTP.Parameters.AddWithValue("@usuario", lblUsuario.Text);
                                cmTP.Parameters.AddWithValue("@idCarpeta", 3);

                                cmTP.ExecuteNonQuery();

                                sqlc.Close();
                                sqlc.Dispose();

                                lbMensajeArchivo.Text = "Ingreso Exitoso";
                                mycomputer.FileSystem.MoveFile(path, UrlSaveFact);

                            }
                            else if (matchCuc.Count > 0)
                            {

                                //Enviamos la información del archivo y de la insersión en la base de datos
                                SqlConnection sqlc = new SqlConnection();
                                SqlConnection cn = new SqlConnection();
                                cn.ConnectionString = "Data Source=DESKTOP-OI5HJE3;initial catalog=cdem;integrated security=true";
                                sqlc = cn;
                                sqlc.Open();
                                String db = "[dbo].[spInsertar]";

                                SqlCommand cmTP = new SqlCommand(db, sqlc);
                                cmTP.CommandType = System.Data.CommandType.StoredProcedure;

                                cmTP.Parameters.AddWithValue("@nombreDocumento", FileUpload1.FileName);
                                cmTP.Parameters.AddWithValue("@extension", extension);
                                cmTP.Parameters.AddWithValue("@usuario", lblUsuario.Text);
                                cmTP.Parameters.AddWithValue("@idCarpeta", 2);

                                cmTP.ExecuteNonQuery();

                                sqlc.Close();
                                sqlc.Dispose();

                                lbMensajeArchivo.Text = "Ingreso Exitoso";
                                mycomputer.FileSystem.MoveFile(path, UrlSaveCuC);
                            }
                            else if (matchCed.Count > 0)
                            {
                                SqlConnection sqlc = new SqlConnection();
                                SqlConnection cn = new SqlConnection();
                                cn.ConnectionString = "Data Source=DESKTOP-OI5HJE3;initial catalog=cdem;integrated security=true";
                                sqlc = cn;
                                sqlc.Open();
                                String db = "[dbo].[spInsertar]";

                                SqlCommand cmTP = new SqlCommand(db, sqlc);
                                cmTP.CommandType = System.Data.CommandType.StoredProcedure;

                                cmTP.Parameters.AddWithValue("@nombreDocumento", FileUpload1.FileName);
                                cmTP.Parameters.AddWithValue("@extension", extension);
                                cmTP.Parameters.AddWithValue("@usuario", lblUsuario.Text);
                                cmTP.Parameters.AddWithValue("@idCarpeta", 1);

                                cmTP.ExecuteNonQuery();

                                sqlc.Close();
                                sqlc.Dispose();

                                lbMensajeArchivo.Text = "Ingreso Exitoso";
                                mycomputer.FileSystem.MoveFile(path, UrlSaveCed);
                            }
                            else if (matchRegiC.Count > 0)
                            {
                                SqlConnection sqlc = new SqlConnection();
                                SqlConnection cn = new SqlConnection();
                                cn.ConnectionString = "Data Source=DESKTOP-OI5HJE3;initial catalog=cdem;integrated security=true";
                                sqlc = cn;
                                sqlc.Open();
                                String db = "[dbo].[spInsertar]";

                                SqlCommand cmTP = new SqlCommand(db, sqlc);
                                cmTP.CommandType = System.Data.CommandType.StoredProcedure;

                                cmTP.Parameters.AddWithValue("@nombreDocumento", FileUpload1.FileName);
                                cmTP.Parameters.AddWithValue("@extension", extension);
                                cmTP.Parameters.AddWithValue("@usuario", lblUsuario.Text);
                                cmTP.Parameters.AddWithValue("@idCarpeta", 5);

                                cmTP.ExecuteNonQuery();

                                sqlc.Close();
                                sqlc.Dispose();

                                lbMensajeArchivo.Text = "Ingreso Exitoso";
                                mycomputer.FileSystem.MoveFile(path, UrlSaveRegisC);
                            }
                            else 
                            {
                                SqlConnection sqlc = new SqlConnection();
                                SqlConnection cn = new SqlConnection();
                                cn.ConnectionString = "Data Source=DESKTOP-OI5HJE3;initial catalog=cdem;integrated security=true";
                                sqlc = cn;
                                sqlc.Open();
                                String db = "[dbo].[spInsertar]";

                                SqlCommand cmTP = new SqlCommand(db, sqlc);
                                cmTP.CommandType = System.Data.CommandType.StoredProcedure;

                                cmTP.Parameters.AddWithValue("@nombreDocumento", FileUpload1.FileName);
                                cmTP.Parameters.AddWithValue("@extension", extension);
                                cmTP.Parameters.AddWithValue("@usuario", lblUsuario.Text);
                                cmTP.Parameters.AddWithValue("@idCarpeta", 4);

                                cmTP.ExecuteNonQuery();

                                sqlc.Close();
                                sqlc.Dispose();

                                lbMensajeArchivo.Text = "No ha podido reconocer el archivo, se ha alojado en la carperta" + urlOtros ; 
                            
                            }

                            //mycomputer.FileSystem.MoveFile(path, UrlSaveOtros);

                        }

                        //if (txt != null) { lbMensajeArchivo.Text = txt; }

                        //Response.Redirect("cpanel.aspx");



                    }
                    else
                    {

                        lbMensajeArchivo.Text = "El nombre de ese archivo ya existe";

                    }

                }
                else
                {
                    lbMensajeArchivo.Text = "Solo se permiten documentos PDF";
                }


            }
            else
            {
                lbMensajeArchivo.Text = "Debes seleccionar una archivo";
            }
        }

        // SUBIR VARIOS ARCHIVOS
        protected void CargarVariosArchivos_Click(object sender, EventArgs e) {

            string urlFact;
            string urlCed;
            string urlRegisC;
            string urlCuC;
            string urlOtros;
            string onlyFileName;
            string UrlSaveFact;
            string UrlSaveCuC;
            string UrlSaveCed;
            string UrlSaveRegisC;
            string UrlSaveOtros;
            Computer mycomputer = new Computer();

            string[] filesArray = Directory.GetFiles(@"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos");


            foreach (string FileName in filesArray)
            {
                onlyFileName = System.IO.Path.GetFileName(FileName);
                string extension = System.IO.Path.GetExtension(onlyFileName);

                // Se crea el objeto ocr
                var Ocr = new IronTesseract();
                // Configuracion para velocidad //
                Ocr.Configuration.BlackListCharacters = "~`$#^*_}{][|\\";
                Ocr.Language = OcrLanguage.SpanishFast;
                Ocr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;
                Ocr.Configuration.EngineMode = TesseractEngineMode.LstmOnly;
                Ocr.Configuration.ReadBarCodes = false;
                Ocr.Configuration.RenderSearchablePdfsAndHocr = false;
                Ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;

                using (var Input = new OcrInput(FileName))
                {
                    Input.Deskew();
                    Input.Binarize();
                    Input.EnhanceResolution();
                    var resp = Ocr.Read(Input);
                    string txt = resp.Text;

                    //Expresiones regulares permitidas para cada tipo de doc//

                    string Factura = @"(\w*factura\w*)|(\w*FACTURA\w*)|(\w*Factura\w*)";
                    string CuentaC = @"(\w*CUENTA COBRO\w*)|(\w*Cuenta Cobro\w*)|(\w*CUENTA DE COBRO\w*)|(\w*Cuenta De Cobro\w*)|(\w*cuenta de cobro\w*)|(\w*Cuenta de Cobro\w*)|(\w*Cobro\w*)|(\w*COBRO\w*)|(\w*cobro\w*)";
                    string Ced = @"(\w*EXPEDICION\w*)|(\w*LUGAR\w*)|(\w*CEDULA\w*)|(\w*CIUDADANIA\w*)";
                    string RegisC = @"(\w*REGISTRO CIVIL\w*)|(\w*registro civil\w*)|(\w*CIVIL\w*)|(\w*REGISTRADURIA\w*)|(\w*registro\w*)";
                    string Otros = @"^(?!.\w*FACTURA\w*)|^(?!.\wFACTURA\w*)|^(?!.\wFactura\w*)|^(?!.\w*REGISTRO CIVIL\w*)|^(?!.\w*registro civil\w*)|^(?!.\w*EXPEDICION\w*)|^(?!.\w*LUGAR\w*)|^(?!.\w*CEDULA\w*)|^(?!.\w*NACIMIENTO\w*)|^(?!.\w*CIUDADANIA\w*)|^(?!.\w*CUENTA COBRO\w*)|^(?!.\w*Cuenta Cobro\w*)|^(?!.\w*CUENTA DE COBRO\w*)|^(?!.\w*Cuenta De Cobro\w*)|^(?!.\w*cuenta de cobro\w*)|^(?!.\w*Cuenta de Cobro\w*)|^(?!.\w*COBRO\w*)|^(?!.\w*Cobro\w*)|^(?!.\w*cobro\w*)";


                    //Expresiones regulares inmutables^(?!.

                    Regex regFact = new Regex(Factura);
                    Regex regCuC = new Regex(CuentaC);
                    Regex regCed = new Regex(Ced);
                    Regex regRegisC = new Regex(RegisC);
                    Regex regOtros = new Regex(Otros);

                    //Coincidencias//

                    MatchCollection matchFact = regFact.Matches(txt);
                    MatchCollection matchCuc = regCuC.Matches(txt);
                    MatchCollection matchCed = regCed.Matches(txt);
                    MatchCollection matchRegiC = regRegisC.Matches(txt);
                    MatchCollection matchOtros = regOtros.Matches(txt);

                    //Ubicacion de las carpetas //

                    urlFact = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Factura\";
                    urlCed = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Cedula\";
                    urlCuC = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Cuentadecobro\";
                    urlRegisC = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Registrocivil\";
                    urlOtros = @"C:\Users\Sena\source\repos\PROYECTOSENA\PROYECTOSENA\Documentos\Otros\";



                    //Concatenacion de la ubicacion de archivos y su nombre para su guardado//

                    UrlSaveFact = string.Concat(urlFact, onlyFileName);
                    UrlSaveCed = string.Concat(urlCed, onlyFileName);
                    UrlSaveCuC = string.Concat(urlCuC, onlyFileName);
                    UrlSaveRegisC = string.Concat(urlRegisC, onlyFileName);
                    UrlSaveOtros = string.Concat(urlOtros, onlyFileName);

                    //Decision de guardado dependiendo tipo de doc//

                    if (matchFact.Count > 0)
                    {
                        //Ingresamos a información de la acción la BD
                        SqlConnection sqlc = new SqlConnection();
                        SqlConnection cn = new SqlConnection();
                        cn.ConnectionString = "Data Source=DESKTOP-OI5HJE3;initial catalog=cdem;integrated security=true";
                        sqlc = cn;
                        sqlc.Open();
                        String db = "[dbo].[spInsertar]";

                        SqlCommand cmTP = new SqlCommand(db, sqlc);
                        cmTP.CommandType = System.Data.CommandType.StoredProcedure;

                        cmTP.Parameters.AddWithValue("@nombreDocumento", onlyFileName);
                        cmTP.Parameters.AddWithValue("@extension", extension);
                        cmTP.Parameters.AddWithValue("@usuario", lblUsuario.Text);
                        cmTP.Parameters.AddWithValue("@idCarpeta", 3);

                        cmTP.ExecuteNonQuery();

                        sqlc.Close();
                        sqlc.Dispose();

                        mycomputer.FileSystem.MoveFile(FileName, UrlSaveFact);

                    }
                    else if (matchCuc.Count > 0)
                    {
                        SqlConnection sqlc = new SqlConnection();
                        SqlConnection cn = new SqlConnection();
                        cn.ConnectionString = "Data Source=DESKTOP-OI5HJE3;initial catalog=cdem;integrated security=true";
                        sqlc = cn;
                        sqlc.Open();
                        String db = "[dbo].[spInsertar]";

                        SqlCommand cmTP = new SqlCommand(db, sqlc);
                        cmTP.CommandType = System.Data.CommandType.StoredProcedure;

                        cmTP.Parameters.AddWithValue("@nombreDocumento", onlyFileName);
                        cmTP.Parameters.AddWithValue("@extension", extension);
                        cmTP.Parameters.AddWithValue("@usuario", lblUsuario.Text);
                        cmTP.Parameters.AddWithValue("@idCarpeta", 2);

                        cmTP.ExecuteNonQuery();

                        sqlc.Close();
                        sqlc.Dispose();

                        mycomputer.FileSystem.MoveFile(FileName, UrlSaveCuC);

                    }
                    else if (matchCed.Count > 0)
                    {
                        SqlConnection sqlc = new SqlConnection();
                        SqlConnection cn = new SqlConnection();
                        cn.ConnectionString = "Data Source=DESKTOP-OI5HJE3;initial catalog=cdem;integrated security=true";
                        sqlc = cn;
                        sqlc.Open();
                        String db = "[dbo].[spInsertar]";

                        SqlCommand cmTP = new SqlCommand(db, sqlc);
                        cmTP.CommandType = System.Data.CommandType.StoredProcedure;

                        cmTP.Parameters.AddWithValue("@nombreDocumento", onlyFileName);
                        cmTP.Parameters.AddWithValue("@extension", extension);
                        cmTP.Parameters.AddWithValue("@usuario", lblUsuario.Text);
                        cmTP.Parameters.AddWithValue("@idCarpeta", 1);

                        cmTP.ExecuteNonQuery();

                        sqlc.Close();
                        sqlc.Dispose();

                        mycomputer.FileSystem.MoveFile(FileName, UrlSaveCed);
                    }
                    else if (matchRegiC.Count > 0)
                    {
                        SqlConnection sqlc = new SqlConnection();
                        SqlConnection cn = new SqlConnection();
                        cn.ConnectionString = "Data Source=DESKTOP-OI5HJE3;initial catalog=cdem;integrated security=true";
                        sqlc = cn;
                        sqlc.Open();
                        String db = "[dbo].[spInsertar]";

                        SqlCommand cmTP = new SqlCommand(db, sqlc);
                        cmTP.CommandType = System.Data.CommandType.StoredProcedure;

                        cmTP.Parameters.AddWithValue("@nombreDocumento", onlyFileName);
                        cmTP.Parameters.AddWithValue("@extension", extension);
                        cmTP.Parameters.AddWithValue("@usuario", lblUsuario.Text);
                        cmTP.Parameters.AddWithValue("@idCarpeta", 5);

                        cmTP.ExecuteNonQuery();

                        sqlc.Close();
                        sqlc.Dispose();

                        mycomputer.FileSystem.MoveFile(FileName, UrlSaveRegisC);
                    }
                    else if (matchOtros.Count > 0)
                    {
                        SqlConnection sqlc = new SqlConnection();
                        SqlConnection cn = new SqlConnection();
                        cn.ConnectionString = "Data Source=DESKTOP-OI5HJE3;initial catalog=cdem;integrated security=true";
                        sqlc = cn;
                        sqlc.Open();
                        String db = "[dbo].[spInsertar]";

                        SqlCommand cmTP = new SqlCommand(db, sqlc);
                        cmTP.CommandType = System.Data.CommandType.StoredProcedure;

                        cmTP.Parameters.AddWithValue("@nombreDocumento", onlyFileName);
                        cmTP.Parameters.AddWithValue("@extension", extension);
                        cmTP.Parameters.AddWithValue("@usuario", lblUsuario.Text);
                        cmTP.Parameters.AddWithValue("@idCarpeta", 4);

                        cmTP.ExecuteNonQuery();

                        sqlc.Close();
                        sqlc.Dispose();

                        mycomputer.FileSystem.MoveFile(FileName, UrlSaveOtros);
                    }


                }
            }


        }

    }

    }
