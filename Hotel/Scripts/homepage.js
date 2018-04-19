(function ($) {
    var $arrivalDayVisual = $('#arrival-day');
    var $arrivalMonthVisual = $('#arrival-month');
    var $departureDayVisual = $('#departure-day');
    var $departureMonthVisual = $('#departure-month');
    var $nightsVisual = $('#home-reservation-nights');


    var arrivalDate, departureDate, nightsCount, guestsAmount, startDate, endDate, guestCount;

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
        //startDate = $('#StartDate');
        //endDate = $('#EndDate');

        startDate = $('#indexStartDate');
        endDate = $('#indexEndDate');
        guestCount = $('#GuestCount');
        arrivalDatepicker.selectDate(new Date());
        departureDatepicker.selectDate(new Date());

        $('#home-reservation__amount').number({
            'minus': 'home-reservation__amount-minus',
            'plus': 'home-reservation__amount-plus',
            'btnTag': 'span'
        });
        $('#home-reservation__amount').click(function () {
            guestCount.val($('#home-reservation__amount').val());
        });

        $('.banner-details').click(function () {
            $('html, body').animate({
                scrollTop: $("#home-gallery").offset().top
            },
                2000);
        });
    });

    function onArrivalDateSelect(formattedDate, date) {
        var formattedDateArray = formattedDate.split(' ');

        if (departureDate && date > departureDate) {
            departureDate = date;
            endDate.val(date.toJSON());
            $departureDayVisual.text(formattedDateArray[0]);
            $departureMonthVisual.text(formattedDateArray[1]);
        }

        $arrivalDayVisual.text(formattedDateArray[0]);
        $arrivalMonthVisual.text(formattedDateArray[1]);

        arrivalDate = date;
        startDate.val(date.toJSON());
        if (arrivalDate && departureDate) {
            var nightsData = new Date(departureDate - arrivalDate);
            nightsCount = Math.ceil(nightsData / (1000 * 3600 * 24));
            $nightsVisual.text(nightsCount);
        }
    }

    function onDepartureDateSelect(formattedDate, date) {
        if (arrivalDate && date < arrivalDate) {
            return;
        }

        var formattedDateArray = formattedDate.split(' ');
        $departureDayVisual.text(formattedDateArray[0]);
        $departureMonthVisual.text(formattedDateArray[1]);

        departureDate = date;
        endDate.val(date.toJSON());
        if (arrivalDate && departureDate) {
            var nightsData = new Date(departureDate - arrivalDate);
            nightsCount = Math.ceil(nightsData / (1000 * 3600 * 24));
            $nightsVisual.text(nightsCount);
        }
    }
})(jQuery);