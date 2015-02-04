<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="perfilvendedor.aspx.cs" Inherits="toptusv1.perfilvendedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="col-md-7 col-xs-12 col-sm-8">
                <h3>Información del vendedor</h3>
                <div class="col-sm-4  col-xs-12 col-md-4">
                    <img src="vendedor/perfil/<%#imagen%>" alt="" class="img-rounded img-responsive" />
                    <br />
                    <%#fb.ToString()=="" ? "" :"<a href='"+fb+"' target='_blank'><img src='imagenes/iconos/facebook.png' width='25' height='25' /></a>" %>
                    <%#tw.ToString()=="" ? "" :"<a href='"+tw+"' target='_blank'><img src='imagenes/iconos/twitter.png' width='25' height='25'/></a>" %>
                    <%#gg.ToString()=="" ? "" :"<a href='"+gg+"' target='_blank'><img src='imagenes/iconos/google.png' width='25' height='25'/></a>" %>
                    <%#ins.ToString()=="" ? "" :"<a href='"+ins+"' target='_blank'><img src='imagenes/iconos/instagram.png'width='25' height='25' /></a>" %>
                    <%#lk.ToString()=="" ? "" :"<a href='"+lk+"' target='_blank'><img src='imagenes/iconos/linked.png' width='25' height='25'/></a>" %>
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
                    </p>

                </div>
            </div>

            <div class="col-md-5 col-sm-4 col-xs-12">

                <h3>Tambien vende:</h3>

                <div class="col-sm-12 col-md-12">
                    <asp:Label runat="server" id="nohay"></asp:Label>
                    <ul>
                        <asp:Repeater ID="rpt_mas_productos" runat="server">
                            <ItemTemplate>
                                <li><a href="productdetail.aspx?prod=<%#Eval("producto_id") %>"><%#Eval("producto") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
