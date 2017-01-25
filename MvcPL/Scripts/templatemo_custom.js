function showhide() {
    var div = document.getElementById("newpost");
    if (div.style.display !== "none") {
        div.style.display = "none";
    } else {
        div.style.display = "block";
    }
}

$(document).ready(function () {
    $('ul li a').click(function () {
        $('li a').removeClass("active");
        $(this).addClass("active");
    });
});

$('.gallery_more').click(function () {
    var $this = $(this);
    $this.toggleClass('gallery_more');
    if ($this.hasClass('gallery_more')) {
        $this.text('Load More');
    } else {
        $this.text('Load Less');
    }
});

jQuery(document).ready(function ($) {

    /************** Menu Content Opening *********************/
    $(" a, .responsive_menu a").click(function () {
        var id = $(this).attr('class');
        id = id.split('-');
        $("#menu-container .content").hide();
        $("#menu-container #menu-" + id[1]).addClass("animated fadeInDown").show();
        $("#menu-container .homepage").hide();
        $(".support").hide();
        $(".testimonials").hide();
        
    });

    $(window).load(function () {
        $("#menu-container .products").hide();
    });

    $(" a.templatemo_home").addClass('active');

    $(" a.templatemo_home, .responsive_menu a.templatemo_home").click(function () {
        $("#menu-container .homepage").addClass("animated fadeInDown").show();
        $(this).addClass('active');
        $(" a.templatemo_page2, .responsive_menu a.templatemo_page2").removeClass('active');
        $(" a.templatemo_page3, .responsive_menu a.templatemo_page3").removeClass('active');
        $(" a.templatemo_page5, .responsive_menu a.templatemo_page5").removeClass('active');
        
    });

    $(" a.templatemo_page2, .responsive_menu a.templatemo_page2").click(function () {
        $("#menu-container .team").addClass("animated fadeInDown").show();
        $(this).addClass('active');
        $("a.templatemo_home, .responsive_menu a.templatemo_home").removeClass('active');
        $("a.templatemo_page3, .responsive_menu a.templatemo_page3").removeClass('active');
        $("a.templatemo_page5, .responsive_menu a.templatemo_page5").removeClass('active');
        
    });

    $(" a.templatemo_page3, .responsive_menu a.templatemo_page3").click(function () {
        $("#menu-container .services").addClass("animated fadeInDown").show();
        $(".our-services").show();
        $(this).addClass('active');
        $(" a.templatemo_page2, .responsive_menu a.templatemo_page2").removeClass('active');
        $(" a.templatemo_home, .responsive_menu a.templatemo_home").removeClass('active');
        $(" a.templatemo_page5, .responsive_menu a.templatemo_page5").removeClass('active');
        
    });

    $(" a.templatemo_page5, .responsive_menu a.templatemo_page5").click(function () {
        $("#menu-container .contact").addClass("animated fadeInDown").show();
        $(this).addClass('active');
        $(" a.templatemo_page2, .responsive_menu a.templatemo_page2").removeClass('active');
        $(" a.templatemo_page3, .responsive_menu a.templatemo_page3").removeClass('active');
        $(" a.templatemo_home, .responsive_menu a.templatemo_home").removeClass('active');

        loadScript();
        
    });



    /************** Gallery Hover Effect *********************/
    $(".overlay").hide();

    $('.gallery-item').hover(
	  function () {
	      $(this).find('.overlay').addClass('animated fadeIn').show();
	  },
	  function () {
	      $(this).find('.overlay').removeClass('animated fadeIn').hide();
	  }
	);


    /************** LightBox *********************/
    $(function () {
        $('[data-rel="lightbox"]').lightbox();
    });


    $("a.menu-toggle-btn").click(function () {
        $(".responsive_menu").stop(true, true).slideToggle();
        return false;
    });

    $(".responsive_menu a").click(function () {
        $('.responsive_menu').hide();
    });

});