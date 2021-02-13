// Imports
import $ from "jquery";
import lazyloader from "../js/lazyloader";
import urlvalidator from "../js/urlvalidator";
import interact from "interactjs";

$(document).ready(function () {
    // Good luck have fun :^)

    lazyloader.simpleLazyLoader();

    $("#page-settings button").click(function () {
        $('#page-settings-modal').modal('hide');
    });

    $("#primary-color").change(function () {
        document.documentElement.style.setProperty('--primary', $(this).val());
    });

    $("#background-color").change(function () {
        document.documentElement.style.setProperty('--background-color', $(this).val());
    });

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

    $(".posts .post p").each(function () {
        var strings = $(this).text().split(" ");

        strings.forEach((string) => {
            if (urlvalidator(string)) {
                $(this).html($(this).html().replace(string, `<a href="${string}" target="_blank">${string}</a>`));
            }
        });
    });

    interact('.draggable')
        .draggable({
            inertia: true,
            modifiers: [
                interact.modifiers.restrictRect({
                    restriction: 'parent',
                    endOnly: true
                })
            ],
            autoScroll: true,

            listeners: {
                move: dragMoveListener,

                end(event) {
                    var textEl = event.target.querySelector('p')

                    textEl && (textEl.textContent =
                        'moved a distance of ' +
                        (Math.sqrt(Math.pow(event.pageX - event.x0, 2) +
                            Math.pow(event.pageY - event.y0, 2) | 0))
                            .toFixed(2) + 'px')
                }
            }
        })

    function dragMoveListener(event) {
        var target = event.target
        var x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx
        var y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy

        target.style.webkitTransform =
            target.style.transform =
            'translate(' + x + 'px, ' + y + 'px)'

        target.setAttribute('data-x', x)
        target.setAttribute('data-y', y)
    }

    window.dragMoveListener = dragMoveListener;
});