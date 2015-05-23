$(document).ready(function () {
    $("#loader").slideUp('1000');
    $("#btnUpload").click(function () {
        $("#loader").slideDown('1000');
    });
    
    $("#btn_actualizar_vendedor_basico").click(function () {
        $("#loader").slideDown('1000');
    });
    $("#btnRedes").click(function () {
        $("#loader").slideDown('1000');
    });

    $("#btnAgregarCategoria").click(function () {
        $("#loader").slideDown('1000');
    });

    $("#add_product").hide();

    $("#link_add_product").click(function () {
        $("#add_product").toggle("slow");
    });
    
    $("#btnAgregarProducto").click(function () {
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
  
         $(function () {
             $("#dialog-message").dialog({
                 modal: true,
                 buttons: {
                     Ok: function () {
                         var url = window.location.href;
                         window.location.replace(url);
                     }
                 }
             });
         });
    
}

function success_insertar_producto(producto) {

    $(function () {
        $("#dialog-message-producto").dialog({
            modal: true,
            buttons: {
                Ok: function () {
                    var url = window.location.href;
                    window.location.replace("catprod.aspx?prod="+producto);
                }
            }
        });
    });

}

function success_insertar_categoria(producto) {

    $(function () {
        $("#dialog-message").dialog({
            modal: true,
            buttons: {
                Ok: function () {
                    var url = window.location.href;
                    window.location.replace("fotosprod.aspx?prod=" + producto);
                }
            }
        });
    });

}