(function ($) {
    var arrivalDate, departureDate, startDate, endDate, departureDatepicker, rooms, guestCount, typeId, adultsCount, form, curDate;
    var hasError = false;

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
        $('#reservation-button').click(function (e) {
            e.preventDefault();
            $('#Name').val($('#name').val());
            $('#Email').val($('#name').val());
            $('#PhoneNumber').val($('#phone').val());
            $('#ChildrenCount').val($('#children-amount').val());
            $('#Note').val($('#comment').val());
            $('#Email').val($('#email').val());
            hasError = false;
            checkRequiredFields();
            if (hasError) {
                return;
            }
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

    function checkRequiredFields() {
        $('.with-validation').each(function () {
            var validationLabel = $(this);
            var emailInput = validationLabel.find('#email');
            var phoneInput = validationLabel.find('#phone');

            if (emailInput.length) {
                var emailValue = emailInput.val().trim();
                if (!validateEmail(emailValue)) {
                    markWithError(validationLabel);
                } else {
                    removeErrorClass(validationLabel);
                }
            } else if (phoneInput.length) {
                var phoneValue = phoneInput.val().trim();
                if (!validatePhone(phoneValue)) {
                    markWithError(validationLabel);
                } else {
                    removeErrorClass(validationLabel);
                }
            } else if (validationLabel.find('.reservation-input').val() === '') {
                markWithError(validationLabel);
            } else {
                removeErrorClass(validationLabel);
            }
        });
    }

    function validateEmail(email) {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }

    function validatePhone(phone) {
        var re = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;
        return re.test(String(phone).toLowerCase());
    }

    function markWithError(label) {
        hasError = true;
        label.addClass('has-error');
    }

    function removeErrorClass(label) {
        label.removeClass('has-error');
    }

})(jQuery);