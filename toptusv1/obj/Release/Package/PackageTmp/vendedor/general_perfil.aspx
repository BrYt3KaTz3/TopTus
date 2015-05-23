<%@ Page Title="" Language="C#" MasterPageFile="~/vendedor/base_vendedor.Master" AutoEventWireup="true" CodeBehind="general_perfil.aspx.cs" Inherits="toptusv1.vendedor.general_perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Vendedor" runat="server">
     <div class="row">
         <h3 class="text-center">Resumen de tu información </h3>
        <div class="col-md-12" style="padding-bottom:30px;">
            <div class="col-md-7 col-xs-12 col-sm-8" style="border-left:1px #f2c2c2 solid;border-bottom:1px #f2c2c2 solid;border-radius:15px;padding:3px;">
                <h3>Información del vendedor</h3>
                <div class="col-sm-4  col-xs-12 col-md-4">
                    <img src="perfil/<%#imagen%>" alt="" class="img-rounded img-responsive" />
                    <a href="fotoperfil.aspx" class="text-info">(Editar foto)</a>
                    <br />
                    <%#fb.ToString()=="" ? "" :"<a href='"+fb+"' target='_blank'><img src='imagenes/iconos/facebook.png' width='25' height='25' /></a>" %>
                    <%#tw.ToString()=="" ? "" :"<a href='"+tw+"' target='_blank'><img src='imagenes/iconos/twitter.png' width='25' height='25'/></a>" %>
                    <%#gg.ToString()=="" ? "" :"<a href='"+gg+"' target='_blank'><img src='imagenes/iconos/google.png' width='25' height='25'/></a>" %>
                    <%#ins.ToString()=="" ? "" :"<a href='"+ins+"' target='_blank'><img src='imagenes/iconos/instagram.png'width='25' height='25' /></a>" %>
                    <%#lk.ToString()=="" ? "" :"<a href='"+lk+"' target='_blank'><img src='imagenes/iconos/linked.png' width='25' height='25'/></a>" %>
                    <br />
                    <a href="socialmedia.aspx" class="text-info">(Editar redes sociales)</a>
                </div>
                <div class="col-sm-8 col-md-8 col-xs-12">
                    <blockquote>
                        <p><%#nombre %></p>
                        <p><%#nick %></p>
                        <small><cite title="Source Title"> <%#estado %>,<%#pais %> <i class="glyphicon glyphicon-map-marker"></i></cite></small>
                    </blockquote>
                    <p>
                        <i class="glyphicon glyphicon-envelope"></i> <%#email %>
                        <br />
                        <i class="glyphicon glyphicon-globe"></i> <%#empresa %>
                        <br />
                        <i class="glyphicon glyphicon-gift"></i> Vendedor <%#tipov %>
                         <br />
                        <i class="glyphicon glyphicon-user"></i> Miembro desde: <%#ingreso %>
                    </p>
                     <a href="vendedor_perfil.aspx" class="text-info">(Editar información básica)</a>

                </div>
            </div>

            <div class="col-md-5 col-sm-4 col-xs-12" style="border-left:1px #f2c2c2 solid;border-bottom:1px #f2c2c2 solid;border-radius:15px;padding:3px;">

                <h3>Tus productos:</h3>

                <div class="col-sm-12 col-md-12">
                    <asp:Label runat="server" id="nohay"></asp:Label>
                    <ul>
                        <asp:Repeater ID="rpt_mas_productos" runat="server">
                            <ItemTemplate>
                                <li><a href="productdetail.aspx?prod=<%#Eval("producto_id") %>"><%#Eval("producto") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <a href="productos.aspx" class="text-info">(Editar productos)</a>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
