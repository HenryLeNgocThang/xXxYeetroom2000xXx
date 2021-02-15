
module.exports = {
    simpleLazyLoader: function () {
        var objects = document.images,
            images = [],
            downloadImage = new Image(),
            lazyloadElements = document.querySelectorAll("[lazyload]"),
            observerConfig = { attributes: true },
            observer = new MutationObserver(function (mutations) {
                mutations.forEach(function (mutation) {
                        if (mutation.type == "attributes") {
                            for (var i = 0; i < images.length; i++) {
                                downloadImage.src = images[i].dataset.src;

                            }
                            
                            for (var i = 0; i < lazyloadElements.length; i++) {
                                if (lazyloadElements[i].querySelector("img")) {
                                    if (lazyloadElements[i].querySelector("img").dataset.load && !lazyloadElements[i].classList.contains("load")) {
                                        lazyloadElements[i].classList.add("load");
                                    }
                                }
                            }
                        }
                    });
                });

        for (var i = 0; i < lazyloadElements.length; i++) {
            observer.observe(lazyloadElements[i], observerConfig)
        }

        // Parse objects from HTMLCollection to array
        for (var i = 0; i < objects.length; i++) {
            images.push(objects[i]);
            observer.observe(images[i], observerConfig);

            if (images[i].getBoundingClientRect().top >= 0 &&
                images[i].getBoundingClientRect().bottom <= window.innerHeight
            ) {
                images[i].dataset.load = true;
            }
        }

        load();
    
        document.addEventListener("scroll", function () {
            if (images.length > 0) {
                for (var i = 0; i < images.length; i++) {
                    if (images[i].dataset.load != true) {
                        if (images[i].getBoundingClientRect().top >= 0 &&
                            images[i].getBoundingClientRect().bottom <= window.innerHeight
                        ) {
                            images[i].dataset.load = true;
                        }
                    }
                }

                load();
            } else {
                observer.disconnect();
            }
        });
    
        downloadImage.onload = function () {
            for (var i = 0; i < images.length; i++) {
                if (images[i].dataset.load) {
                    if (images[i].dataset.src.indexOf("https://") != -1 || images[i].dataset.src.indexOf("https://") != -1) {
                        images[i].src = images[i].dataset.src;
                    } else {
                        images[i].src = "";
                    }
                    
                    images.splice(i, 1);
                }
            }
        };

        function load() {
            for (var i = 0; i < lazyloadElements.length; i++) {
                if (!lazyloadElements[i].querySelector("img")) {
                    if (lazyloadElements[i].getBoundingClientRect().top >= 0 &&
                        lazyloadElements[i].getBoundingClientRect().bottom <= window.innerHeight ||
                        lazyloadElements[i].getBoundingClientRect().top + lazyloadElements[i].offsetHeight >= 0 &&
                        lazyloadElements[i].getBoundingClientRect().bottom >= 0
                    ) {
                        lazyloadElements[i].classList.add("load");
                    }
                }
            }
        }
    }
}