

// check which attribute is selected and open the accessory div
$(document).ready(function () {
    $('#att').on('change', function () {
        var att = this.value;
        //window.alert(att);
        $(".div").fadeOut("slow");
        $("#" + att).fadeIn("slow");
        $(".input").val("");

    });
});

// check which radio button is selected. when the radio button "Between" is selected a second input textfield will appear
$(document).ready(function () {
    $('input[type=radio]').prop('checked', false);
    $('input[type=radio]:first').prop('checked', true)

    $('input[type=radio]').click(function (event) {
        $('input[type=radio]').prop('checked', false);
        $(this).prop('checked', true);
        if (this.name == "Between") {
            $('#number2').fadeIn('slow');
        } else if(this.name != "Between") {
            $('#number2').fadeOut('slow');
        }

    });
});

// when selected date the div will show
$(document).ready(function () {
    $('#date').change(function () {
        if (this.checked) {
            $('#DateTimeDiv').fadeIn('slow');
        } else {
            $('#DateTimeDiv').fadeOut('slow');
        }
    });
});

// check if the input value is numeric
var specialKeys = new Array();
specialKeys.push(8); //Backspace
function IsNumeric(e) {
    var keyCode = e.which ? e.which : e.keyCode
    var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
    document.getElementById("error").style.display = ret ? "none" : "inline";
    return ret;
}

// check if the input is a numeric value but this time with an exception for the "-" sign
var specialKeys = new Array();
specialKeys.push(8); //Backspace
specialKeys.push(45) // "-" sign
function IsNumericDate(e) {
    var keyCode = e.which ? e.which : e.keyCode
    var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
    document.getElementById("errorDate").style.display = ret ? "none" : "inline";
    return ret;
}