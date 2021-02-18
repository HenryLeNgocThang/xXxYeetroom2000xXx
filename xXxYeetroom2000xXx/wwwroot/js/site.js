// Imports
import $ from "jquery";
import { simpleLazyLoader } from "../js/lazyloader";
import cookie from "../js/cookie";
import coloring from "../js/coloring";
import urlvalidator from "../js/urlvalidator";
import interact from "interactjs";

if (/MSIE \d|Trident.*rv:/.test(navigator.userAgent)) {
    window.location = 'microsoft-edge:' + window.location;
    setTimeout(function () {
        window.location = 'https://go.microsoft.com/fwlink/?linkid=2135547';
    }, 1);
}

$(document).ready(function () {
    // Good luck have fun :^)

    var saveButton = $("#saveSettings");
    var messageBox = $("#message-box");

    var pageSettings = {
        primary: {
            element: document.querySelector("#primary-color"),
            rootname: "--primary",
            color: "#483CCC",
            changedColor: ""
        },
        background: {
            element: document.querySelector("#background-color"),
            rootname: "--background-color",
            color: "#E1E7EF",
            changedColor: ""
        }
    }

    simpleLazyLoader();

    $("#page-settings button").click(function () {
        $('#page-settings-modal').modal('hide');
    });

    if (!cookie.get("init")) {
        messageBox.addClass("play").text("Raum betreten!");
        cookie.set("init", true);
        setTimeout(function () {
            messageBox.removeClass("play");
        }, 5100);
    }

    Object.keys(pageSettings).forEach(setting => {
        if (cookie.get(setting)) {
            pageSettings[setting]["color"] = cookie.get(setting);
            pageSettings[setting]["element"].value = pageSettings[setting]["color"];
            document.documentElement.style.setProperty(pageSettings[setting]["rootname"], pageSettings[setting]["color"]);

            var brightness;

            brightness = coloring.brightness(
                coloring.hexToRgb(pageSettings[setting]["color"]).r,
                coloring.hexToRgb(pageSettings[setting]["color"]).g,
                coloring.hexToRgb(pageSettings[setting]["color"]).b,
                "#111111",
                "#f8f9fa"
            );

            document.documentElement.style.setProperty(pageSettings[setting]["rootname"], pageSettings[setting]["color"]);

            switch (pageSettings[setting]["rootname"]) {
                case "--background-color":
                    document.documentElement.style.setProperty("--dark", brightness);
                    break;
                case "--primary":
                    document.documentElement.style.setProperty("--light", brightness);
                    if (brightness == "#111111") {
                        document.documentElement.style.setProperty("--gray-dark", "#f8f9fa");
                    } else {
                        document.documentElement.style.setProperty("--gray-dark", "#111111");
                    }
                    break;
            }
        }
    });

    $(".post-comments").each(function () {
        var $showCommentsBtn = $(this).find("a[data-toggle='collapse']") ? $(this).find("a[data-toggle='collapse']") : null;
        var $commentsText = $(this).find('.collapse p').toggle() ? $(this).find('.collapse p').toggle() : null;
        var $comments = $(this).find(".collapse").toggle();

        if ($showCommentsBtn && $commentsText) {
            if ($commentsText.length >= 2) {
                $showCommentsBtn.addClass("show");
                $comments.height(`${$commentsText.height() + 4}px`);
            } else {
                $comments.addClass("show");
                $showCommentsBtn.attr("aria-expanded", true);
                $showCommentsBtn.addClass("collapsed");
            }

            $showCommentsBtn.click(function () {
                setTimeout(function () {
                    if (!$showCommentsBtn.hasClass("collapsed")) {
                        $showCommentsBtn.text("Weniger anzeigen");
                    } else {
                        $showCommentsBtn.text("Alle Kommentare anzeigen");
                    }
                }, 300);

                if (!$showCommentsBtn.hasClass("collapsed")) {
                    $comments.collapse('hide');
                    $comments.height(`${$commentsText.height() + 4}px`);
                } else {
                    $comments.collapse('show');
                }
            });
        }
    });

    for (var setting in pageSettings) {
        pageSettings[setting]["element"].addEventListener("input", function () {
            var brightness;

            pageSettings[this.dataset.setting]["changedColor"] = this.value;
            brightness = coloring.brightness(
                coloring.hexToRgb(pageSettings[this.dataset.setting]["changedColor"]).r,
                coloring.hexToRgb(pageSettings[this.dataset.setting]["changedColor"]).g,
                coloring.hexToRgb(pageSettings[this.dataset.setting]["changedColor"]).b,
                "#111111",
                "#f8f9fa"
            );
            document.documentElement.style.setProperty(pageSettings[this.dataset.setting]["rootname"], this.value);

            switch (pageSettings[this.dataset.setting]["rootname"]) {
                case "--background-color":
                    document.documentElement.style.setProperty("--dark", brightness);
                    break;
                case "--primary":
                    document.documentElement.style.setProperty("--light", brightness);
                    if (brightness == "#111111") {
                        document.documentElement.style.setProperty("--gray-dark", "#f8f9fa");
                    } else {
                        document.documentElement.style.setProperty("--gray-dark", "#111111");
                    }
                    break;
            }
        });
    }

    saveButton.click(function () {
        for (var setting in pageSettings) {
            pageSettings[setting]["color"] = pageSettings[setting]["changedColor"];
            cookie.set(setting, pageSettings[setting]["color"], 2100);
        }

        messageBox.addClass("play").text("Erfolgreich gespeichert!");
        setTimeout(function () {
            messageBox.removeClass("play");
        }, 5100);
    });

    $('a[href^="#"]:not([data-toggle="collapse"])').on('click', function (e) {
        e.preventDefault();
        var target = this.hash;
        var $target = $(target);
        $('html, body').stop().animate({
            'scrollTop': $target.offset().top
        }, 900, 'swing', function () {
            window.location.hash = target;
        });
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
            $("input.form-control, textarea.form-control").each(function () {
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