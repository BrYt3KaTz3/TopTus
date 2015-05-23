<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="contacto.aspx.cs" Inherits="toptusv1.contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
     <div class="col-md-offset-4 col-md-4row"><h3>Contacto</h3></div>
    <div class="row"><h4 class="text-center">Por favor llena el siguiente formulario de contacto:</h4></div>
           <div class="row">
            <div class="col-md-10 col-md-offset-2" id="formulario_solicitud">

                <div class="form-group">
                    <div class="row">
                        <label for="con_nombre" class="col-lg-2 col-md-2 control-label">Nombre:</label>
                        <div class="col-lg-6 col-md-6">
                            <asp:TextBox ID="con_nombre" type="text" CssClass="form-control input_form" placeholder="Nombre" runat="server"></asp:TextBox>

                        </div>
                    </div>
                    <div class="row padding_inicio">
                        <label for="con_empresa" class="col-lg-2 col-md-2 control-label">Empresa:</label>
                        <div class="col-lg-6 col-md-6">
                            <asp:TextBox ID="con_empresa" type="text" CssClass="form-control input_form" placeholder="Empresa" runat="server"></asp:TextBox>

                        </div>
                    </div>
                     <div class="row padding_inicio">
                        <label for="con_direccion" class="col-lg-2 col-md-2 control-label">Dirección:</label>
                        <div class="col-lg-6 col-md-6">
                            <asp:TextBox ID="con_direccion" type="text" CssClass="form-control input_form" placeholder="Dirección" runat="server"></asp:TextBox>

                        </div>
                    </div>

                     <div class="row padding_inicio">
                        <label for="con_pais" class="col-lg-2 col-md-2 control-label">País:</label>
                        <div class="col-lg-6 col-md-6">
                            <asp:TextBox ID="con_pais" type="text" CssClass="form-control input_form" placeholder="País" runat="server"></asp:TextBox>

                        </div>
                    </div>

                     <div class="row padding_inicio">
                        <label for="con_ciudad" class="col-lg-2 col-md-2 control-label">Ciudad:</label>
                        <div class="col-lg-6 col-md-6">
                            <asp:TextBox ID="con_ciudad" type="text" CssClass="form-control input_form" placeholder="Ciudad" runat="server"></asp:TextBox>

                        </div>
                    </div>

                     <div class="row padding_inicio">
                        <label for="con_tel" class="col-lg-2 col-md-2 control-label">Teléfono:</label>
                        <div class="col-lg-6 col-md-6">
                            <asp:TextBox ID="con_tel" type="text" CssClass="form-control input_form" placeholder="Teléfono" runat="server"></asp:TextBox>

                        </div>
                    </div>

                     <div class="row padding_inicio">
                        <label for="con_mail" class="col-lg-2 col-md-2 control-label">Mail:</label>
                        <div class="col-lg-6 col-md-6">
                            <asp:TextBox ID="con_mail" type="mail" CssClass="form-control input_form" placeholder="Email" runat="server"></asp:TextBox>

                        </div>
                    </div>

                     <div class="row padding_inicio">
                        <label for="con_comentario" class="col-lg-2 col-md-2 control-label">Comentario:</label>
                        <div class="col-lg-6 col-md-6">
                            <asp:TextBox ID="con_comentario" type="text" TextMode="MultiLine" CssClass="form-control input_form" placeholder="Comentario" runat="server"></asp:TextBox>

                        </div>
                    </div>

                     <div class="row padding_inicio">
                              <div class="col-lg-6 col-md-6 col-md-offset-2">
                                  <asp:Button ID="btnComentario" OnClick="btnComentario_Click" runat="server" CssClass="btn"  Text="Enviar" />
                        </div>
                    </div>


                </div>


            </div>
        </div>
        </div>

     <div id="dialogcomentario" title="Confirmación" style="display:none">
  <p> Se ha enviado su mensaje, en breve será atendido.</p>
</div>
    <div id="loader">
        <label>Enviando mensaje</label>
    <img src="../imagenes/ajax-loader.gif" alt="loading"/><br/>
    
   
</div>

</asp:Content>
