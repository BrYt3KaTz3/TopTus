<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="productlist.aspx.cs" Inherits="toptusv1.productos.productlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="productos/js/productos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="lista col-md-6">
            <ul><li id="li_categoria" runat="server"></li><li>></li><li id="li_subcategoria" runat="server"></li></ul>
        </div>
    </div>

     <div class="container-pad" id="property-listings">
         <!-- REPEAETTEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEERRRRRRRRRRRR -->
          <div class="row"><asp:Label runat="server" ID="no_hay_productos"></asp:Label>
        <asp:Repeater ID="rptProductosList" OnItemDataBound="rptProductosList_ItemDataBound" runat="server">
            <ItemTemplate>
                
        <div class="col-sm-12">
           <div class="brdr bgc-fff pad-10 box-shad btm-mrg-20 property-listing">
               <asp:HiddenField runat="server" ID="hidden_product" Value='<%# Eval("producto_id") %>' ClientIDMode="Static" />
                        <div class="media">
                            <a class="pull-left" href="productdetail.aspx?prod=<%# Eval("producto_id") %>" target="_parent">
                            <img alt="image" class="img-responsive max_fotos_list" src="<%# ruta(int.Parse(Eval("producto_id").ToString())) %>"></a>

                            <div class="clearfix visible-sm visible-xs"></div>
                            
                            <div class="media-body fnt-smaller">
                                <a href="#" target="_parent"></a>

                                <h4 class="media-heading">
                                  <a href="productdetail.aspx?prod=<%# Eval("producto_id") %>" target="_parent"><%#Eval("producto") %> <h3 class="pull-right" style="color:black;">$<%# Eval("precio") %></h3></a></h4>
                                                                                                                

                                <ul class="list-inline mrg-0 btm-mrg-10 clr-535353">
                                   <!-- <asp:Repeater ID="rptcatsub" runat="server">
                                        <ItemTemplate>

                                             <li><%# Eval("categoria_descr") %>  - <%#Eval ("subcategoria_descr") %>.</li>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                   
                                    -->
                                 
                                </ul>                                      
                                <h5>Vendedor: <a href="perfilvendedor.aspx?vendedor=<%#Eval("vendedor_id") %>"><%#Eval("nick").ToString()== "" ? Eval("nombre"): Eval("nick") %></a></h5>
                                <p class="hidden-xs"><%# Eval("producto_descr") %></p>
                              
                                <br />
                                
                              
                                
                            </div>
                        </div>
                    </div><!-- End Listing-->
        </div><!-- End -col md-->
                 
    
            </ItemTemplate>

        </asp:Repeater>
        </div>

   

</div>


</asp:Content>
