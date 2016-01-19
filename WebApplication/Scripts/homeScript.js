
// This code shows the radio buttons for speed when selecting speed out of the dropdown menu.

$(document).ready(function () {
    $('#att').on('change', function () {
        if (this.value == 'Speed')
        {
            $("#Speed").show();
        }
        else {
            $("#Speed").hide();
        }
    });
});

$(document).ready(function () {
    $('input[type=radio]').prop('checked', false);
    $('input[type=radio]:first').prop('checked', true)

    $('input[type=radio]').click(function (event) {
        $('input[type=radio]').prop('checked', false);
        $(this).prop('checked', true);
    });
});