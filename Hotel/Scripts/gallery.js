(function ($) {
    var counter = 9;
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
                        //galObj.append('<a class="gallery-thumbnail" href="/Content/img/gallery/thumb/tumb_' + item.ImgName + '">' +
                        //    '<img class="gallery-image" src="/Content/img/gallery/' + item.ImgName + '" />' +
                        //    '</a >');
                        galObj.append('<a class="gallery-thumbnail" href="/Content/img/gallery/' + item.ImgName + '">' +
                            '<img class="gallery-image" src="/Content/img/gallery/thumb/tumb_' + item.ImgName + '" />' +
                            '</a >');
                    });
                    setGalleryHeight();


                    lightGallery(document.getElementById('gallery-wrapper'));
                    checkButton();
                });
        }


        $('#loadPicsPhoto').click(function (e) {
            counter += 9;
            appendPics();
        });
    });

    function setGalleryHeight() {
        var allImagesHeight = 0;
        var maxHeigth = 0;
        var minHeight = 0;
        var imgObjs = $('.gallery-thumbnail');
        var indexer = 0;
        var imgCount = imgObjs.length;

        if (imgCount % 2 !== 0)
            imgCount += 1;
        var indexerStop = imgCount / 3;

        imgObjs.each(function () {
            allImagesHeight += $(this).outerHeight() + Number.parseInt($(this).css('margin-bottom'));
            indexer += 1;

            if (indexer >= indexerStop) {
                indexer = 0;
                if (indexer <= minHeight || minHeight === 0) minHeight = allImagesHeight;
                if (allImagesHeight > maxHeigth) maxHeigth = allImagesHeight;
                allImagesHeight = 0;
            }
        });
        $('#gallery-wrapper').height((maxHeigth + minHeight) / 2 + 'px');
    }
    function checkButton() {
        if (picsCount > counter)
            loadBtn.show();
        else
            loadBtn.hide();
    }
})(jQuery);