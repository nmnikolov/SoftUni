jQuery(document).ready(function($) {

    $("#answer").click(
        function() {
            $("#answer-form").slideToggle();
            this.value = this.value === "Hide" ? "Answer" : "Hide";
        }
    );

    $(".save").click(
        function() {
            this.value = this.value === "Save" ? "updating..." : "Save";
        }
    );

    $(".add").click(
        function() {
            this.value = this.value === "Add" ? "sending..." : "Add";
        }
    );

    $(".reply").click(
        function() {
            this.value = "sending..."
        }
    );

    $("#questions-button").click(
        function() {
            $("#profile-questions-details").slideToggle();
            this.value = this.value === "Hide" ? "Questions started" : "Hide";
        }
    );


    //toggle search form
    $("#search-toggle").click(
        function() {
            var search = $("#search-form");
            if(search.css('display')=='none') {
                search.slideToggle();
                $("#search-text").val("").focus();
                $(this).find('svg:hidden').show().siblings().hide();
                //$("#search-toggle-show").hide().sibling().show();
            }
        }
    );

    //hide search for on focusout
    $("#search-text").focusout(
        function() {
            $("#search-form").slideUp();
            $("#search-toggle").find('svg:hidden').show().siblings().hide();
            //$("#search-toggle-show").show().sibling().hide();
        }
    );



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

    //$( ".registration-hints > input" ).hover(function() {
    //    $hint = $(this).siblings();
    //    $hint.css('display' , 'inline-block');
    //}, function() {
    //    $hint = $(this).siblings();
    //    $hint.css('display' , 'none');
    //});


    $( ".registration-hints > input" ).focusin(
        function() {
        $hint = $(this).siblings();
        $hint.css('display' , 'inline-block');
    });

    $( ".registration-hints > input" ).focusout(
        function() {
            $hint = $(this).siblings();
            $hint.css('display' , 'none');
    });

});