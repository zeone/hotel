(function ($) {
    $(document).ready(function () {
        $('.room-slide').each(function () {
            lightGallery($(this)[0]);
        });

        $('.room-type-closed__btn').click(function () {
            closeAllDetails();
            openDetails($(this));
        });
        $('.room-type-opened__close').click(function () {
           closeDetails($(this));
        });

    });

    function openDetails($btn) {
        var $wrapper = $btn.closest('.room-type');
        $wrapper.addClass('opened');

        $wrapper.find('.room-gallery').slick({
            arrows: false,
            dots: true,
            draggable: false,
        });

        $('html, body').animate({
            scrollTop: $wrapper.offset().top
        }, 1500);

    }
    function closeDetails($btn) {
        var $wrapper = $btn.closest('.room-type');
        $wrapper.removeClass('opened');
        $wrapper.find('.room-gallery').slick('unslick');
    }
    function closeAllDetails() {
        $('.room-type').removeClass('opened');
    }
})(jQuery);