<%@ Page Title="" Language="C#" MasterPageFile="~/vendedor/base_vendedor.Master" AutoEventWireup="true" CodeBehind="modificar_producto.aspx.cs" Inherits="toptusv1.vendedor.modificar_producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Vendedor" runat="server">
    <div class="padding_inicio row">
        <h3 class="text-center titulo_seccion" >Modificación de Información de producto</h3>
            <div class="col-md-10 col-md-offset-2" id="formulario_modificacion">
        <div class="form-group">
                    <label for="prod" class="col-lg-2 control-label">Nombre:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="txtNombre" type="text" CssClass="form-control input_form"   runat="server" ></asp:TextBox>
                      
                    </div>
                </div>
                <br />
        <div class="form-group">
                    <label for="precio" class="col-lg-2 control-label">Precio:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="txtPrecio" type="text" CssClass="form-control input_form"   runat="server" ></asp:TextBox>
                      
                    </div>
                </div>
                <br />
        <div class="form-group">
                    <label for="desc" class="col-lg-2 control-label">Descripción:</label>
                    <div class="col-lg-6">
                      <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" Height="150px" CssClass="form-control input_form"  runat="server" ></asp:TextBox>
                        <div align="center">
                      <asp:Button ID="btnModificarProducto" OnClick="btnModificarProducto_Click" CssClass="btn-danger btn padding_inicio" runat="server" Text="Actualizar Producto" />
                    </div>
                        </div>
                </div>
                <br />
                
       </div>
    </div>

    <!-- Categorias -->
      <div class="padding_inicio row">
        <h3 class="text-center titulo_seccion" >Categorías y Subcategorías</h3>
          
           <a href="catprod.aspx?prod=<%#  encriptar_url(producto).ToString() %>"> <h4 class="text-center">Agregar categorías</h4></a>
            <div class="col-md-8 col-md-offset-4" id="">
       
                
            <div class="row">
            
            <h4> <asp:Label runat="server" ID="repeater_status" CssClass="alert-danger"></asp:Label></h4>
           <ul>
               <asp:Repeater ID="rptCategorias_Subcategorias" runat="server">
                   <ItemTemplate>
                   <li>
                       <asp:LinkButton ID="delete_cat" runat="server"  CommandName="eliminar"  CommandArgument='<%#Eval("categoria_id") + ";" +Eval("subcategoria_id")%>' OnCommand="delete_cat_Click" OnClientClick='return confirm("¿Estás seguro de querer eliminar esta categoría?")' ><span class="glyphicon glyphicon-remove"></span>  </asp:LinkButton><span class="text-info" style="font-size:18px;"><%# Eval("categoria_descr") %>  - <%#Eval ("subcategoria_descr") %> </span>
                   </li>
                   </ItemTemplate>
               </asp:Repeater>
           </ul>
       
             
        </div>
       </div>
    </div>

    <!-- Fotos -->
      <div class="padding_inicio row">
        <h3 class="text-center titulo_seccion" >Fotografías del producto</h3>
            <a href="fotosprod.aspx?prod=<%#  encriptar_url(producto).ToString() %>"> <h4 class="text-center">Agregar fotos</h4></a>
          <asp:Label ID="nofotos" runat="server"  cssClass="text-center" Text=""></asp:Label>
            <div class="col-md-10 col-md-offset-2" id="Div1">
        
                 

           
            <br />
            
            <asp:Repeater ID="rptFotoProducto" runat="server">
                <ItemTemplate>
                    <div class="col-md-2">
                     <img class="img-responsive" src="../<%#Eval("img_ruta") %>" style="padding-bottom:10px"   />
                        <asp:LinkButton ID="btnEliminarFoto" runat="server" CssClass="text-center" CommandArgument='<%#Eval("img_prod_detail_id")  + ";" +Eval("img_ruta")%>' CommandName="eliminar_foto" OnCommand="btnEliminarFoto_Command" OnClientClick='return confirm("¿Estás seguro de querer borrar esta foto?")'>Eliminar</asp:LinkButton>
                        
                        <br />
                    <br />
                    </div>
                     <br />
                </ItemTemplate>

            </asp:Repeater>
        
       </div>
    </div>


    <div class="padding_inicio row" align="center">
        <h3 class="text-center titulo_seccion" >Eliminar Producto</h3>
        <span onclick='return confirm("¿Estás seguro de querer borrar este producto y toda su información relacionada?")'>
            <asp:Button ID="btnEliminarProducto" CssClass="btn btn-danger" runat="server" Text="Eliminar producto." OnClick="btnEliminarProducto_Click"   />
        </span>
         
           
    </div>

    <div id="dialog-message-modificar" title="Éxito" style="display:none;">
  <p>
    
    Producto actualizado de forma correcta
  </p>
  <p>
    <b>Presione OK para continuar.</b>
  </p>
</div>

    <div id="dialog-message-eliminarcategoria" title="Éxito" style="display:none;">
  <p>
    
    Categoría eliminada correctamente
  </p>
  <p>
    <b>Presione OK para continuar.</b>
  </p>
</div>

      <div id="dialog-message-eliminarfoto" title="Éxito" style="display:none;">
  <p>
    
   Foto eliminada correctamente
  </p>
  <p>
    <b>Presione OK para continuar.</b>
  </p>
</div>

    
      <div id="dialog-message-eliminarproducto" title="Éxito" style="display:none;">
  <p>
    
  Producto eliminado correctamente
  </p>
  <p>
    <b>Presione OK para continuar.</b>
  </p>
</div>

</asp:Content>
