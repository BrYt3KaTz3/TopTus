<%@ Page Title="" Language="C#" MasterPageFile="~/vendedor/base_vendedor.Master" AutoEventWireup="true" CodeBehind="vendedor_perfil.aspx.cs" Inherits="toptusv1.vendedor.vendedor_perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Vendedor" runat="server">

   <div class="row">
       
       <div class="col-md-8 col-lg-8 col-xs-8 col-md-offset-4"><h3>Basic Information</h3></div>
       
   </div>


     <div class="row">
            <div class="col-md-10 col-md-offset-2" id="formulario_vendedor_basico">

                <div class="form-group">
                    <label for="ven_nombre" class="col-lg-2 control-label">Nombre(s):</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_nombre" type="text" CssClass="form-control input_form"  placeholder="Nombre(s)" runat="server" ></asp:TextBox>
                      
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <label for="ven_apellidop" class="col-lg-2 control-label">Apellido Paterno:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_apellidop" type="text" CssClass="form-control"  placeholder="Apellido Paterno" runat="server"></asp:TextBox>
                      
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <label for="ven_apellidom" class="col-lg-2 control-label">Apellido Materno:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_apellidom" type="text" CssClass="form-control" placeholder="Apellido Materno " runat="server"></asp:TextBox>
                      
                    </div>
                </div>
                <br />
                  <div class="form-group">
                    <label for="ven_email" class="col-lg-2 control-label">Email:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_email" type="email" CssClass ="form-control"  placeholder="Email " runat="server"></asp:TextBox>
                      
                    </div>
                </div>

                 <br />
                  <div class="form-group">
                    <div class="col-lg-offset-2 col-lg-10">
                      
                        <asp:Button  ClientIDMode="Static" ID="btn_actualizar_vendedor_basico" CssClass="btn btn-default" runat="server" Text="Enviar" />
                    </div>
                  </div>

            </div>
        </div>



    
    
    <div id="loader">
        <label>Procesando solicitud</label>
    <img src="../imagenes/ajax-loader.gif" alt="loading"/><br/>
        </div>

</asp:Content>
