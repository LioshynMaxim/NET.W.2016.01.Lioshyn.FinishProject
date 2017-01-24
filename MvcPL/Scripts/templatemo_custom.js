//"use strict";

//jQuery(document).ready(function($){

/************** Menu Content Opening *********************/
//	$(".main_menu a, .responsive_menu a").click(function(){
//		var id =  $(this).attr("class");
//		id = id.split("-");
//		$("#menu-container .content").hide();
//		$("#menu-container #menu-"+id[1]).addClass("animated fadeInDown").show();
//		$("#menu-container .homepage").hide();
//		$(".support").hide();
//		$(".testimonials").hide();
//		return false;
//	});

//	$( window ).load(function() {
//	  $("#menu-container .products").hide();
//	});

//$(".main_menu a.templatemo_home").addClass("active");

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



//	/************** Gallery Hover Effect *********************/
//	$(".overlay").hide();

//	$(".gallery-item").hover(
//	  function() {
//	    $(this).find(".overlay").addClass("animated fadeIn").show();
//	  },
//	  function() {
//	    $(this).find(".overlay").removeClass("animated fadeIn").hide();
//	  }
//	);

$('.gallery_more').click(function () {
    var $this = $(this);
    $this.toggleClass('gallery_more');
    if ($this.hasClass('gallery_more')) {
        $this.text('Load More');
    } else {
        $this.text('Load Less');
    }
});

//	/************** LightBox *********************/
//	$(function(){
//		$('[data-rel="lightbox"]').lightbox();
//	});


//	$("a.menu-toggle-btn").click(function() {
//	  $(".responsive_menu").stop(true,true).slideToggle();
//	  return false;
//	});

//    $(".responsive_menu a").click(function(){
//		$(".responsive_menu").hide();
//	});

//});