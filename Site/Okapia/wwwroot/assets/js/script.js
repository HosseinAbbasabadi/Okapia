(function($) {
	
	"use strict";


    // Back to top
    $.scrollUp({
        scrollText: '<i class="fa fa-angle-up"></i>',
        easingType: 'linear',
        scrollSpeed: 900,
        animation: 'fade'
    });


    // Menu sticky
    $(window).on('scroll',function() {    
        var scroll = $(window).scrollTop();
        if (scroll < 20) {
         $(".header-area").removeClass("sticky-header");
        }else{
         $(".header-area").addClass("sticky-header");
        }
     });
    
	
    //js code for mobile menu toggle
   $(".menu-toggle").on("click", function() {
       $(this).toggleClass("is-active");
   });

    // banner content animation
    $(".hero-area").on("translate.owl.carousel", function() {
        $(".hero-sub h1").removeClass("animated flipInX").css("opacity", "0"),
        $(".hero-sub p").removeClass("animated fadeInUp").css("opacity", "0"),
        $(".hero-sub a").removeClass("animated fadeInUp").css("opacity", "0")
    }),
    $(".hero-area").on("translated.owl.carousel", function() {
        $(".hero-sub h1").addClass("animated flipInX").css("opacity", "1"),
        $(".hero-sub p").addClass("animated fadeInUp").css("opacity", "1"),
        $(".hero-sub a").addClass("animated fadeInUp").css("opacity", "1")
    });


        
     //portfolio filtering

    var $portfolio = $('.portfolio');
    if ($.fn.imagesLoaded && $portfolio.length > 0) {
        imagesLoaded($portfolio, function () {
            $portfolio.isotope({
                itemSelector: '.portfolio-item',
                filter: '*'
            });
            $(window).trigger("resize");
        });
    }

    $('.portfolio-filter').on('click', 'a', function (e) {
        e.preventDefault();
        $(this).parent().addClass('active').siblings().removeClass('active');
        var filterValue = $(this).attr('data-filter');
        $portfolio.isotope({filter: filterValue});
    });

    
     // Portfolio popup

    $(".portfolio-gallery").each(function () {
        $(this).find(".popup-gallery").magnificPopup({
            type: "image",
            gallery: {
                enabled: true
            }
        });
    }); 

    $('.video-popup').magnificPopup({
        type: 'iframe',
    });


    // Hero Slider
    //$('.hero-area').owlCarousel({
    //    loop:true,
    //    dots: false,
    //   // autoplay: true,
    //    mouseDrag: false,
    //    animateOut: 'fadeOut',
    //    animateIn: 'fadeIn',
    //    autoplayTimeout: 10000,
    //    smartSpeed: 1500,
    //    nav:true,
    //    navText: [
    //        '<i class="fa fa-angle-left"></i>',
    //        '<i class="fa fa-angle-right"></i>'
    //    ],
    //    responsive:{
    //        0:{
    //            items:1,
    //            nav:false,
    //        },
    //        576:{
    //            items:1
    //        },
    //        1000:{
    //            items:1
    //        }
    //    }
    //});



    // Partner Slider
    $('.partners-logo').owlCarousel({
        loop:true,
        dots: false,
        autoplay: true,
        margin:30,
        smartSpeed: 1500,
        responsive:{
            0:{
                items:2
            },
            600:{
                items:3
            },
            1000:{
                items:5
            }
        }
    });

    
    // Partner Slider
    $('.testimonials').owlCarousel({
        loop:true,
        dots: false,
        autoplay: true,
        margin:30,
        smartSpeed: 1500,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:2
            },
            1000:{
                items:3
            }
        }
    });

    //Counter-JS
    $('.count').counterUp({
        delay: 10,
        time: 2000
    });



    // Preloader Js
    $(window).on('load', function(){
      $('.preloader').fadeOut(1000); // set duration in brackets    
    });


    // Wow js active
    new WOW().init(); 
    


    // // Nice Select
    // $('.select-bar').niceSelect();
    

    $('.star-rating i').each(function(){        
        var backgroundSize = $(this).css('background-size');
        backgroundSize =parseFloat(backgroundSize);
        var Width = $(this).width();
        var backgroundSizePixel = (Width * backgroundSize) / 100;
        $(this).parent().find('span > span').css('background-size' , backgroundSizePixel +'px');
    })
    

	
})(jQuery);


$(function(){
var swiper = new Swiper('.swiper-container', {	
	autoplay:true,	
	navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
      },
  });
})