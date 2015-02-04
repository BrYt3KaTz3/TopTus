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
           
            <img src="vendedor/prod_fotos/2.jpg" class="img-responsive" />
        </div>
        <div class="col-md-2">
            <img class="pics" src="vendedor/prod_fotos/2.jpg" data-glisse-big="vendedor/prod_fotos/2.jpg" rel="group1"  />
         
            <img class="pics" src="images/products/chamarra.jpg"  data-glisse-big="images/products/chamarra.jpg" rel="group1"  />
   
              <img class="pics" src="images/products/app.jpg"  data-glisse-big="images/products/app.jpg" rel="group1"  />
      
             <img class="pics" src="images/products/5.jpg"  data-glisse-big="images/products/5.jpg" rel="group1"  />
      
              <img class="pics" src="images/products/6.jpg"  data-glisse-big="images/products/6.jpg" rel="group1"  />
       
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
