$(document).ready(function () {
    $("#loader").slideUp('1000');
    $("#btnUpload").click(function () {
        $("#loader").slideDown('1000');
    });

    $("#btn_actualizar_vendedor_basico").click(function () {
        $("#loader").slideDown('1000');
    });

});

   

function error_insertar(error)
{
    alert('Error:'+error);
}

function error_insertar_foto(error) {
    alert('Error:' + error);
}

function success_insertar() {
    alert("Información actualizada con éxito");
}