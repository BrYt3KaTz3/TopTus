<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="productdetail.aspx.cs" Inherits="toptusv1.productdetail" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta property="og:image" content="http://demo.toptus.com/<%#ruta_foto %>"/>
    <link href="productos/css/glisse.css" rel="stylesheet" />
    <link href="productos/css/app.css" rel="stylesheet" />
    <script src="productos/js/glisse.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <br />

    </div>
    <div class="col-md-12">
        <div class ="row pull-right"> 
            <div class="fb-share-button" data-href="http://demo.toptus.com/productdetail.aspx?prod=<%#hdproducto.Value%>" data-layout="button_count"></div>
        </div>
        <div class="row container-pad">

            <div class="col-md-4">
                <asp:Label ID="nofotos" runat="server" Text=""></asp:Label>
                <img src="<%#ruta_foto %>" class="img-responsive" />
            </div>
            <div class="col-md-2">
                <asp:Repeater ID="rptFotosPorProducto" runat="server">
                    <ItemTemplate>
                        <img class="pics" src="<%#Eval("img_ruta") %>" style="padding-bottom: 10px" data-glisse-big="<%#Eval("img_ruta") %>" title="<%#Eval("img_descr") %>" rel="group<%#Eval("producto_id") %>" />
                    </ItemTemplate>
                </asp:Repeater>






            </div>




            <div class="col-md-6">
                <h1 class="text-danger"><%#nombre_producto %></h1>

                <h1 class="text-warning">$ <%#precio %></h1>
                <p class="text-muted"><%#descripcion %></p>


                <div class="row">
                    <div class="col-md-3 col-xs-8 col-sm-5">
                        Vendedor:<br />
                        <h5><a href="perfilvendedor.aspx?vendedor=<%# id_vendedor %>"><%# nick.ToString()== "" ? nombre : nick %></a></h5>
                        <img src="vendedor/perfil/<%# imagen %>" class="img-responsive img-rounded" />
                    </div>
                </div>


            </div>
        </div>

        <div class="container-pad row">
            <div class="panel panel-default widget">
                <div class="panel-heading">
                    <span class="glyphicon glyphicon-comment"></span>
                    <h3 class="panel-title">Comentarios sobre el producto.</h3>
                    <span class="label label-info" id="num_coments" runat="server"></span>
                </div>
                <div class="panel-heading">
                    <div class="row">

                        <div class="" id="add-comment">

                            <div class="form-group">
                                <label for="coment" class="col-sm-12 col-md-12 control-label ">Comentario</label>
                                <div class="col-sm-12 col-md-12">

                                    <asp:TextBox ID="txtComentario" TextMode="MultiLine" Height="100" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>


                            </div>

                            <div class="form-group">
                                <div class=" col-sm-12 ">

                                    <asp:Button ID="btnComentario" CssClass="btn btn-danger btn-circle text-uppercase"  OnClick="btnComentario_Click" runat="server" Text="Envíar" />
                                    <span class="glyphicon glyphicon-send "></span>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
                <div class="panel-body">
                    <ul class="list-group">



                        <asp:Repeater ID="rptComentarios" runat="server" OnItemDataBound="rptComentarios_ItemDataBound">
                            <ItemTemplate>
                                <li class="list-group-item">
                                    <div class="row">
                                        <div class="col-xs-4 col-md-1">
                                            <img src="vendedor/perfil/<%# Eval("imagen") %>" class="img-circle img-responsive" />

                                        </div>
                                        <div class="col-xs-8 col-md-11">
                                            <div class="item-comentarios">
                                                <div class="row">
                                                    <div>

                                                        <div class="mic-info">
                                                            Usuario: <a href="perfilvendedor.aspx?vendedor=<%# Eval("vendedor_id") %>"><%# Eval("nombre") %> - <%# Eval("nick") %></a>
                                                        </div>
                                                    </div>
                                                    <div class="comment-text">
                                                        <%# Eval("comentario") %>
                                                    </div>
                                                    <asp:HiddenField  ID="hidden_comentario" runat="server" Value='<%# Eval("comentario_id") %>' ClientIDMode="Static" />
                                                    <div class="action">
                                                        <!--<a href="productdetail.aspx?prod=<%# Eval("producto_id") %>&com=<%# Eval("comentario_id") %>&usr=<%# Eval("vendedor_id") %>">
                                                            <button type="button" class="btn btn-danger btn-xs" title="Responder">
                                                                <span class="glyphicon glyphicon-pencil"></span>
                                                            </button>
                                                        </a>-->
                                                        <a href="javascript:mostrar_caja_respuesta(<%# Eval("comentario_id") %>,<%# Eval("vendedor_id") %>) " id="add_respuesta<%# Eval("comentario_id") %>"> <button type="button" class="btn btn-danger btn-xs" title="Responder">
                                                                <span class="glyphicon glyphicon-pencil"></span>
                                                            </button></a>
                                                        </div>


                                                </div>
                                                
                                            </div>
                                        </div> 

                                    </div>
                                        <div class="row">
                                                    <!----------------------------------------------------------------------------------------------------RESPUESTAS------------------------------------------------------------------------------------------------------>
                                                    <div class="col-md-12  col-xs-12 comment-text text-muted item-respuesta">
                                                        <ul>
                                                        <asp:Repeater ID="rptRespuestas" runat="server">
                                                            <ItemTemplate>
                                                                <li>
                                                                <div class="row col-md-11  respuesta">
                                                                    <br /><br />
                                                                    <div class="mic-info">
                                                                        <a href="perfilvendedor.aspx?vendedor=<%# Eval("vendedor_id") %>"><%# Eval("nombre") %> - <%# Eval("nick") %>:</a> 
                                                                    </div>
                                                                    <div class="comment-text">

                                                                       <span class="glyphicon glyphicon-transfer"></span> <%# Eval("respuesta") %>
                                                                    </div>
                                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("comentario_id") %>' ClientIDMode="Static" />
                                                                    <div class="action">
                                                                       <a href="javascript:mostrar_caja_respuesta(<%# Eval("comentario_id") %>,<%# Eval("vendedor_id") %>) " id='add_respuesta<%# Eval("comentario_id") %>'> <button type="button" class="btn btn-info btn-xs" title="Responder">
                                                                <span class="glyphicon glyphicon-pencil"></span>
                                                            </button></a>
                                                                    </div>
                                                                </div>
                                                                <!--row-->
                                                            </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        </ul>
                                                    </div>

                                                </div>
                                   

                                    <!--caja de texto pa responder-->
                                    <div class="row">
                                        <div id="add-respuesta<%# Eval("comentario_id") %>" style="display:none;" >

                                            <div class="form-group">
                                                <label for="coment" class="col-sm-12 col-md-12 control-label ">Respuesta</label>
                                                <div class="col-sm-12 col-md-12">

                                                    <asp:TextBox ID="txtRespuesta" TextMode="MultiLine" Height="100" CssClass="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
                                                </div>


                                            </div>

                                            <div class="form-group">
                                                <div class=" col-sm-12 ">

                                                    <asp:Button ID="btnRespuesta" CssClass="btn btn-danger btn-circle" OnClick="btnRespuesta_Click" runat="server" Text="Responder" />
                                                    <span class="glyphicon glyphicon-send "></span>
                                                    
                                                </div>
                                            </div>

                                         </div>
                                    </div>
                                </li>
                            </ItemTemplate>

                        </asp:Repeater>







                    </ul>
                    <asp:HiddenField ID="hdusuario" runat="server"  ClientIDMode="Static"/> <!--usuario a responder , el usuario que responde se saca de la sesión-->
                    <asp:HiddenField ID="hdcomentario" runat="server" ClientIDMode="Static" /><!-- comentario que se responde -->
                    <asp:HiddenField ID="hdproducto" runat="server" ClientIDMode="Static" /><!-- -->
                   
                </div>
            </div>
        </div>

    </div>
   

    
    
    <script>
        $(function () {
            $('.pics').glisse({            
            });
        });
</script>

    <div id="fb-root"></div>
<script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/es_LA/sdk.js#xfbml=1&version=v2.3";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

    <div id="dialog-message-no" title="Error" style="display:none;">
  <p id="mensaje_error">
    
    
  </p>
  <p>
    <b>Presione OK para continuar.</b>
  </p>
</div>
    
    <div id="dialog-message-comentario-ok" title="Éxito" style="display:none;">
  <p>
    
    Comentario envíado con éxito
  </p>
  <p>
    <b>Presione OK para continuar.</b>
  </p>
</div>

     <div id="dialog-comentario-ok-nomail" title="Éxito" style="display:none;">
  <p>
    
    Comentario envíado con éxito , notificación no enviada, mantente alerta de tu bandeja de entrada.
  </p>
  <p>
    <b>Presione OK para continuar.</b>
  </p>
</div>
</asp:Content>
