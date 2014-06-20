function SeletorMenu(index){
    $("ul.nav.navbar-nav.side-nav li").each(function (componente, link) {
        if ($(this).hasClass("active")) {
            $(this).removeClass("active");
        }
    });
    $($("ul.nav.navbar-nav.side-nav li")[index]).addClass('active');
};