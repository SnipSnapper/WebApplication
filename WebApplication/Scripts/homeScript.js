
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
