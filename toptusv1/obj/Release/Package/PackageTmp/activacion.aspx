<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="activacion.aspx.cs" Inherits="toptusv1.activacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-12">


        <div class="col-md-6 col-md-offset-2 text-center"  runat="server" id="noactivada" style="padding:20px">
            Hola <span class="text-info"> <%#correo %></span> , da click en el siguiente botón para activar tu cuenta en Toptus.
            <br /><br />
            <asp:Button ID="btnActivar" OnClick="btnActivar_Click" runat="server" CssClass="btn-danger btn" style="padding:15px" Text="ACTIVAR MI CUENTA" />
            <br /><br />
            <span class="text-center">cualquier duda comunicate  <a href="mailto:soporte@toptus.com">soporte@toptus.com</a></span>
        </div>

        <div class="col-md-6 col-md-offset-2" runat="server" id="activada">
             Hola <span class="text-info"> <%#correo %></span> , tu cuenta ya está activada, cualquier duda comunicate  <a href="mailto:soporte@toptus.com">soporte@toptus.com</a>
        </div>


         <div id="dialog-message-activacion" title="Mensaje" style="display:none;">
  <p id="mensaje">
    
    
  </p>
  <p>
    <b>Presione OK para continuar.</b>
  </p>
</div>


    </div>

    

</asp:Content>
