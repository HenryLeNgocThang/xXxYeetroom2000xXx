// Imports
import $ from "jquery";
import lazyloader from "../js/lazyloader";

$(document).ready(function () {
    // Good luck have fun :^)

    lazyloader.simpleLazyLoader();

    // If someone clicks on the document
    $(document).on("click", function (event) {
        // Current target
        var $currentTarget = $(event.target);

        // Hide form if pressed target is not form-submit or form-control input
        if (!$currentTarget.hasClass("form-submit") && !$currentTarget.hasClass("form-control")) {
            $("form.show").removeClass("show");
        }

        if ($currentTarget.hasClass("show-form")) {
            // Show form if pressed element has class show-form
            $currentTarget.prev().addClass("show");

            // Reset every input fields if pressed target is not input field from target
            $("input.form-control").each(function () {
                $(this).val("");
            });
        }
    });

    $(document).scroll(function () {
        clearTimeout($.data(this, 'scrollTimer'));
        $("main .posts").addClass("scrolling");
        $.data(this, 'scrollTimer', setTimeout(function () {
            $("main .posts").removeClass("scrolling");
        }, 100));
    });
});