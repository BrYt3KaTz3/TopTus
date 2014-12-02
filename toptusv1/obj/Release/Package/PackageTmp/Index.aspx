﻿<%@ Page Title="" Language="C#" MasterPageFile="/base.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="toptusv1.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/index.js"></script>
   <script src="jsgaleria/modernizr.custom.63321.js"></script>
    <link href="css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">
         <div class="row">
             <div class="col-md-12">


                 <div id="mi-slider" class="mi-slider">
    <ul>
        <li><a href="#"><img src="images/1.jpg" alt="img01"><h4>Boots</h4></a></li>
        <li><a href="#"><img src="images/2.jpg" alt="img02"><h4>Oxfords</h4></a></li>
        <li><a href="#"><img src="images/3.jpg" alt="img03"><h4>Loafers</h4></a></li>
        <li><a href="#"><img src="images/4.jpg" alt="img04"><h4>Sneakers</h4></a></li>
    </ul>
    <ul>
        <li><a href="#"><img src="images/5.jpg" alt="img05"><h4>Belts</h4></a></li>
        <li><a href="#"><img src="images/6.jpg" alt="img06"><h4>Hats & Caps</h4></a></li>
        <li><a href="#"><img src="images/7.jpg" alt="img07"><h4>Sunglasses</h4></a></li>
        <li><a href="#"><img src="images/8.jpg" alt="img08"><h4>Scarves</h4></a></li>
    </ul>
    <ul>
        <li><a href="#"><img src="images/9.jpg" alt="img09"><h4>Casual</h4></a></li>
        <li><a href="#"><img src="images/10.jpg" alt="img10"><h4>Luxury</h4></a></li>
        <li><a href="#"><img src="images/11.jpg" alt="img11"><h4>Sport</h4></a></li>
    </ul>
    <ul>
        <li><a href="#"><img src="images/12.jpg" alt="img12"><h4>Carry-Ons</h4></a></li>
        <li><a href="#"><img src="images/13.jpg" alt="img13"><h4>Duffel Bags</h4></a></li>
        <li><a href="#"><img src="images/14.jpg" alt="img14"><h4>Laptop Bags</h4></a></li>
        <li><a href="#"><img src="images/15.jpg" alt="img15"><h4>Briefcases</h4></a></li>
    </ul>
    <nav>
        <a href="#">Shoes</a>
        <a href="#">Accessories</a>
        <a href="#">Watches</a>
        <a href="#">Bags</a>
    </nav>
</div>


             </div>

         </div>
         <br />
         <br />
          <div class="row">
              <div class="col-md-4">
                   <h3>Title A</h3>
                   <p>
                       Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
                   </p>
               </div>
               <div class="col-md-4">
                   <h3>Title B</h3>
                   <p>
                       Nuncamente viverra imperdiet enim. Fusce est. Vivamus a tellus.
                       Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.
                   </p>
               </div>
               <div class="col-md-4">
                   <h3>Title C</h3>
                   <p>
                       Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.
                       Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.
                   </p>
               </div>
           </div>
         <div class="row">
             <div class="col-md-12">
            
             <br />
             ¿Quieres ser parte de TopTus?... entra <a href="solicitud.aspx" >aquí</a>
                 </div>
         </div>

       </div>    
    <script src="jsgaleria/jquery.catslider.js"></script>
		<script>
		    $(function () {

		        $('#mi-slider').catslider();

		    });
		</script>

</asp:Content>
