<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="solicitud.aspx.cs" Inherits="toptusv1.vendedor.solicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    
    <script src="Scripts/solicitud.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   
	<div class="row">
        	<div class="col-md-6">
				
					<!-- PRICE ITEM -->
					<div class="panel price panel-grey">
						<div class="panel-heading arrow_box text-center">
						<h3>PLAN LIGHT</h3>
						</div>
						<div class="panel-body text-center">
							<p class="lead" style="font-size:40px"><strong>$0<br /> <span class="text-muted texto_pequeño">pesos mexicanos</span><br /> mes</strong></p>
						</div>
						<ul class="list-group list-group-flush text-center">
							<li class="list-group-item"><i class="icon-ok text-success"></i> Hasta 5 productos a ofrecer</li>
							<li class="list-group-item"><i class="icon-ok text-success"></i> 2 fotos por producto</li>
							<li class="list-group-item"><i class="icon-ok text-success"></i> Hasta 3 categorías por producto</li>
                            <li class="list-group-item"><i class="icon-ok text-danger"></i>Completamente gratis</li>
						</ul>
						<div class="panel-footer">
							<a class="btn  btn-block btn-danger" href="#">OBTENER</a>
						</div>
					</div>
					<!-- /PRICE ITEM -->
					
					
				</div>

    			<div class="col-md-6">
				
					<!-- PRICE ITEM -->
					<div class="panel price panel-red">
						<div class="panel-heading  text-center">
						<h3>PLAN PREMIUM</h3>
						</div>
						<div class="panel-body text-center">
							<p class="lead" style="font-size:40px"><strong>$99.99<br /> <span class="text-muted texto_pequeño">pesos mexicanos</span> <br /> mes</strong></p>
						</div>
						<ul class="list-group list-group-flush text-center">
							<li class="list-group-item"><i class="icon-ok text-danger"></i> Sin límite de productos</li>
							<li class="list-group-item"><i class="icon-ok text-danger"></i> Sin límite de categorías</li>
							<li class="list-group-item"><i class="icon-ok text-danger"></i> Hasta 5 fotos por producto</li>
                            <li class="list-group-item"><i class="icon-ok text-danger"></i> Chat de negocios</li>
						</ul>
						<div class="panel-footer">
							<a class="btn  btn-block btn-danger" href="#">OBTENERLO YA</a>
						</div>
					</div>
					<!-- /PRICE ITEM -->
					
					
				</div>
				
			
				
				
				
			
				
				
				
			</div>
            




    <div  id="div_solicitud">
          <div class="row">
              <div class="col-md-10 col-md-offset-2">
                   <h3>Solicitud de Ingreso</h3>
                   <p>
                    Favor de llenar los campos siguientes para comenzar el proceso de solicitud.
                   </p>
                  
               </div>
              
              
           </div>
        <div class="row">
            <div class="col-md-12 col-md-offset-2" id="formulario_solicitud">

                <div class="form-group">
                    <label for="sol_nombre" class="col-lg-2 control-label">Nombre(s):</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="sol_nombre" type="text" CssClass="form-control input_form"  placeholder="Nombre(s)" runat="server" ></asp:TextBox>
                      
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <label for="sol_apellidop" class="col-lg-2 control-label">Apellido Paterno:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="sol_apellidop" type="text" CssClass="form-control"  placeholder="Apellido Paterno" runat="server"></asp:TextBox>
                      
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <label for="sol_apellidom" class="col-lg-2 control-label">Apellido Materno:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="sol_apellidom" type="text" CssClass="form-control" placeholder="Apellido Materno " runat="server"></asp:TextBox>
                      
                    </div>
                </div>
                <br />
                  <div class="form-group">
                    <label for="sol_email" class="col-lg-2 control-label">Email:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="sol_email" type="email" CssClass ="form-control"  placeholder="Email " runat="server"></asp:TextBox>
                      
                    </div>
                </div>
                 <br />
                <div class="form-group">
                    <label for="sol_email" class="col-lg-2 control-label">Contraseña:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="sol_pass" type="password" CssClass ="form-control"  placeholder="Contraseña " runat="server"></asp:TextBox>
                      
                    </div>
                </div>

                 <br />
                  <div class="form-group">
                    <div class="col-lg-offset-2 col-lg-10">
                      
                        <asp:Button  ClientIDMode="Static" ID="btn_enviar_solicitud" CssClass="btn btn-default" runat="server" Text="Enviar" OnClick="btn_enviar_solicitud_Click" />
                    </div>
                  </div>

            </div>
        </div>
          


       </div> 
    <%--
    <script type="text/javascript">
        $(document).ready(function () {
            $("#form_solicitud").validate({

                rules: {
                    <%=sol_nombre.UniqueID %>: 
                    {
                        minlength: 2,
                        required: true
                    },
                }, //rules
                messages: {
                    <%=sol_nombre.UniqueID %>:
                    { 
                        required: "* Campo Requerido*", 
                        minlength: "* Por favor digitar al menos 2 caracteres *" 
                    }
                }
            })
        }); con esto sirve local, o sea con el código aquí

    </script> --%>
    
    <div id="dialog" title="Confirmación" style="display:none">
  <p> La solicitud ha sido procesada correctamente, se ha enviado un email al correo registrado</p>
</div>
    <div id="loader">
        <label>Procesando solicitud</label>
    <img src="../imagenes/ajax-loader.gif" alt="loading"/><br/>
    
   
</div>
</asp:Content>
