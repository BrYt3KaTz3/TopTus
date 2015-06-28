<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="confirmacion.aspx.cs" Inherits="toptusv1.confirmacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-12">

        <div class="row">

            <div class="col-md-6 col-md-offset-3 text-center " runat="server" id="simail">
                
                <h3 class="text-danger">Hace falta un paso más</h3>
                <h5 class="text-justify">Hemos envíado un correo de bienvenida y confirmación a <span class="text-info"> <%#correo %></span> , sigue las instrucciones y comienza tu aventura en Toptus !!</h5>
                <p class="text-justify text-muted"><small>Si no recibes tu correo de bienvenida en un plazo de 15 minutos, envíanos un mensaje a <a href="mailto:soporte@toptus.com">soporte@toptus.com</a> con el mail que registraste.</small>
                 
                </p>

                <img src="imagenes/BienvenidoTopTus.png" class="img-responsive text-center" />

            </div>
              <div class="col-md-6 col-md-offset-3 text-center " runat="server" id="nomail">

                 <h3 class="text-danger">Hace falta un paso más</h3>
                <h5 class="text-justify">Se ha procesado la solicitud de <span class="text-info"> <%#correo %> </span>, desafortunadamente el correo de bienvenida no pudo ser envíado,
                    manda un mensaje a <a href="mailto:soporte@toptus.com">soporte@toptus.com</a> y te diremos los pasos a seguir.
                </h5>
                
                <img src="imagenes/BienvenidoTopTus.png" class="img-responsive" />
            </div>


        </div>


    </div>

</asp:Content>
