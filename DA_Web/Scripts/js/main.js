(function ($) {
    "use strict";

$(document).ready(function(){
/*---------------------------------------
	curency and language js
----------------------------------------- */	
	$(".current-currency").on( "click", function(){
		$(".currency-toogle").slideToggle(400);
	});
	$(".current-lang").on( "click", function(){
		$(".language-toogle").slideToggle(400);
	});	
		
/*---------------------------------------
	price range ui slider js
----------------------------------------- */		
	$( "#price-range" ).slider({
		range: true,
		min: 1,
		max: 100,
		values: [ 10, 90 ],
		slide: function( event, ui ) {
			$( "#slidevalue" ).val( "$" + ui.values[ 0 ] + " - $" + ui.values[ 1 ] );
		}
	});
	$( "#slidevalue" ).val( "$" + $( "#price-range" ).slider( "values", 0 ) +
		" - $" + $( "#price-range" ).slider( "values", 1 ) );	
		
/*---------------------------------------
	scroll to top
----------------------------------------- */	
	$(window).scroll(function(){
		if ($(this).scrollTop() > 250) {
			$('.bstore-scrollertop').fadeIn();
		} else {
			$('.bstore-scrollertop').fadeOut();
		}
	});
	//Click event to scroll to top
	$('.bstore-scrollertop').on( "click", function(){
		$('html, body').animate({scrollTop : 0},800);
		return false;
	});	
	
/*---------------------------------------
	mobile menu
----------------------------------------- */	
		$('.mobile-menu').meanmenu();	
		
/*---------------------------------------
	new  product, sale product carousel
----------------------------------------- */	
	
		
/*---------------------------------------
	featured  product, bestseller, carousel
----------------------------------------- */	

		
/*---------------------------------------
	related-product  carousel
----------------------------------------- */	
	
/*---------------------------------------
	latest news carousel
----------------------------------------- */	
	
		
/*---------------------------------------
	client carousel
----------------------------------------- */	
	
/*---------------------------------------
	home 2 left category menu
----------------------------------------- */	
	$('.category-heading').on( "click", function(){
		$('.category-menu-list').slideToggle(300);
	});	
		
/*---------------------------------------
	home 2 new product, home 2 sale product carousel
----------------------------------------- */	
	
		
/*---------------------------------------
	sidebar best seller carousel
----------------------------------------- */
	
/*---------------------------------------
	tab product carousel	
----------------------------------------- */	
	
			
/*---------------------------------------
	mainSlider
----------------------------------------- */	
	$('#mainSlider').nivoSlider({
		controlNav: true,
		 directionNav: false,
		 pauseTime: 5000,
		nextText: '<div class="slider-bolut"></div>',
		prevText: '<div class="slider-bolut"></div>'
		
	});		

/*---------------------------------------
	single product product thumbnail
----------------------------------------- */	
	$('.bxslider').bxSlider({
	  minSlides: 3,
	  maxSlides: 3,
	  slideWidth: 88,
	  responsive:true,
	   nextText: '<i class="fa fa-angle-left"></i>',
	  prevText: '<i class="fa fa-angle-right"></i>'
	});	

/*---------------------------------------
	francy box lightbox
----------------------------------------- */	
	$(".fancybox").fancybox();	

/*-----------------------------------------
	cart plus minus button
--------------------------------------------*/	  
	
	  $(".qtybutton").on("click", function() {
		var $button = $(this);
		var oldValue = $button.parent().find("input").val();
		if ($button.text() == "+") {
		  var newVal = parseFloat(oldValue) + 1;
		} else {
		   // Don't allow decrementing below zero
		  if (oldValue > 1) {
			var newVal = parseFloat(oldValue) - 1;
			} else {
			newVal = 1;
		  }
		  }
		$button.parent().find("input").val(newVal);
	  });
		
}); 

})(jQuery);	