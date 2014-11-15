$(document).ready(main);

function main() {

    $("#menu_general").hide();
    validateForm();
}

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
    $("#menu_general").hide();
    alert('wrong user/password');


}