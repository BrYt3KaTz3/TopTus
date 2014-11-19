<%@ Page Title="" Language="C#" MasterPageFile="/base.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="toptusv1.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/index.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">
          <div class="row">
              <div class="col-md-4">
                   <h1>Title A</h1>
                   <p>
                       Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
                   </p>
               </div>
               <div class="col-md-4">
                   <h1>Title B</h1>
                   <p>
                       Nuncamente viverra imperdiet enim. Fusce est. Vivamus a tellus.
                       Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.
                   </p>
               </div>
               <div class="col-md-4">
                   <h1>Title C</h1>
                   <p>
                       Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.
                       Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.
                   </p>
               </div>
           </div>
         <div class="row">
             <div class="col-md-12">
             <a href="productlist.aspx">Lista de productos</a>
             <br />
             ¿Quieres ser parte de TopTus?... entra <a href="vendedor/solicitud.aspx" target="_blank">aquí</a>
                 </div>
         </div>

       </div>    

</asp:Content>
