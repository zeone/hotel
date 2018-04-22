(function ($) {
    var arrivalDate, departureDate, startDate, endDate, departureDatepicker, rooms, guestCount, typeId, adultsCount, form, curDate;

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
        //main obj for controller
        startDate = $('#StartDate');
        endDate = $('#EndDate');
        typeId = $('#TypeId');
        guestCount = $('#GuestCount');




        rooms = $('#room-category');
        adultsCount = $('#adults-amount');
        form = $('.reservation-form');

        //init values
        typeId.val(1);
        adultsCount.val(1);

        updatePrice();

        if (startDate.length > 0) {
            curDate = new Date(parseInt(startDate.val()));
            arrivalDatepicker.selectDate(curDate);
        } else {
            arrivalDatepicker.selectDate(new Date());
        }

        if (endDate.length > 0) {
            curDate = new Date(parseInt(endDate.val()));
            departureDatepicker.selectDate(curDate);
        } else {
            departureDatepicker.selectDate(new Date());
        }

        departureDatepicker.selectDate(new Date());

        $('.reservation-select').chosen({
            disable_search: true
        });


        function updatePrice() {
            var appType = typeId.val();
            var guests = guestCount.val();
            $.getJSON('GetAppPrice',
                {
                    apTypeId: appType,
                    gusetCount: guests
                }, function (resp) {
                    $('#room-price').val(resp);
                });
        }

        $('#room-category').change(function (item) {
            typeId.val($(item.target).val());
            updatePrice();
        });

        $('#adults-amount').change(function (item) {
            guestCount.val($(item.target).val());
            // $('#results').load('@Url.Action("BookSearch", "Home")?name=' + name)
            updatePrice();
        });
        $('#reservationBtn').click(function (e) {
            e.preventDefault();
            $('#Name').val($('#name').val());
            $('#Email').val($('#name').val());
            $('#PhoneNumber').val($('#phone').val());
            $('#ChildrenCount').val($('#children-amount').val());
            $('#Note').val($('#comment').val());
            $('#Email').val($('#email').val());
            $('.reservation-form').submit();
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




})(jQuery);