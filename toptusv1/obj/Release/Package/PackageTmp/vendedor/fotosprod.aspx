<%@ Page Title="" Language="C#" MasterPageFile="~/vendedor/base_vendedor.Master" AutoEventWireup="true" CodeBehind="fotosprod.aspx.cs" Inherits="toptusv1.vendedor.fotosprod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Vendedor" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
       
       <div class="col-md-4 col-md-offset-4"><h3 class="text-center">Fotos por producto</h3></div>
         </div>

    <div class="row notas">
        <h5 class="text-center"><span>Nota 1: La primer foto que subas será la foto que se mostrará en el listado de productos, las siguientes se mostrarán en la galería del mismo.</span></h5>
        <h5 class="text-center"><span>Nota 2: Trata de que el nombre de la foto a subir no contenga espacios o caracteres especiales, ejemplos:  'producto#$#%3.jpg' , 'mi foto.jpg' </span></h5>
 
    </div>
    <div class="row">
        <div class="col-md-4 col-md-offset-4"><h3 class="text-center"><%#producto %></h3></div>
        
    </div>
    <div class="row"><h4 class="text-center"><a href="modificar_producto.aspx?prod=<%#  encriptar_url(id_prodd.ToString()) %>" class="text-info" target="_parent">(editar información)</a></h4></div>

    <div class="row">

        <div class="col-md-12">


            <div class="col-md-6 col-sm-6 col-xs-12" style="border-right: 1px solid gray">
                <h4>Agrega el nombre y la descripción de cada foto de tu producto:</h4>
                <div id="ContentPlaceHolder_Vendedor_UpdatePanel1">
                    <div class="row">
                    <div class="form-group">
                        <label for="catprod_cat" class="col-md-4 control-label">Nombre de la foto:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtNombreFoto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    </div>
                        <br>
                    <br>
                    <div class="row">
                    <div class="form-group">
                        <label for="catprod_sub" class="col-md-4 control-label">Descripción de la foto:</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtDescripcionFoto" runat="server"></asp:TextBox>
                        </div>
                    </div>
                        </div>
                    <div class="form-group">
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                        <ContentTemplate>
                           
                            <div class="col-md-10 col-md-offset-2">                                               
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="FileUpload1" />
                            <br />  
                           
                            <asp:Button ID="btnUpload" ClientIDMode="Static" runat="server" Text="Agregar Foto" OnClick="btnUpload_Click"  class="btn-lg" /><br />
                                </div> 
                        </ContentTemplate>
                        <Triggers> <asp:PostBackTrigger ControlID="btnUpload" /> </Triggers>  
                    </asp:UpdatePanel>
                    </div>


                </div>
                
            </div>
        <div class="col-md-6 col-sm-6 col-xs-12">

           <h4>Fotos del producto:</h4>
            <br />
            <asp:Label ID="nofotos" runat="server" Text=""></asp:Label>
            <asp:Repeater ID="rptFotoProducto" runat="server">
                <ItemTemplate>
                    <div class="col-md-6 col-md-offset-3">
                     <img class="img-responsive" src="../<%#Eval("img_ruta") %>" style="padding-bottom:10px"   />
                        <asp:LinkButton ID="btnEliminarFoto" runat="server" CssClass="text-center" CommandArgument='<%#Eval("img_prod_detail_id")  + ";" +Eval("img_ruta")%>' CommandName="eliminar_foto" OnCommand="btnEliminarFoto_Command"  OnClientClick='return confirm("¿Estás seguro de querer borrar esta foto?")'>Eliminar</asp:LinkButton>
                        
                        <br />
                    <br />
                    </div>
                   
                     <br />
                </ItemTemplate>

            </asp:Repeater>
        </div>
        </div>

    </div>

      <div id="dialog-message-eliminarfoto" title="Éxito" style="display:none;">
  <p>
    
   Foto eliminada correctamente
  </p>
  <p>
    <b>Presione OK para continuar.</b>
  </p>
</div>
</asp:Content>
