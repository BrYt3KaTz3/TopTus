<%@ Page Title="" Language="C#" MasterPageFile="/base.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="toptusv1.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/index.js"></script>
    <script src="jsgaleria/modernizr.custom.63321.js"></script>
    <script src="jsgaleria/pgwslider.js"></script>
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/pgwslider.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--<div class="col-md-12">
        <img src="imagenes/circulo/Home%20Web%20TT%20Ubicaciones.png" / class="img-responsive">
    </div>-->
    <div class="col-md-12 padding_inicio" id="circulo">

        <div class="row">
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/A1.png" class="img-responsive " /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <a href="perfilvendedor.aspx?vendedor=11">
                <img src="imagenes/circulo/A2.png" class="img-responsive " /></a> </div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <a href="perfilvendedor.aspx?vendedor=11">
                <img src="imagenes/circulo/A3.png" class="img-responsive " /></a> </div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <a href="perfilvendedor.aspx?vendedor=11">
                <img src="imagenes/circulo/A4.png" class="img-responsive " /></a> </div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <a href="perfilvendedor.aspx?vendedor=11">
                <img src="imagenes/circulo/A5.png" class="img-responsive" /></a> </div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/A6.png" class="img-responsive" /></div>

        </div>
        <div class="row">
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/B1.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/B2.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/B3.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/B4.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/B5.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/B6.png" class="img-responsive" /></div>
        </div>
        <div class="row">
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/C1.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/C2.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/C3.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/C4.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/C5.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/C6.png" class="img-responsive" /></div>
        </div>
        <div class="row">
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/d1.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/D2.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/D3.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/D4.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/D5.png" class="img-responsive" /></div>
            <div class="col-md-2 col-xs-2 col-sm-2">
                <img src="imagenes/circulo/D6.png" class="img-responsive" /></div>
        </div>

    </div>


    <div class="row padding_inicio">
        <div class="col-md-12 col-xs-12 col-sm-12 rojo padding_inicio">
               <div class="col-md-11 col-xs-11 col-sm-11 gris"><h2 class="text-center hometitle">Hogar</h2></div><div class="col-md-1 col-xs-1 col-sm-1"></div>         
        </div>
      
        <asp:Repeater ID="rpthogar" runat="server">
            <ItemTemplate>
                 <div class="col-md-2 col-sm-4 col-xs-6 column productbox">
            <img src="vendedor/<%#Eval("img_principal") %>" class="img-responsive">
            <div class="producttitle"><%#Eval("producto") %></div>
            <div class="productprice"><div class="pull-right"><a href="productdetail.aspx?prod=<%#Eval("producto_id") %>" class="btn btn-danger btn-sm" role="button">Más detalles</a></div><div class="pricetext">$ <%#Eval("precio") %></div></div>
        </div>
            </ItemTemplate>

        </asp:Repeater>
       
         
    </div>

    <div class="row">
       <div class="col-md-12 col-xs-12 col-sm-12 rojo padding_inicio">
               <div class="col-md-11 col-xs-11 col-sm-11 gris"><h2 class="text-center hometitle">Deportes</h2></div><div class="col-md-1 col-xs-1 col-sm-1"></div>         
        </div>
    </div>
    <div class="row">
       <div class="col-md-12 col-xs-12 col-sm-12 rojo padding_inicio">
               <div class="col-md-11 col-xs-11 col-sm-11 gris"><h2 class="text-center hometitle">Electrónica y Tecnología</h2></div><div class="col-md-1 col-xs-1 col-sm-1"></div>         
        </div>    
    </div>
     <div class="row">
       <div class="col-md-12 col-xs-12 col-sm-12 rojo padding_inicio">
               <div class="col-md-11 col-xs-11 col-sm-11 gris"><h2 class="text-center hometitle">Reciclaje</h2></div><div class="col-md-1 col-xs-1 col-sm-1"></div>         
        </div> 
    </div>
     <div class="row">
         <div class="col-md-12 col-xs-12 col-sm-12 rojo padding_inicio">
               <div class="col-md-11 col-xs-11 col-sm-11 gris"><h2 class="text-center hometitle">Orgánico</h2></div><div class="col-md-1 col-xs-1 col-sm-1"></div>         
        </div> 
    </div>
     <div class="row">
         <div class="col-md-12 col-xs-12 col-sm-12 rojo padding_inicio">
               <div class="col-md-11 col-xs-11 col-sm-11 gris"><h2 class="text-center hometitle">Moda</h2></div><div class="col-md-1 col-xs-1 col-sm-1"></div>         
        </div> 
    </div>
     <div class="row">
        <div class="col-md-12 col-xs-12 col-sm-12 rojo padding_inicio">
               <div class="col-md-11 col-xs-11 col-sm-11 gris"><h2 class="text-center hometitle">Todo lo demás</h2></div><div class="col-md-1 col-xs-1 col-sm-1"></div>         
        </div> 
    </div>

    <!-- <div class="row top-buffer"> galerias nuevas 
             <div class="col-md-4">

                <ul class="pgwSlider">
                <li><img src="images/products/2.jpg" class="img-responsive"><span>Las mejores aplicaciones móviles del momento</span></li>
                <li><img src="images/products/1.jpg" class="img-responsive" alt="Sudaderas para damas" data-description="Bonitos diseños para este invierno"></li>
                <li><img src="images/products/3.jpg" class="img-responsive" alt="¿Qué tal una bonita bolsa para tu pareja?" data-large-src="images/products/5.jpg"></li>
                <li><img src="images/products/4.jpg" class="img-responsive"><span>Regalale a tus hijos este instrumento</span></li>
                <li><a href="http://shure.com/"  target="_blank"><img src="images/products/5.jpg" class="img-responsive"/><span>Los mejores micrófonos</span></a></li>
                </ul>
             </div>

        <div class="col-md-4">

                <ul class="pgwSlider">
                <li><img src="images/products/6.jpg" class="img-responsive"></li>
                <li><img src="images/products/7.png" class="img-responsive"></li>
                <li><img src="images/products/8.jpg" class="img-responsive"></li>
                <li><img src="images/products/9.png" class="img-responsive"></li>
                <li><img src="images/products/10.jpg" class="img-responsive"><span>La mejor ropa de la temporada</span></li>
               
                </ul>
             </div>

        <div class="col-md-4">
           <div class="row">
               </div>
                    <img src="images/products/publi1.jpg" />
                 <div class="row">
            
              
                    <img src="images/products/publi2.jpg" /></div>
           
        </div>


    </div> -->


    <div class="row top-buffer">
        <!--galeria 
             <div class="col-md-12">

                <ul class="pgwSlider">
                <li><img src="images/products/app.jpg"><span>Las mejores aplicaciones móviles del momento</span></li>
                <li><img src="images/products/chamarra.jpg" alt="Sudaderas para damas" data-description="Bonitos diseños para este invierno"></li>
                <li><img src="images/products/bolsas.jpg" alt="¿Qué tal una bonita bolsa para tu pareja?" data-large-src="images/products/bolsas.jpg"></li>
                <li><img src="images/products/colores.jpg"><span>Regalale a tus hijos estos bonitos colores</span></li>
                <li><a href="http://www.nyc.gov" target="_blank"><img src="images/products/reloj.jpg" /><span>Nunca llegues tarde con estos bonitos relojes</span></a></li>
                </ul>

             </div> -->
    </div>

    <!--<div class="row top-buffer ">
             <div class="col-md-6"><h3 class="text-center">Wanna Sell?</h3>
                 Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
             </div>
             <div class="col-md-6"><h3 class="text-center">Wanna Buy?</h3>
                 Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
             </div>
         </div>
         <div class="row top-buffer">
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

         </div> -->
    <br />
    <br />
    <div class="row">
        <div class="col-md-12">

            <h3 class="text-center">Haz Más</h3>
        </div>

    </div>

    <div class="row">
        <div class="col-md-12 cuatro_puntos">
            <div class="col-md-3">
                <div class="row">
                    <h4 class="text-center">
                        <img src="imagenes/iconos/porque.png" />Regístrate. </h4>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <p class="text-justify">
                            Más Opciones para satisfacer tus necesidades y hacer crecer tu negocio.
                        </p>

                        <p class="text-justify">
                            Toptus te facilita la búsqueda de  los mejores productos y servicios del 
                            mercado. Con solo un click podrás obtener la información completa de
                             lo que estas buscando y podrás darte a conocer con muchos posibles clientes.
                        </p>
                    </div>
                </div>

            </div>
            <div class="col-md-3">
                <div class="row">
                    <h4 class="text-center">
                        <img src="imagenes/iconos/calidad.png" />Alta Calidad. </h4>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <ul>

                            <li>Los Mejores Precios, Directamente De Fábrica, Importadores y Distribuidores de confianza</li>

                            <li>Somos una empresa que busca que nuestros usuarios trabajen con la más alta calidad en su servicio.</li>
                            <li>Toptus se encarga de evaluar a sus vendedores para que trabajen bajo el reglamento de calidad, para así ser la única página de internet confiable en el mercado.</li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row">
                    <h4 class="text-center">
                        <img src="imagenes/iconos/clientes.png" />
                        Excelente atención. </h4>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <p class="text-justify">
                           Toptus ofrece un servicio de atención al cliente. Puedes hacer preguntas a nuestro correo 
                            electrónico <a href="mailto:info@toptus.com">info@toptus.com</a> Nuestros representantes del servicio 
                            de atención al cliente estarán atentos a cualquier inquietud por parte de los usuarios. 

                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row">
                    <h4 class="text-center">
                        <img src="imagenes/iconos/vanguardia.png" />
                        Productos univanguardistas.</h4>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <p class="text-justify">
                            En Toptus no solamente esperamos a que nuestros usuarios se registren, nuestro equipo se  encarga de visitar negocios dentro de la república para poder ofrecerles un espacio en nuestro sitio toptus.com
                        </p>
                        <p class="text-justify">
                            Toptus va mas allá de las fronteras invitando físicamente a todos los nuevos empresarios para invitarlos a la única pagina web más confiable del mercado.
                        </p>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <!--          <div class="table-bordered row">
               <div class="col-md-1">
             <img src="imagenes/opciones.png" / class="img-responsive">
         </div>
              <div class="col-md-11">
                   <h3>Por qué ser miembro de TopTus? </h3>
                   <p class="text-justify">
                      Más Opciones para satisfacer tus necesidades y hacer crecer tu negocio.
                     </p>
                  <p class="text-justify">
                      TopTus.com es una empresa de comercio online que pone en contacto a compradores y vendedores de  artículos y servicios  los cuales difícilmente se encuentran en el mercado. Artículos de Moda, Salud y Belleza, Electrónica y Hogar, todos pueden ser encontrados en cualquier parte del país a precios inmejorables con solo recibir los datos del contacto de forma rápida y sencilla. Si quiere hacer crecer su negocio haga que TopTus sea una parte de su vida.
                  </p>
                  <p class="text-justify">
                     Toptus te ofrece los mejores artículos y servicios del mercado. Con solo un click podrás ponerte en contacto con empresarios y podrás ofrecer tu producto a millones de clientes.
                  </p>
               </div>
              

         </div><br />
               <div class="table-bordered row">
                    <div class="col-md-4">
             <img src="imagenes/calidad.jpg" / class="img-responsive">
             </div>
               <div class="col-md-8">
                   <h3>Alta Calidad</h3>
                   <ul>
                       <li>Estamos en constante monitoreo para que los usuarios ofrezcan productos de la más alta calidad.</li>
                       <li>Los Mejores Precios, Directamente De Fábrica, Importadores y Distribuidores de confianza</li>
                       <li>Como empresa de comercio online, TopTus.com constantemente contacta y analiza a sus usuarios para que los vendedores cumplan con los precios y términos establecidos en sus anuncios.</li>
                       <li>Somos una empresa que busca que nuestros usuarios trabajen con la más alta calidad en su servicio.</li>
                       <li>Toptus se encarga de evaluar a sus vendedores para que trabajen bajo el reglamento de calidad, para así ser la única página de internet confiable en el mercado.</li>
                   </ul>
               
               </div>
              
           </div><br />
        
     <div class="table-bordered row">

      <div class="col-md-4">
             <img src="imagenes/contacto.jpg" / class="img-responsive">
         </div>
              <div class="col-md-8">
                   <h3>Servicio De Atención al Cliente Profesional Y Cercano </h3>
                   <p class="text-justify">
                     Toptus.com ofrece un servicio de atención al cliente excelente y completo durante todo el proceso en el sitio. Antes de contactanos, antes de adquirir cualquiera de nuestras dos membrecías  puede hacer preguntas en tiempo real a  nuestro correo electrónico dudas@toptus.com. Nuestros representantes del servicio de atención al cliente siempre estarán disponibles para responder preguntas a través de nuestro correo dudas@toptus.com 
                  </p>
                  <p class="text-justify">
                     Ponte en contacto con nosotros si tienes alguna queja o duda. Estamos disponibles las 24 horas del día. Nuestro personal te lo agradecerá.
                </p>
                 </div>
               </div><br />
     <div class="table-bordered row">
         <div class="col-md-4">
             <img src="imagenes/inova.jpg" / class="img-responsive">
         </div>
               <div class="col-md-8">
                   <h3>Productos únicos y de vanguardia  </h3>
                       
                  <p class="text-justify">
                  En Toptus no solamente esperamos a que nuestros usuarios se registren, nuestro equipo se  encarga de visitar negocios dentro de la república para poder ofrecerles un espacio en nuestro sitio toptus.com
                   </p>
                    <p class="text-justify">
                     Toptus va mas allá de las fronteras invitando físicamente a todos los nuevos empresarios para invitarlos a la única pagina web más confiable del mercado.
                     </p>
                   
                   
               </div>
              
           </div><br />-->

    <div class="row">
        <div class="col-md-12">
        </div>
    </div>


    <script src="jsgaleria/jquery.catslider.js"></script>
    <!--Slider de tennis-->
    <script>
        $(function () {

            $('#mi-slider').catslider();

        });
    </script>

    <!--javascript para zoom-->

      <script>
         
              $('.viewport').mouseenter(function (e) {
                  var h = $(this).children('a').children('img').height();
                  var w = $(this).children('a').children('img').width();
                  console.log(h);
                  
                  $(this).children('a').children('img').animate({ height: h + 20, left: '0', top: '0', width: w + 20 }, 100);
                  
              }).mouseleave(function (e) {
                  $(this).children('a').children('img').animate({ height: '100%', left: '0', top: '0', width: '100%' }, 100);
                  
              });
         
    </script>


</asp:Content>
