$(document).ready(function () {
    "use strict";
    //caching the scroll top element
    var scrollButton = $("#scroll-top");
    $(window).scroll(function () {
        $(this).scrollTop() >= 200 ? scrollButton.show() : scrollButton.hide();
    });

    //click on button to scroll up
    scrollButton.click(function () {
        $("html,body").animate({ scrollTop: 0 }, 600);
    });

    //login form
    $(function () {
        // contact form animations
        $('#login').click(function () {
            $('#contactForm').fadeToggle();
        })
        $(document).mouseup(function (e) {
            var container = $("#contactForm");

            if (!container.is(e.target) // if the target of the click isn't the container...
                && container.has(e.target).length === 0) // ... nor a descendant of the container
            {
                container.fadeOut();
            }
        });
    });

    //register form
    $(function () {

        // contact form animations
        $('#register').click(function () {
            $('#contactForm2').fadeToggle();
        })
        $(document).mouseup(function (e) {
            var container = $("#contactForm2");

            if (!container.is(e.target) // if the target of the click isn't the container...
                && container.has(e.target).length === 0) // ... nor a descendant of the container
            {
                container.fadeOut();
            }
        });
    });
});