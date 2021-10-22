<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PROYECTOSENA.Views.interaz.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 
  
    <title>CDEM</title>

    <!-- Font Icon -->
    <link rel="stylesheet" href="fonts/material-icon/css/material-design-iconic-font.min.css"/>

    <!-- Main css -->
    <link rel="stylesheet" href="css/style.css"/>
</head>
<body>
    <br/><br/>
        <!-- Sing in  Form -->
        <section class="sign-in">
            <div class="container">
                <div class="signin-content">
                    <div class="signin-image">

                            <img src="images/logo.png" alt="sing up image"/>
                        <figure><img src="images/signin-image.png" alt="sing up image"/></figure>

                     
                       
                    </div>

                    <div class="signin-form">
                        <h2 class="form-title">Iniciar sesión</h2>
                        <h3>CDEM</h3>

                        <form runat="server" class="register-form" id="login">

                            <div class="form-group">
                                <label for="username"><i class="zmdi zmdi-account material-icons-name"></i></label>
                               
                               <asp:TextBox ID="TextBox1" placeholder="usuario" CssClass="form-control" runat="server"></asp:TextBox>
                            
                            </div>
                            <p id="retorno"></p>
                            <p id="retorno2"></p>
                           

                            <div class="form-group">
                                <label for="pass"><i class="zmdi zmdi-lock"></i></label>
                                <asp:TextBox ID="TextBox2" type="password" placeholder="Contraseña" CssClass="form-control" runat="server"></asp:TextBox>

                               
                            </div>
                            <p id="input-error"></p>
                            <p id="input-error2"></p>

                            <div class="form-group form-button">
                                    
                                <asp:Button ID="Button1" runat="server" CssClass="form-submi" Text="Login" OnClick="validar" />

                                <asp:Label runat="server" ID="lblError"></asp:Label>
                                
                            </div>
                        </form>
                        
                    </div>
                </div>
            </div>
        </section>

   
    <!-- JS -->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="js/main.js"></script>
</body>
</html>