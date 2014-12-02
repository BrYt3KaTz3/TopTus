$(document).ready(main);

function main()
{
   
   
}

function solicitud_aprobada()
{
    $("#dialog").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                window.location.replace("a_solicitud.aspx");
            }
        }
    }); 
}

$("#btn_aceptar_solicitud").click(function () {
    $("#loader").slideDown('1000');
})