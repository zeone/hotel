(function ($) {
    var arrivalDate, departureDate, startDate, endDate, departureDatepicker;

    $(document).ready(function () {
        $('#arrival-date').datepicker({
            language: 'en',
            dateFormat: 'dd.mm.yyyy',
            onSelect: onArrivalDateSelect
        });
        $('#departure-date').datepicker({
            language: 'en',
            dateFormat: 'dd.mm.yyyy',
            onSelect: onDepartureDateSelect
        });

        var arrivalDatepicker = $('#arrival-date').datepicker().data('datepicker');
        departureDatepicker = $('#departure-date').datepicker().data('datepicker');

        startDate = $('#StartDate');
        endDate = $('#EndDate');



        if (startDate.length > 0) {
            var curDate = new Date(parseInt(startDate.val()));
            arrivalDatepicker.selectDate(curDate);
        } else {
            arrivalDatepicker.selectDate(new Date());
        }

        if (endDate.length > 0) {
            var curDate = new Date(parseInt(endDate.val()));
            departureDatepicker.selectDate(curDate);
        } else {
            departureDatepicker.selectDate(new Date());
        }

        departureDatepicker.selectDate(new Date());

        $('.reservation-select').chosen({
            disable_search: true
        });
    });

    function onArrivalDateSelect(formattedDate, date) {
        if (departureDate && date > departureDate) {
            departureDatepicker.selectDate(date);
            endDate.val(date.toJSON());
        }
        startDate.val(date.toJSON());
        arrivalDate = date;
    }

    function onDepartureDateSelect(formattedDate, date) {
        if (arrivalDate && date < arrivalDate) {
            return;
        }
        endDate.val(date.toJSON());
        departureDate = date;
    }

    $('#room-category').change(function (item) {
        $('#TypeId').val($(item.target).val());
        console.log(item);
    });
})(jQuery);