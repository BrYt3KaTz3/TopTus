$(document).ready(function () {
    menu_class_change();
    main();
    

    /*evitar apostrofes en todas las cajas
    $("input , textarea").keydown(function (event) {
        console.log(event.keyCode);
        if (event.shiftKey) {
            event.preventDefault();
        }

        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 192 || event.keyCode == 13 || event.keyCode == 32 || event.keyCode == 16 || event.keyCode == 190 || event.keyCode == 188) {
        }
        else {
            if (event.keyCode < 95) {
                if (event.keyCode < 48 || event.keyCode > 90) {
                    event.preventDefault();
                }
            }
            else {
                if ( event.keyCode > 105) {
                    event.preventDefault();
                }
            }
        }
    });
    */
    
   
      
   
    // Add slideDown animation to dropdown
    $('.dropdown').on('show.bs.dropdown', function (e) {
        $(this).find('.dropdown-menu').first().stop(true, true).slideDown();
    });

    // Add slideUp animation to dropdown
    $('.dropdown').on('hide.bs.dropdown', function (e) {
        $(this).find('.dropdown-menu').first().stop(true, true).slideUp();
    });

  

    $('.subcategoria').click(function () {
        $("#loader").slideDown('1000');
    });
    //mostrar caja de comentarios
   

    // código para active en los li de bootstrap
    var url = window.location;
    // Will only work if string in href matches with location
    $('ul.nav a[href="' + url + '"]').parent().addClass('activemenu');

    // Will also work for relative and absolute hrefs
    $('ul.nav a').filter(function () {
        return this.href == url;
    }).parent().addClass('activemenu');
    // fin código para active en los li de bootstrap

}   
);



function menu_class_change() //cambiar la clase activa del men+u al ser seleccionado
{
  /*  var cambio = false;
    $('.nav li a').each(function (index) {
        if (this.href.trim() == window.location) {
            $(this).parent().addClass("active");
            cambio = true;
        }
    });
    if (!cambio) {
        $('.nav li:first').addClass("active");
    }*/
}

//envio de comentario



function main() {

    validateFormComentario();
    
};



// $("#form_solicitud").validate();

function validateFormComentario() {

    $("[id*='form1']").validate({ // se cambio el nombre delform, ya pertenece a la base
        rules: {
            ctl00$ContentPlaceHolder1$con_nombre:
                {
                    required: true
                },
            ctl00$ContentPlaceHolder1$con_empresa:
                {
                    required: true
                },
            ctl00$ContentPlaceHolder1$con_pais:
               {
                   required: true
               },
            ctl00$ContentPlaceHolder1$con_ciudad:
               {
                   required: true
               },
            ctl00$ContentPlaceHolder1$con_comentario:
               {
                   required: true
               },
            ctl00$ContentPlaceHolder1$con_mail:
                {
                    required: true,
                    email: true
                }
        },//fin rules
        messages: {
            ctl00$ContentPlaceHolder1$con_nombre:
                {
                    required: 'Campo obligatorio'
                },
            ctl00$ContentPlaceHolder1$con_empresa:
              {
                  required: 'Campo obligatorio'
              },
            ctl00$ContentPlaceHolder1$con_pais:
              {
                  required: 'Campo obligatorio'
              },
            ctl00$ContentPlaceHolder1$con_ciudad:
              {
                  required: 'Campo obligatorio'
              },
            ctl00$ContentPlaceHolder1$con_comentario:
              {
                  required: 'Campo obligatorio'
              },
             ctl00$ContentPlaceHolder1$con_mail:
                {
                    required: 'Campo obligatorio',
                    email: 'Favor de teclear un mail válido'
                }
        },//fin messages

        submitHandler: function (form) { // esta estructura hace postback 
            $("#loader").slideDown('1000');

            form.submit();
            return;
        }
    });


}//fin funcion validar



function confirmacion_comentario() {

    $("#dialogcomentario").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                window.location.replace("Index.aspx");
            }
        }
    });


}
function error_comentario() {
    alert('Ha ocurrido un error, intenta nuevamente o escribe a soporte@toptus.com');
}

function error_comentario_producto(error) {
    alert('Error:' + error);
}

function confirmacion_comentario_producto()
{
    $("#dialog-message-comentario-ok").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                var url = window.location.href;
                window.location.replace(url);
               
            }
        }
    });
}

function confirmacion_comentario_producto_nomail() {
    $("#dialog-comentario-ok-nomail").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                var url = window.location.href;
                window.location.replace(url);

            }
        }
    });
}

function log_error_comentario_producto(mensaje)
{
    $("#mensaje_error").text(mensaje);
    $("#dialog-message-no").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                var url = window.location.href;
                window.location.replace(url);

            }
        }
    });
}

function caracter_nopermitido(mensaje) {
    $("#mensaje_error").text(mensaje);
    $("#dialog-message-no").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                $("#dialog-message-no").dialog("close");

            }
        }
    });
}

function mostrar_caja_respuesta(comentario,vendedor) { //vendedor a responder y comentario a responder
   
        
    $("#add-respuesta" + comentario).toggle("slow");
    $("#hdcomentario").val(comentario);
    $("#hdusuario").val(vendedor);
       
}

function mensaje_general(mensaje) {
    $("#mensaje").text(mensaje);
    $("#dialog-message").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                var url = window.location.href;
                window.location.replace(url);

            }
        }
    });
}

function mensaje_activacion(mensaje,url) {
    $("#mensaje").text(mensaje);
    $("#dialog-message-activacion").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                
                window.location.replace(url);

            }
        }
    });
}