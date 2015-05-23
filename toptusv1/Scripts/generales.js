$(document).ready(function () {
    menu_class_change();
    main();
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