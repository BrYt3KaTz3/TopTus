
$(document).ready(main);

function main() {

    validateForm();
};


function validateForm() {

    $("[id*='form1']").validate({ // se cambio el nombre delform, ya pertenece a la base
        rules: {
            ctl00$ContentPlaceHolder_Vendedor$ven_nick:
                {
                    required: true
                },
            ctl00$ContentPlaceHolder_Vendedor$ven_nombre:
                {
                    required: true
                },
            ctl00$ContentPlaceHolder_Vendedor$ven_apellidop:
                {
                    required: true,
                    
                },
            ctl00$ContentPlaceHolder_Vendedor$ven_ciudad:
                {
                    required: true,

                },
            ctl00$ContentPlaceHolder_Vendedor$ven_empresa:
                {
                    required: true,

                }
        },//fin rules
        messages: {
            ctl00$ContentPlaceHolder_Vendedor$ven_nick:
                {
                    required: 'Campo obligatorio'
                },
            ctl00$ContentPlaceHolder_Vendedor$ven_nombre:
               {
                   required: 'Campo obligatorio'
               },
            ctl00$ContentPlaceHolder_Vendedor$ven_apellidop:
                {
                    required: 'Campo obligatorio',
                  
                },
            ctl00$ContentPlaceHolder_Vendedor$ven_ciudad:
               {
                   required: 'Campo obligatorio'
               },
            ctl00$ContentPlaceHolder_Vendedor$ven_empresa:
               {
                   required: 'Campo obligatorio'
               }

        },//fin messages

        submitHandler: function (form) { // esta estructura hace postback 
            $("#loader").slideDown('1000');

            form.submit();
            return;
        }
    });


}//fin funcion validar