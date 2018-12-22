(function($) {
    var $mobileMenuOpenBtn = $('#header-mobile-open');
    var $mobileMenuCloseBtn = $('#header-mobile-close');
    var $headerContainer = $('#header-main');
    var headerOpenedClass = 'opened';

    $mobileMenuOpenBtn.click(openMobileHeader);
    $mobileMenuCloseBtn.click(closeMobileHeader);

    function openMobileHeader() {
        $headerContainer.addClass(headerOpenedClass);
    }

    function closeMobileHeader() {
        $headerContainer.removeClass(headerOpenedClass);
    }
})(jQuery);