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

        arrivalDatepicker.selectDate(new Date());
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

        arrivalDate = date;
    }

    function onDepartureDateSelect(formattedDate, date) {
        if (arrivalDate && date < arrivalDate) {
            return;
        }

        departureDate = date;
    }
})(jQuery);