<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="toptusv1.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Login/login.css" rel="stylesheet" />
    <script src="Login/login.js"></script>
    <link href="vendedor/css/jquery-ui.css" rel="stylesheet" />
    <script src="vendedor/js/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row" style="padding-top:80px; padding-bottom:80px;">
        <div class="col-md-4 col-md-offset-4">
            <div class="panel panel-default">
                <div class="panel-body">
                    <h4 style="border-bottom: 1px solid #c5c5c5;" class="text-center">
                        <i class="glyphicon glyphicon-user"></i>
                        Entrar
                    </h4>
                    <div style="padding: 20px;" id="form-login">
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon1"><span class="glyphicon glyphicon-envelope"></span>
                            </span>

                            <asp:TextBox ID="log_usuario" CssClass="form-control" runat="server" placeholder="Correo electrónico"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon1"><span class="glyphicon glyphicon-lock"></span></span>
                            <asp:TextBox ID="log_password" type="password" CssClass="form-control" runat="server" placeholder="Contraseña"></asp:TextBox>
                            
                        </div>
                    </div>

                 
               
                <asp:Button ID="Button1" runat="server" CssClass="button-link btn btn-sm btn-danger btn-block" Text="INGRESAR" OnClick="Button1_Click" />
             </asp:Panel>  
                        <a href="#" id="olvidado" class=" pull-right">Olvidaste tu contraseña?</a>
                         </div>
                    <asp:Panel ID="Panel2" runat="server" DefaultButton="btnRecuperar">
                       
                   
                    <div style="display: none;" id="form-olvidado">
                        <h4 class="">Olvidaste tu contraseña?
                        </h4>

                       
                            <span class="help-block">Teclea el correo que usas para entrar a tu cuenta.
          <br/>
                                Enviaremos tu información de acceso vía correo electrónico.
                            </span>
                            <div class="form-group input-group">
                                <span class="input-group-addon">@
                                </span>
                               <asp:TextBox ID="txtcorreo" type="correo" CssClass="form-control" runat="server" placeholder="correo"></asp:TextBox>
                            </div>
                            

                             <asp:Button  ID="btnRecuperar" runat="server" CssClass="button-link btn btn-sm btn-danger btn-block" Text="RECUPERAR" OnClick="btnRecuperar_Click"  />

                            <p class="help-block">
                                <a class="pull-right" href="#" id="acceso">Entra a tu cuenta</a>
                            </p>
                      

                    </div>
                </asp:Panel>
                </div>
            </div>


        </div>
    </div>

        <div id="dialog-message-error" title="Error" style="display:none">
            <p>
                <span class="ui-icon ui-icon-circle-check" style="float: left; margin: 0 7px 50px 0;"></span>
                Usuario no encontrado en el sistema.
            </p>
         
        </div>

          <div id="dialog-recuperacion-ok" title="Todo salió bien" style="display:none">
            <p>
                <span class="ui-icon ui-icon-circle-check" style="float: left; margin: 0 7px 50px 0;"></span>
               Se ha enviado la información de acceso al correo proporcionado.
            </p>
         
        </div>

        <div id="dialog_error_2" title="Algo ha ocurrido" style="display:none">
            <p>
                <span class="ui-icon ui-icon-circle-check" style="float: left; margin: 0 7px 50px 0;"></span>
            No hemos podido enviar la información a su correo, intente más tarde.
            </p>
         
        </div>

        <div id="loader">
        <label>Procesando solicitud</label>
    <img src="../imagenes/ajax-loader.gif" alt="loading"/><br/>
        </div>

    </div>
</asp:Content>
