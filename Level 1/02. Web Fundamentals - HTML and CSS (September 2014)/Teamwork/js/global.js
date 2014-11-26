jQuery(document).ready(function($) {
			
	//Show up-to-top button
	$(window).scroll(function () {
		if ($(this).scrollTop() > 100) {
			$('#up-to-top').fadeIn();
		} else {
			$('#up-to-top').fadeOut();
		}
	});
			
	//Animate move to top
	$('#up-to-top').click(function () {
		$('html, body').animate({ scrollTop: 0 }, 800);
		return false;
	});

    //Mobile menu open
    $('.site-nav-toggle').click(function() {
        $('#navigation-mobile').slideToggle();
        $(this).find('div:hidden').show().siblings().hide();
	});

    // Hide mobile-menu > 768
    $(window).resize(function() {
        if ($(window).width() > 768) {
            $("#navigation-mobile").hide();
        }
    });

});