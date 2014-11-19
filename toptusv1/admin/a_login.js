$(document).ready(main);

function main() {
    
  
    validateForm();
}

function validateForm() {

    $("[id*='form_admin_login']").validate({
        rules: {
            a_usuario:
                {
                    required: true
                },
            a_password:
                {
                    required: true
                }
        },//fin rules
        messages: {
            a_usuario:
                {
                    required: 'Campo obligatorio'
                },
            a_password:
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
    $("#menu_general_admin").hide();
    $("#titulo_admin").hide();
    alert('Datos Incorrectos');
    $("#a_usuario").focus();


}