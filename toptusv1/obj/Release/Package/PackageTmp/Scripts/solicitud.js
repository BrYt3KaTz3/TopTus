$(document).ready(main);

function main() {

    validateForm();
};



    // $("#form_solicitud").validate();

function validateForm(){

    $("[id*='form1']").validate({ // se cambio el nombre delform, ya pertenece a la base
         rules: {
             ctl00$ContentPlaceHolder1$sol_apellidop:
                 {
                     required: true
                 },
             ctl00$ContentPlaceHolder1$sol_nombre:
                 {
                     required: true
                 },
             ctl00$ContentPlaceHolder1$sol_email:
                 {
                     required: true,
                     email: true
                 }
         },//fin rules
         messages: {
             ctl00$ContentPlaceHolder1$sol_apellidop:
                 {
                     required: 'Campo obligatorio'
                 },
             ctl00$ContentPlaceHolder1$sol_nombre:
                {
                    required: 'Campo obligatorio'
                },
             ctl00$ContentPlaceHolder1$sol_email:
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

function confirmacion_solicitud()
{
   
    $("#dialog").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                window.location.replace("Index.aspx");
            }
        }
    });
    

}



function error_solicitud(mensaje) {
    $("#error_dialog").text(mensaje);
    $("#dialog_error").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                window.location.replace("solicitud.aspx");
            }
        }
    });
}
