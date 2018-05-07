(function ($) {
    var counter = 10;
    var loadBtn, picsCount;
    $(document).ready(function () {
        loadBtn = $("#loadPicsPhoto");
        picsCount = parseInt($("#picsCount").val());
        checkButton();

        setGalleryHeight();

        function appendPics() {
            var galObj = $('#gallery-wrapper');
            $.getJSON('NextPics',
                {
                    nextCount: counter
                }, function (resp) {
                    resp.forEach(function (item) {
                        galObj.append('<a class="gallery-thumbnail" href="/Content/img/gallery/thumb/tumb_' + item.ImgName + '">' +
                            '<img class="gallery-image" src="/Content/img/gallery/' + item.ImgName + '" />' +
                            '</a >');
                    });
                    setGalleryHeight();
                    lightGallery(document.getElementById('gallery-wrapper'));
                    checkButton();
                });
        }


        $('#loadPicsPhoto').click(function (e) {
            counter += 10;
            appendPics();
        });
    });

    function setGalleryHeight() {
        var allImagesHeight = 0;
        $('.gallery-thumbnail').each(function () {
            allImagesHeight += $(this).outerHeight() + Number.parseInt($(this).css('margin-bottom'));
        });
        $('#gallery-wrapper').height(allImagesHeight / 3 + 'px');
    }
    function checkButton() {
        if (picsCount > counter)
            loadBtn.show();
        else
            loadBtn.hide();
    }
})(jQuery);