(function($){
    var arrivalDate, departureDate;

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
        var departureDatepicker = $('#departure-date').datepicker().data('datepicker');

        arrivalDatepicker.selectDate(new Date());
        departureDatepicker.selectDate(new Date());

        $('.reservation-select').chosen({
            disable_search: true
        });
    });

    function onArrivalDateSelect(formattedDate, date) {
        if (departureDate && date > departureDate) {
            return
        }

        arrivalDate = date;
    }

    function onDepartureDateSelect(formattedDate, date) {
        if (arrivalDate && date < arrivalDate) {
            return
        }

        departureDate = date;
    }
})(jQuery);