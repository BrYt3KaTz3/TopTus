$(document).ready(function () {
    menu_class_change();
    // Add slideDown animation to dropdown
    $('.dropdown').on('show.bs.dropdown', function (e) {
        $(this).find('.dropdown-menu').first().stop(true, true).slideDown();
    });

    // Add slideUp animation to dropdown
    $('.dropdown').on('hide.bs.dropdown', function (e) {
        $(this).find('.dropdown-menu').first().stop(true, true).slideUp();
    });

  

    $('.subcategoria').click(function () {
        $("#loader").slideDown('1000');
    });


    // código para active en los li de bootstrap
    var url = window.location;
    // Will only work if string in href matches with location
    $('ul.nav a[href="' + url + '"]').parent().addClass('activemenu');

    // Will also work for relative and absolute hrefs
    $('ul.nav a').filter(function () {
        return this.href == url;
    }).parent().addClass('activemenu');
    // fin código para active en los li de bootstrap

}   
);



function menu_class_change() //cambiar la clase activa del men+u al ser seleccionado
{
  /*  var cambio = false;
    $('.nav li a').each(function (index) {
        if (this.href.trim() == window.location) {
            $(this).parent().addClass("active");
            cambio = true;
        }
    });
    if (!cambio) {
        $('.nav li:first').addClass("active");
    }*/
}

