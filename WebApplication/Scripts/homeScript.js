
// This code shows the radio buttons for speed when selecting speed out of the dropdown menu.

$(document).ready(function () {
    $('#att').on('change', function () {
        var att = this.value;
        //window.alert(att);
        $(".div").fadeOut("slow");
        $("#" + att).fadeIn("slow");
        $(".input").val("");

    });
});

$(document).ready(function () {
    $('input[type=radio]').prop('checked', false);
    $('input[type=radio]:first').prop('checked', true)

    $('input[type=radio]').click(function (event) {
        $('input[type=radio]').prop('checked', false);
        $(this).prop('checked', true);
    });
    $("#Between").pop(function () {
        var test = $(this).val();
        $("div.desc").hide();
        $("#" + test).show();
    });
});

$(document).ready(function () {
    $('#date').change(function () {
        if (this.checked) {
            $('#DateTimeDiv').fadeIn('slow');
        } else {
            $('#DateTimeDiv').fadeOut('slow');
        }
    });
});