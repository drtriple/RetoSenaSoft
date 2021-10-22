<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cpanel.aspx.cs" Inherits="PROYECTOSENA.Views.interaz.cpanel" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <!-- Required meta tags -->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>CDEM | INICIO</title>
    <!-- base:css -->
    <link rel="stylesheet" href="vendors/mdi/css/materialdesignicons.min.css" />
    <link rel="stylesheet" href="vendors/base/vendor.bundle.base.css" />
    <!-- endinject -->
    <!-- plugin css for this page -->
    <!-- End plugin css for this page -->
    <!-- inject:css -->
    <link rel="stylesheet" href="css/stylePanel.css" />
    <!-- endinject -->
    <link rel="shortcut icon" href="images/favicon.png" />


    <!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
  </head>
  <body>
    <div class="container-scroller">
			
		<!-- partial:partials/_horizontal-navbar.html -->
    <div class="horizontal-menu">
      <nav class="navbar top-navbar col-lg-12 col-12 p-0">
        <div class="container-fluid">
          <div class="navbar-menu-wrapper d-flex align-items-center justify-content-between">
            <ul class="navbar-nav navbar-nav-left">
             
              <li class="nav-item dropdown">
                <a class="nav-link count-indicator dropdown-toggle d-flex align-items-center justify-content-center" id="notificationDropdown" href="#" data-toggle="dropdown">
                  <i class="mdi mdi-bell mx-0"></i>
                  <span class="count bg-success">#</span>
                </a>
                <div class="dropdown-menu dropdown-menu-right navbar-dropdown preview-list" aria-labelledby="notificationDropdown">
                  <p class="mb-0 font-weight-normal float-left dropdown-header">Notificaciones</p>
                  <a class="dropdown-item preview-item">
                    <div class="preview-thumbnail">
                        <div class="preview-icon bg-success">
                          <i class="mdi mdi-information mx-0"></i>
                        </div>
                    </div>
                    <div class="preview-item-content">
                       <asp:Label runat="server" ID="lblPrueba" Text=""></asp:Label>
                        <p class="font-weight-light small-text mb-0 text-muted">
                          Justo ahora
                        </p>
                    </div>
                  </a>
                 
               
                </div>
              </li>
           
             
              <li class="nav-item nav-search d-none d-lg-block ml-3">
                <div class="input-group">
                    <div class="input-group-prepend">
                      <span class="input-group-text" id="search">
                        <i class="mdi mdi-magnify"></i>
                      </span>
                    </div>
                    <input type="text" class="form-control" placeholder="Buscar" aria-label="search" aria-describedby="search" />
                </div>
              </li>	
            </ul>
            <div class="text-center navbar-brand-wrapper d-flex align-items-center justify-content-center">
                <a class="navbar-brand brand-logo" href="cpanel.html"><img src="images/logo.png" alt="logo"/></a>
                <a class="navbar-brand brand-logo-mini" href="cpanel.html"><img src="images/logo.png" alt="logo"/></a>
            </div>
            <ul class="navbar-nav navbar-nav-right">
                
              
                <li class="nav-item nav-profile dropdown">
                  <a class="nav-link dropdown-toggle" href="#" data-toggle="dropdown" id="profileDropdown">
                    <asp:Label ID="lblUsuario" Cssclass="nav-profile-name" runat="server" Text=" "></asp:Label>
                    <span class="online-status"></span>
                    <img src="images/user.png" alt="profile"/>
                  </a>
                  <div class="dropdown-menu dropdown-menu-right navbar-dropdown" aria-labelledby="profileDropdown">
                    
                      
                  </div>
                </li>
            </ul>
            <button class="navbar-toggler navbar-toggler-right d-lg-none align-self-center" type="button" data-toggle="horizontal-menu-toggle">
              <span class="mdi mdi-menu"></span>
            </button>
          </div>
        </div>
      </nav>
      <nav class="bottom-navbar">
        <div class="container">
            <ul class="nav page-navigation">
              <li class="nav-item">
                <a class="nav-link" href="cpanel.aspx">
                  <i class="mdi mdi-file-document-box menu-icon"></i>
                  <span class="menu-title">Subir</span>
                </a>
              </li>
              <li class="nav-item">
                  <a href="cpanel-carpetas.aspx" class="nav-link">
                    <i class="mdi mdi-folder-multiple menu icon"></i>
                    <span class="menu-title">Carpetas</span>
                    <i class="menu-arrow"></i>
                  </a>
                 
              </li>
              
              
              <li class="nav-item">
                  <a href="cpanel-historial.aspx" class="nav-link">
                    <i class="mdi mdi-account-search menu icon"></i>
                    <span class="menu-title">Historial</span>
                    <i class="menu-arrow"></i>
                  </a>
              </li>
            
                       
            
            </ul>
        </div>
      </nav>
    </div>
    <!-- partial -->
		<div class="container-fluid page-body-wrapper">
			<div class="main-panel">
				<div class="content-wrapper">
					<div class="row">
						<div class="col-sm-6 mb-4 mb-xl-0">
							<div class="d-lg-flex align-items-center">
								<div>
									<h3 class="text-dark font-weight-bold mb-2">Hola, bienvenido CDEM!</h3>
									<h6 class="font-weight-normal mb-2">Inicio realizado </h6>
								</div>
								
							</div>
						</div>
						<div class="col-sm-6">
							<div class="d-flex align-items-center justify-content-md-end">
							
								<div class="pr-1 mb-3 mb-xl-0">
										<button type="button" class="btn btn-outline-inverse-info btn-icon-text">
											Ayuda
											<i class="mdi mdi-help-circle-outline btn-icon-append"></i>                          
									</button>
								</div>
								
							</div>
						</div>
					</div>
					<div class="row mt-4">
						<div class="col-lg-8 grid-margin stretch-card">
							<div class="card">
								<div class="card-body">
									<div class="row">
										<div class="col-lg-12">
                                           
       
                                                 <form runat="server" class="form-group"> 
                                                    
                                                     <div style="padding-left: 40rem !important;">

                                                           <asp:Button ID="BtnCerrar" runat="server" Text="Cerrar sesión" OnClick="BtnCerrar_Click" />
                                                  
                      </div>

                                                      <h4 class="card-title">Subir archivos</h4>

                                                      <label>Cargar archivos</label>
                                                   
                                                    <div class="input-group col-xs-12">
                                                      <asp:FileUpload ID="FileUpload1" runat="server" Cssclass="form-control file-upload-info"  multiple="multiple"  />
                                                     
                                                    </div>

                                                     <br>

                                                       <asp:Button ID="SubirArchivo" runat="server" Cssclass="btn btn-primary mr-2" Text="Subir un archivo" Onclick="SubirArchivo_Click" />
                                                
                                                 <br> <br>

                                                      <asp:Button ID="CargarVariosArchivos" runat="server" Cssclass="btn btn-primary mr-2" Text="Generar Repositorio de varios archivos" Onclick="CargarVariosArchivos_Click" />
                                                


                                                     <asp:Label ID="lbMensajeArchivo" runat="server" Text="" ></asp:Label>

                                                        </form>
                                                   
                                           
										</div>
										
									
									</div>
								</div>
							</div>
						</div>
						<div class="col-lg-4 mb-3 mb-lg-0">
                                <div class="card bg-primary">
										<div class="card-body text-white">
											<h3 class="font-weight-bold mb-3">18,39 (75GB)</h3>
											<div class="progress mb-3">
												<div class="progress-bar  bg-warning" role="progressbar" style="width: 40%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
											</div>
                                            <p class="pb-0 mb-0">Almacenamiento usado</p>
                                            <br/>
                                            <h4 class="font-weight-bold mb-3">Número de archivos: </h4>
                                            <asp:Label runat="server" ID="LabelCantidadArchivos" Text=""></asp:Label>
                                          
										</div>
									</div>
						</div>
                    </div>
                    

					
				</div>
			
				<footer class="footer">
          <div class="footer-wrap">
            <div class="d-sm-flex justify-content-center justify-content-sm-between">
              <span class="text-muted d-block text-center text-sm-left d-sm-inline-block">Copyright © CENTRO DE SERVICIOS Y GESTIÓN EMPRESARIAL | REGIONAL ANTIOQUIA 2021</span>
              <span class="float-none float-sm-right d-block mt-1 mt-sm-0 text-center">  <a href="" target="_blank">CDEM </a></span>
            </div>
          </div>
        </footer>
				<!-- partial -->
			</div>
			<!-- main-panel ends -->
		</div>
		<!-- page-body-wrapper ends -->
    </div>
		<!-- container-scroller -->
    <!-- base:js -->
    <script src="vendors/base/vendor.bundle.base.js"></script>
    <!-- endinject -->
    <!-- Plugin js for this page-->
    <!-- End plugin js for this page-->
    <!-- inject:js -->
    <script src="js/control.js"></script>
    <!-- endinject -->
    <!-- plugin js for this page -->
    <!-- End plugin js for this page -->
    
    
	
		
    <!-- Custom js for this page-->
    <script src="js/dashboard.js"></script>
    <!-- End custom js for this page-->

    <!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
  </body>
</html>
