$(document).ready(main);

function main() {

    validateForm();
};



    // $("#form_solicitud").validate();

function validateForm(){

     $("[id*='form_solicitud']").validate({
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
             form.submit().delay('8000');
             return;
         }
     });


}//fin funcion validar

function confirmacion_solicitud()
{
   
    alert('solicitud procesada con éxito');
    

}
function error_solicitud() {
    alert('error al procesar la solicitud');
}
function mail_ya_registrado() {
    alert('Este correo ya está dado de alta');
}