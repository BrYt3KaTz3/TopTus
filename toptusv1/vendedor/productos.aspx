<%@ Page Title="" Language="C#" MasterPageFile="~/vendedor/base_vendedor.Master" AutoEventWireup="true" CodeBehind="productos.aspx.cs" Inherits="toptusv1.vendedor.products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Vendedor" runat="server">
     <div class="row">
       
       <div class="col-md-4 col-md-offset-4"><h3>Productos</h3></div>
         </div> 
    <div class="row">
        <div class="text-info col-md-6">Nota: después de agregar un producto, asegurate de agregar sus categorías y sus fotografías, de otra manera no aparecerá publicado</div>
 <br />
    </div>
    <br />
    
    <a href="#" id="link_add_product" class="button-link">Agregar nuevo producto</a>
    <div id="add_product">
     <div class="row" >
       
       <div class="col-md-4 col-md-offset-4"><h3>Agregar producto</h3></div>

     </div>
         <div class="row">
       <div class="col-md-offset-3">
                    <label for="prod_nombre" class="col-md-3 control-label">Nombre del producto:</label>
                    <div class="col-md-6">
                      <asp:TextBox ID="prod_nombre" type="text" CssClass="form-control input_form"  placeholder="Producto" runat="server" ></asp:TextBox>
                      
                    </div>
                </div>
             </div><br />
               <div class="row">
             <div class="col-md-offset-3">
                    <label for="prod_descr" class="col-md-3 control-label">Descripción:</label>
                    <div class="col-md-6">
                        
                      <asp:TextBox ID="prod_descr" TextMode="MultiLine" CssClass="form-control input_form"  placeholder="Descripción" runat="server" ></asp:TextBox>
                      
                    </div>
                </div>
                   </div><br />
               <div class="row">
             <div class="col-md-offset-3">
                    <label for="prod_precio" class="col-md-3 control-label">Precio:<span class="pull-right">$</span></label>
                    <div class="col-md-6">
                      <asp:TextBox ID="prod_precio" type="text" CssClass="form-control input_form"  placeholder="99.99" runat="server" ></asp:TextBox>
                      
                    </div>
                </div>
                <br /><br />
   </div><div class="text-center">
        <asp:Button ID="btnAgregarProducto" ClientIDMode="Static" runat="server" CssClass="btn-lg"  Text="Agregar producto" OnClick="btnAgregarProducto_Click" />
        </div>
    </div>
    <br/>
    <div class="container-pad" id="property-listings">
         <!-- REPEAETTEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEERRRRRRRRRRRR -->
        <asp:Repeater ID="rptProductos" runat="server">
            <ItemTemplate>
                 <div class="row">
        <div class="col-md-12">
           <div class="brdr bgc-fff pad-10 box-shad btm-mrg-20 property-listing">
               <asp:HiddenField runat="server" ID="hidden_product" Value='<%# Eval("producto_id") %>' ClientIDMode="Static" />
                        <div class="media">
                            <a class="pull-left" href="#" target="_parent">
                            <img alt="image" class="img-responsive" src="<%# Eval("img_principal") %>"></a>

                            <div class="clearfix visible-sm"></div>

                            <div class="media-body fnt-smaller">
                                <a href="#" target="_parent"></a>

                                <h4 class="media-heading">
                                  <a href="#" target="_parent"><%# Eval("producto") %> <small class="pull-right">$<%# Eval("precio") %></small></a></h4>


                                <ul class="list-inline mrg-0 btm-mrg-10 clr-535353">
                                    <li>Vendedor</li>

                                    <li style="list-style: none">|</li>

                                    <li>5 Beds</li>

                                    <li style="list-style: none">|</li>

                                    <li>5 Baths</li>
                                </ul>

                                <p class="hidden-xs"><%# Eval("producto_descr") %></p>
                                <span class="fnt-smaller fnt-lighter fnt-arial">Courtesy of HS Fox & Roach-Chestnut Hill
                                Evergreen</span>
                                <br />
                                <a href="catprod.aspx?prod=<%#  encriptar_url(Eval("producto_id").ToString()) %>"> <span class="pull-right">Agregar categorías</span></a>
                              
                                
                            </div>
                        </div>
                    </div><!-- End Listing-->
        </div><!-- End -col md-->
                 
    </div>
            </ItemTemplate>

        </asp:Repeater>


   

</div>
</asp:Content>
