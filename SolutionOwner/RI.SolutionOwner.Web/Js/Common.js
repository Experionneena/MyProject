
//-----------------------------------// Disable management tools //-----------------------------------//
function DisableTool() {
    $('.disabletool').attr("disabled", "disabled");
}
function CheckBoxChange(checkedItem, parentId) {
    if (arguments.length == 1) {
        var isChecked = $('#' + checkedItem).prop('checked');
        $('.checkbox_click').prop('checked', false);
        if (isChecked) {
            $('#' + checkedItem).prop('checked', true);
            $('.disabletool').removeAttr("disabled", "disabled");
        }
        else {
            $('#' + checkedItem).prop('checked', false);
            DisableTool();
        }
    } else if (arguments.length == 2) {
        var isChecked = $('#' + parentId).find('#' + checkedItem).prop('checked');
        $('#' + parentId).find('.checkbox_click').prop('checked', false);;
        if (isChecked) {
            $('#' + parentId).find('#' + checkedItem).prop('checked', true);
            $('.disabletool').removeAttr("disabled", "disabled");
        }
        else {
            $('#' + parentId).find('#' + checkedItem).prop('checked', false);
            DisableTool();
        }
    }
}

function checkSingleCheckBox(source) {
    $('.checkbox_click').prop('checked', false);
    $(source).prop('checked', true);
    checkedItem = $(source).attr('id');
    $('.tooltip__block').find('button').prop('disabled', false);
}

function checkAllChanged(source) {
    var ischecked = $(source).prop('checked');
    $('.checkbox_click').prop('checked', ischecked);
}

function checkSelectedItem(source) {
    var ischecked = $(source).prop('checked');
    if (!ischecked) {
        $('#chkAll').prop('checked', ischecked);
    }
}

function disableToolbarButtons() {
    $('.tooltip__block').find('button').not('.tb_add').attr('disabled', 'disabled');
    $('.tooltip').css("display", "none");
}

function getAllCheckedItems() {
    var checkedValues = $('.checkbox_click:checked').map(function () {
        return this.id;
    }).get();
    return checkedValues;
}