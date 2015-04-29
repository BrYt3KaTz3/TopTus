<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="productdetail.aspx.cs" Inherits="toptusv1.productdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="productos/css/glisse.css" rel="stylesheet" />
    <link href="productos/css/app.css" rel="stylesheet" />
    <script src="productos/js/glisse.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <br />

    </div>
    <div class="col-md-12">
    <div class="row container-pad">

        <div class="col-md-4">
            <asp:Label ID="nofotos" runat="server" Text=""></asp:Label>
            <img src="vendedor/prod_fotos/<%#id_producto %>.jpg" class="img-responsive" />
        </div>
        <div class="col-md-2">
            <asp:Repeater ID="rptFotosPorProducto" runat="server">
                <ItemTemplate>
                     <img class="pics" src="<%#Eval("img_ruta") %>" style="padding-bottom:10px" data-glisse-big="<%#Eval("img_ruta") %>" title="<%#Eval("img_descr") %>" rel="group<%#Eval("producto_id") %>"  />
                </ItemTemplate>
            </asp:Repeater>


           
         
            
       
        </div>
    

       

            <div class="col-md-6">
                <h1 class="text-danger"> <%#nombre_producto %></h1>
                
                <h1 class="text-warning"> $ <%#precio %></h1>
                <p class="text-muted"> <%#descripcion %></p>

                <h6>Cate y sub??</h6>
                <div class="row"> 
                <div class="col-md-3 col-xs-8 col-sm-5">
                    Vendedor:<br /> <h5><a href="perfilvendedor.aspx?vendedor=<%# id_vendedor %>"><%# nick.ToString()== "" ? nombre : nick %></a></h5>
                    <img src="vendedor/perfil/<%# imagen %>" class="img-responsive img-rounded" />
                </div>
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
</asp:Content>
