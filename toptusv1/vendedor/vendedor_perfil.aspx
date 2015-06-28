<%@ Page Title="" Language="C#" MasterPageFile="~/vendedor/base_vendedor.Master" AutoEventWireup="true" CodeBehind="vendedor_perfil.aspx.cs" Inherits="toptusv1.vendedor.vendedor_perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/vendedor_perfil.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Vendedor" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <div class="row">
       
       
       <div class="col-md-8 col-lg-8 col-xs-8 col-md-offset-4"><h3>Información Básica</h3></div>
       
   </div>

      <asp:Panel ID="Panel1" runat="server" DefaultButton="btn_actualizar_vendedor_basico">
     <div class="row" >
            <div class="col-md-10 col-md-offset-2" id="formulario_vendedor_basico">
                <div class="form-group">
                    <label for="ven_nombre" class="col-lg-2 control-label">*Nombre de Usuario:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_nick" type="text" CssClass="form-control input_form"  placeholder="Nickname" runat="server" ></asp:TextBox>
                      
                    </div>
                </div>
                <br />

                <div class="form-group">
                    <label for="ven_nombre" class="col-lg-2 control-label">*Nombre(s):</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_nombre" type="text" CssClass="form-control input_form"  placeholder="Nombre(s)" runat="server" ></asp:TextBox>
                      
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <label for="ven_apellidop" class="col-lg-2 control-label">*Apellido Paterno:</label>
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
                    <label for="ven_email" class="col-lg-2 control-label">*Email:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_email"  type="email" CssClass ="form-control"  placeholder="Email " runat="server" Enabled="False"></asp:TextBox>
                      
                    </div>
                </div>
                 <br />
                  <div class="form-group">
                    <label for="ven_email" class="col-lg-2 control-label">Miembro desde: (mm/dd/aaaa)</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_fechaingreso"  type="email" CssClass ="form-control"  placeholder="Fecha de ingreso " runat="server" Enabled="False"></asp:TextBox>
                      
                    </div>
                </div>
                 <br />
                <div class="form-group">
                    <label for="ven_email" class="col-lg-2 control-label">*Nombre de su Empresa:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_empresa"   CssClass ="form-control"  placeholder="Empresa " runat="server" ></asp:TextBox>
                      
                    </div>
                </div>
                 <br /> 
                  <div class="form-group">
                    <label for="ven_email" class="col-lg-2 control-label">RFC:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_rfc"   CssClass ="form-control"  placeholder="RFC " runat="server" ></asp:TextBox>
                      
                    </div>
                </div>
               
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                        <label for="ven_pais" class="col-lg-2 control-label">*País:</label>
                        <div class="col-lg-6">
                          <asp:DropDownList ID="ddlpais"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlpais_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        </div>
                         <br />
                         <br /> 
                        <div class="form-group">
                        <label for="ven_estado" class="col-lg-2 control-label">*Estado:</label>
                        <div class="col-lg-6">
                          <asp:DropDownList ID="ddlestado" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </div>
                        </div>

                    </ContentTemplate>

                </asp:UpdatePanel>
                <br />
                  <div class="form-group">
                    <label for="ven_email" class="col-lg-2 control-label">*Ciudad:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_ciudad"   CssClass ="form-control"  placeholder="Ciudad" runat="server" ></asp:TextBox>
                      
                    </div>
                </div>

                <br /> 
                  <div class="form-group">
                    <label for="ven_email" class="col-lg-2 control-label">Colonia:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_colonia"   CssClass ="form-control"  placeholder="Colonia " runat="server" ></asp:TextBox>
                      
                    </div>
                </div>
                <br />
                  <div class="form-group">
                    <label for="ven_email" class="col-lg-2 control-label">Calle:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_calle"   CssClass ="form-control"  placeholder="Calle " runat="server" ></asp:TextBox>
                      
                    </div>
                </div>

                <br /> 
                  <div class="form-group">
                    <label for="ven_email" class="col-lg-2 control-label">Número Exterior:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_num"   CssClass ="form-control"  placeholder="Número Ext. " runat="server" ></asp:TextBox>
                      
                    </div>
                </div>

                <br /> 
                  <div class="form-group">
                    <label for="ven_email" class="col-lg-2 control-label">Número Interior:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="ven_num_int"   CssClass ="form-control"  placeholder="Número Int. " runat="server" ></asp:TextBox>
                      
                    </div>
                </div>
                 <br /> 
                  <div class="form-group">
                      <div class="row">
                      <label for="ven_email" class="col-md-2  control-label">Lada País:</label>
                      <div class="col-md-6 ">
                      <asp:TextBox ID="ven_lada_pais"   CssClass ="form-control"  placeholder="Lada País" runat="server" ></asp:TextBox>
                      </div>
                      </div> 
                      
                      <div class="row">
                       <label for="ven_email" class="col-md-2 control-label">Lada Ciudad:</label>
                      <div class="col-md-6 ">
                      <asp:TextBox ID="ven_lada_ciudad"   CssClass ="form-control"  placeholder="Lada Ciudad. " runat="server" ></asp:TextBox>
                      </div></div>

                      <div class="row">
                          <label for="ven_email" class="col-md-2 control-label">Teléfono:</label>
                           <div class="col-md-6 ">
                      <asp:TextBox ID="ven_telefono"   CssClass ="form-control"  placeholder="Teléfono." runat="server" ></asp:TextBox>
                      </div>
                      </div>
                     
                      <div class="row">
                           <label for="ven_email" class="col-md-2 control-label">Extensión:</label>
                       <div class="col-md-6 ">
                      <asp:TextBox ID="ven_extension"   CssClass ="form-control"  placeholder="Extensión. " runat="server" ></asp:TextBox>
                      </div>
                         </div> 
                    
                      
                      </div>
                         
                      
                      
                     
                           
                   
                    
                      </div>
                </div>
                 <br /> 
                 
                 <br />
                  <div class="form-group">
                    <div class="col-lg-offset-2 col-lg-10">
                      
                            <asp:Button  ClientIDMode="Static" ID="btn_actualizar_vendedor_basico" CssClass="btn-danger btn" runat="server" Text="Actualizar Información" OnClick="btn_actualizar_vendedor_basico_Click" />
                        
                        
                    </div>
                  </div>

           

</asp:Panel>

    
    
    <div id="loader">
        <label>Procesando solicitud</label>
    <img src="../imagenes/ajax-loader.gif" alt="loading"/><br/>
        </div>

</asp:Content>
