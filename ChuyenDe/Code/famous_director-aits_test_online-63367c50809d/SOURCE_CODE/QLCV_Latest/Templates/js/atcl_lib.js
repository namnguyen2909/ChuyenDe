//Form Validation
function validateForm() {    
    blValidData = true;
    strElementID = "";
    $(".required_css").each(function () {
        strElementID = "#" + $(this).attr("id") + "_errorMsg";
        if (($(this).val().trim() == "") || ($(this).val().trim() == "BLANK_ITEM")) {
            $(this).css("border", "1px solid red");
            $(strElementID).css("display", "block");
            blValidData = false;
        }
        else {
            $(this).css("border", "1px solid #ccc");
            $(strElementID).css("display", "none");
        }
    });
    return blValidData;
}

function validateForm_2() {//function is used in case of validating by 2 differrent form in one page
    blValidData = true;
    strElementID = "";
    $(".required_2_css").each(function () {
        strElementID = "#" + $(this).attr("id") + "_errorMsg";
        if (($(this).val().trim() == "") || ($(this).val().trim() == "BLANK_ITEM")) {
            $(this).css("border", "1px solid red");
            $(strElementID).css("display", "block");
            blValidData = false;
        }
        else {
            $(this).css("border", "1px solid #ccc");
            $(strElementID).css("display", "none");
        }
    });
    return blValidData;
}

$(".value_css").val("hide");
$(".click_css").click(function (e) {
    if ($(this).parent(".point_css").children(".value_css").val() == "hide") {
        $(this).parent(".point_css").children(".value_css").val("show");
        $(this).parents(".control_tbl_css").children(".systemLogID").show();
    }
    else {
        $(this).parent(".point_css").children(".value_css").val("hide");
        $(this).parents(".control_tbl_css").children(".systemLogID").hide();
    }

});