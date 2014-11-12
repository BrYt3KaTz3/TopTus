<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="productos.aspx.cs" Inherits="toptusv1.productos.productos"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-2.1.1.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script src="js/productos.js"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="container" id="general">
          <div class="row">
              <div class="col-md-4">
                   <h1>Producto A</h1>
                   <p>
                     Aquí se mostrarán los productos dinámicamente
                   </p>
                  <div id="productos"></div>
               </div>
              
           </div>
         
       </div>    

</asp:Content>
