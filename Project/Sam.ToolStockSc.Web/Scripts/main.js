$.noConflict();

jQuery(document).ready(function($) {

	"use strict";

	[].slice.call( document.querySelectorAll( "select.cs-select" ) ).forEach( function(el) {
		new SelectFx(el);
	});

    jQuery(".selectpicker").selectpicker;


    $('.search-trigger').on('click', function(event) {
		event.preventDefault();
		event.stopPropagation();
		$('.search-trigger').parent('.header-left').addClass('open');
	});

	$('.search-close').on('click', function(event) {
		event.preventDefault();
		event.stopPropagation();
		$('.search-trigger').parent('.header-left').removeClass('open');
	});

	$('.equal-height').matchHeight({
		property: 'max-height'
	});

	// var chartsheight = $('.flotRealtime2').height();
	// $('.traffic-chart').css('height', chartsheight-122);


	// Counter Number
	$('.count').each(function () {
		$(this).prop('Counter',0).animate({
			Counter: $(this).text()
		}, {
			duration: 3000,
			easing: 'swing',
			step: function (now) {
				$(this).text(Math.ceil(now));
			}
		});
	});


	 
	 
	// Menu Trigger
	$("#menuToggle").on("click", function() {
		var windowWidth = $(window).width();   		 
		if (windowWidth<1010) { 
			$('body').removeClass('open'); 
			if (windowWidth<760){ 
				$('#left-panel').slideToggle(); 
			} else {
				$('#left-panel').toggleClass('open-menu');  
			} 
		} else {
			$('body').toggleClass('open');
			$('#left-panel').removeClass('open-menu');  
		} 
			 
	}); 

	 
	$(".menu-item-has-children.dropdown").each(function() {
		$(this).on('click', function() {
			var $tempText = $(this).children('.dropdown-toggle').html();
			$(this).children('.sub-menu').prepend('<li class="subtitle">' + $tempText + '</li>'); 
		});
	});


	// Load Resize 
	$(window).on("load resize", function() {
	    const windowWidth = $(window).width();  		 
	    if (windowWidth<1010) {
			$("body").addClass("small-device"); 
		} else {
			$("body").removeClass("small-device");  
		}

	});

    // -------------------------------------------------

    $('[data-toggle-second="tooltip"]').tooltip();

    $('.stop-propagation').on('click', function (e) {
        e.stopPropagation();
    });

    var result = $('#userInfo');

    $('#results').on('click', '.userInfo', function (e) {
    //$('.userInfo').click(function (e) {
        $.ajax({
            type: 'GET',
            url: '/api/Info/' + e.target.id,
            dataType: 'json',
            success: function (data, textStatus, xhr) {
                $("#userInfo").empty();
                $("#userInfoTemplate").tmpl(data).appendTo("#userInfo");
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log('Error in Operation');
            }  

        });

    });

    //$(function () {
    //    setTimeout(function () {
    //        $('#ErrorPage').removeClass('loading');
    //    }, 1000);
    //});
});

jQuery(document).on('click', '.table-row', function () {
    var route = $(this).attr("id");
    $("#results").load(route);
})

var ClearAllFilter = function (url, manufacturer, toolTypeId) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (html) {
            $('#results').html(html);
            $('#PageNumber').val(1);
            $('#PageSize').val(6);
            $('#searchString').val("");
            $('#Manufacturer').val(manufacturer);
            $('#toolTypeId').val(toolTypeId);
        }
    });
}

