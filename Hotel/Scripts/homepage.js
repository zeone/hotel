(function($){
    var $arrivalDayVisual = $('#arrival-day');
    var $arrivalMonthVisual = $('#arrival-month');
    var $departureDayVisual = $('#departure-day');
    var $departureMonthVisual = $('#departure-month');
    var $nightsVisual = $('#home-reservation-nights');

    var arrivalDate, departureDate, nightsCount, guestsAmount;

    $(document).ready(function () {
        $('#arrival-date').datepicker({
           language: 'en',
           dateFormat: 'd M',
           onSelect: onArrivalDateSelect
        });
        $('#departure-date').datepicker({
            language: 'en',
            dateFormat: 'd M',
            onSelect: onDepartureDateSelect
        });

        var arrivalDatepicker = $('#arrival-date').datepicker().data('datepicker');
        var departureDatepicker = $('#departure-date').datepicker().data('datepicker');

        arrivalDatepicker.selectDate(new Date());
        departureDatepicker.selectDate(new Date());

        $('#home-reservation__amount').number({
            'minus' : 'home-reservation__amount-minus',
            'plus' : 'home-reservation__amount-plus',
            'btnTag' : 'span'
        });
        
        $('.banner-details').click(function () {
            $('html, body').animate({
                scrollTop: $("#home-gallery").offset().top
            }, 2000);
        })
    });

    function onArrivalDateSelect(formattedDate, date) {
        if (departureDate && date > departureDate) {
            return
        }

        var formattedDateArray = formattedDate.split(' ');
        $arrivalDayVisual.text(formattedDateArray[0]);
        $arrivalMonthVisual.text(formattedDateArray[1]);

        arrivalDate = date;

        if (arrivalDate && departureDate) {
            var nightsData = new Date(departureDate-arrivalDate);
            nightsCount = Math.ceil(nightsData / (1000 * 3600 * 24));
            $nightsVisual.text(nightsCount);
        }
    }

    function onDepartureDateSelect(formattedDate, date) {
        if (arrivalDate && date < arrivalDate) {
            return
        }

        var formattedDateArray = formattedDate.split(' ');
        $departureDayVisual.text(formattedDateArray[0]);
        $departureMonthVisual.text(formattedDateArray[1]);

        departureDate = date;

        if (arrivalDate && departureDate) {
            var nightsData = new Date(departureDate-arrivalDate);
            nightsCount = Math.ceil(nightsData / (1000 * 3600 * 24));
            $nightsVisual.text(nightsCount);
        }
    }
})(jQuery);