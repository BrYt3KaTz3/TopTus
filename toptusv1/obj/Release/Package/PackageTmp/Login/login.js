$(document).ready(main);

function main() {

   /* $("#menu_general").hide();
    $("#header").hide();
    $("#footer").hide();
    $(".footer-bottom").hide();
    $("#logindiv").hide();*/
    
    $('#olvidado').click(function (e) {
        
        $('div#form-olvidado').fadeIn('700');
        $('div#form-login').hide();
    });
    $('#acceso').click(function (e) {
        $('div#form-olvidado').hide();
        $('div#form-login').fadeIn('700');
    });

}

function validateFormRecuperar() {

    $("[id*='form1']").validate({
        rules: {
            ctl00$ContentPlaceHolder1$txtcorreo:
                {
                    required: true,
                    email: true
                }
        },//fin rules
        messages: {
            ctl00$ContentPlaceHolder1$txtcorreo:
                {
                    required: 'Campo obligatorio',
                    email: 'Favor de teclear un mail válido'
                }
        },//fin messages

        submitHandler: function (form) { // esta estructura hace postback 
            $("#loader").slideDown('1000');
            form.submit().delay('8000');
            return;
        }
    });


}//fin funcion validar
function validateForm() {

    $("[id*='form1']").validate({
        rules: {
            ctl00$ContentPlaceHolder1$log_usuario:
                {
                    required: true,
                    email: true
                },
            ctl00$ContentPlaceHolder1$log_password:
                {
                    required: true
                }
        },//fin rules
        messages: {
            ctl00$ContentPlaceHolder1$log_usuario:
                {
                    required: 'Campo obligatorio',
                    email: 'Favor de teclear un mail válido'
                },
            ctl00$ContentPlaceHolder1$log_password:
               {
                   required: 'Campo obligatorio'
               }
        },//fin messages

        submitHandler: function (form) { // esta estructura hace postback 
            $("#loader").slideDown('1000');
            form.submit().delay('8000');
            return;
        }
    });


}//fin funcion validar

function wrong_user() {
    /*$("#menu_general").hide();*/
    alert('wrong user/password');


}



function confirmacion_recuperar() {

    $("#dialog-recuperacion-ok").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                window.location.replace("Index.aspx");
            }
        }
    });


}

function error_recuperar() {

    $("#dialog-message-error").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });


}

function error_recuperar_dos() {

    $("#dialog_error_2").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });


}