
$(document).ready(function () {

    menu_class_change();
       
    });



function menu_class_change() //cambiar la clase activa del men+u al ser seleccionado
{
    var cambio = false;
    $('.nav li a').each(function (index) {
        if (this.href.trim() == window.location) {
            $(this).parent().addClass("active");
            cambio = true;
        }
    });
    if (!cambio) {
        $('.nav li:first').addClass("active");
    }
}