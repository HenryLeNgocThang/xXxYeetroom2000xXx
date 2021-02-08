// Imports
import $ from "jquery";

$(document).ready(function () {
    // Good luck have fun :^)

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
            $currentTarget.next().addClass("show");

            // Reset every input fields if pressed target is not input field from target
            $("input.form-control").each(function () {
                $(this).val("");
            });
        }
    });
});