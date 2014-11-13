<%@ Page Title="" Language="C#" MasterPageFile="~/vendedor/base_solicitud.Master" AutoEventWireup="true" CodeBehind="solicitud.aspx.cs" Inherits="toptusv1.vendedor.solicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    
    <script src="js/solicitud.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div  id="div_solicitud">
          <div class="row">
              <div class="col-md-12 col-md-offset-2">
                   <h1>Solicitud de Ingreso</h1>
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
    <div id="loader">
        <label>Procesando solicitud</label>
    <img src="../imagenes/ajax-loader.gif" alt="loading"/><br/>
    
   
</div>
</asp:Content>
