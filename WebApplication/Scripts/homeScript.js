
// This code shows the radio buttons for speed when selecting speed out of the dropdown menu.

$(document).ready(function () {
    $('#att').change(function () {
        var location = $(this).val(),
        div = $('#' + location);

        if ($(this).val(location)) {
            div.show();
        } else {
            div.hide();
        }
    });
});
