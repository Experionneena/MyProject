

//----------------------// ADD JS//----------------------//

//----------------------// Validate Create popup //----------------------//
$('#txtName').keypress(function (e) {
    $('#txtNameError').html('');
});
$('#txtDisplayName').keypress(function (e) {
    $('#txtDisplayNameError').html('');
});
$('#txtProgramLink').keypress(function (e) {
    $('#txtProgramLinkError').html('');
});
$('#txtIconClass').keypress(function (e) {
    $('#txtIconClassError').html('');
});
$('#txtSortOrder').keypress(function(e) {
    $('#txtSortOrderError').html('');
})
//----------------------// Save Feature //----------------------//
$("#btn_featureSave").click(function () {
    var isError = false;
    if ($("#txtName").val().trim() == "" || $("#txtName").val().trim() == null) {
        $('#txtNameError').html('Required field *');
        isError = true;
    }
    else {
        $('#txtNameError').html('');
    }
    if ($("#txtDisplayName").val().trim() == "" || $("#txtDisplayName").val().trim() == null) {
        $('#txtDisplayNameError').html('Required field *');
        isError = true;
    }
    else {
        $('#txtDisplayNameError').html('');
    }
    if ($("#txtProgramLink").val().trim() == "" || $("#txtProgramLink").val().trim() == null) {
        $('#txtProgramLinkError').html('Required field *');
        isError = true;
    }
    else {
        $('#txtProgramLinkError').html('');
    }
    if ($("#txtIconClass").val().trim() == "" || $("#txtIconClass").val().trim() == null) {
        $('#txtIconClassError').html('Required field *');
        isError = true;
    }
    else {
        $('#txtIconClassError').html('');
    }
    if ($("#txtSortOrder").val().trim() == "" || $("#txtSortOrder").val().trim() == null) {
        $('#txtSortOrderError').html('Required field *');
        isError = true;
    }
    else if (!$.isNumeric($("#txtSortOrder").val().trim())) {
        $('#txtSortOrderError').html('Required number *');
        isError = true;
    }
    else {
        $('#txtSortOrderError').html('');
    }
    if ($("#ddlCategoryId option:selected").val() == 0 || $("#ddlCategoryId option:selected").val().trim() == null) {
        isError = true;
    }
    else {
        $('#ddlCategoryIdError').html('');
    }
    if ($("#ddlHierarchyIdAdd option:selected").val() == 0 || $("#ddlHierarchyIdAdd option:selected").val().trim() == null) {
        isError = true;
    }
    if (!validateTextOnly($("#txtName").val())) {
        $('#txtNameError').html('Text only *');
        isError = true;
    }
    if (!validateTextOnly($("#txtDisplayName").val())) {
        $('#txtDisplayNameError').html('Text only *');
        isError = true;
    }
    if (!validateURL($("#txtProgramLink").val())) {
        $('#txtProgramLinkError').html('Invalid URL *');
        isError = true;
    }
    if (!validateIconClass($("#txtIconClass").val())) {
        $('#txtIconClassError').html('Text only *');
        isError = true;
    }

    if (isError) {
        return false;
    }
    ShowProgress();
    var postData = {
        Name: $("#txtName").val(),
        DisplayName: $("#txtDisplayName").val(),
        IconClass: $("#txtIconClass").val(),
        SortOrder: $("#txtSortOrder").val(),
        ProgramLink: $("#txtProgramLink").val(),
        CategoryId: $("#ddlCategoryId option:selected").val(),
        HierarchyId: $("#ddlHierarchyIdAdd option:selected").val(),
        IsActive: $("#chkIsActive").prop("checked")
    }
    var hid = $("#ddlHierarchyIdAdd option:selected").val();
    $.ajax({
        url: '@Url.Action("CreateFeature", "SPFeature")',
        type: 'POST',
        data: postData,
        success: function (data) {
            if (data.Status == 1) {
                hideProgress();
                $('#featureAddPopup').modal('hide');
                hideProgress();
                ShowAlert(data.Message, 'success');
                $('#feature_Grid').empty();
                $('#feature_Grid').html(data.Data);
                $("li.active").removeClass("active");
                $('#' + hid).addClass('active');
                collapseTable();
            }
            else {
                hideProgress();
                //$('#featureAddPopup').modal('hide');
                ShowAlert(data.Message, 'error');
            }

        },

        error: function (data) {
            hideProgress();
            //$('#featureAddPopup').modal('hide');
            ShowAlert('Something wrong!', 'error');
        }
    });
});

$("#btn_cancelAdd").click(function () {
    $("#txtName").val('');
    $("#txtPrgLink").val('');
    $("#txtNameError").html('');
    $("#txtLinkError").html('');
    $("#statuscheckbox").prop('checked', false);
    $('#featureAddPopup').modal('hide');
});

function validateTextOnly(myText) {
    var filter = /^[a-zA-Z ]+$/;
    if (filter.test(myText)) {
        return true;
    }
    else {
        return false;
    }
}

function validateIconClass(icon) {
    var filter = /^[a-zA-Z \s\-]+$/;
    if (filter.test(icon)) {
        return true;
    }
    else {
        return false;
    }
}


function validateTextNumberSpace(myText) {
    var filter = /^(?:[A-Za-z]+)(?:[A-Za-z0-9 _]*)$/;
    if (filter.test(myText)) {
        return true;
    }
    else {
        return false;
    }
}

function validateURL(myText) {
    var expression = new RegExp(/https?:\/\/(?:www\.|(?!www))[^\s\.]+\.[^\s]{2,}|www\.[^\s]+\.[^\s]{2,}/);
    if (expression.test(myText)) {
        return true;
    }
    else {
        return false;
    }
}

//----------------------// Edit JS//----------------------//

//----------------------// Validate Edit popup //----------------------//
$('#txtNameEdit').keypress(function (e) {
    $('#txtNameEditError').html('');
});
$('#txtDisplayNameEdit').keypress(function (e) {
    $('#txtDisplayNameEditError').html('');
});
$('#txtProgramLinkEdit').keypress(function (e) {
    $('#txtProgramLinkEditError').html('');
});
$('#txtIconClassEdit').keypress(function (e) {
    $('#txtIconClassEditError').html('');
});
$('#txtSortOrderEdit').keypress(function (e) {
    $('#txtSortOrderEditError').html('');
})

//----------------------// Update Feature //----------------------//
$("#btn_featureEdit").click(function () {
    var isError = false;
    if ($("#txtNameEdit").val().trim() == "" || $("#txtNameEdit").val().trim() == null) {
        $('#txtNameEditError').html('Required field *');
        isError = true;
    }
    else {
        $('#txtNameEditError').html('');
    }
    if ($("#txtDisplayNameEdit").val().trim() == "" || $("#txtDisplayNameEdit").val().trim() == null) {
        $('#txtDisplayNameEditError').html('Required field *');
        isError = true;
    }
    else {
        $('#txtDisplayNameEditError').html('');
    }
    if ($("#txtProgramLinkEdit").val().trim() == "" || $("#txtProgramLinkEdit").val().trim() == null) {
        $('#txtProgramLinkEditError').html('Required field *');
        isError = true;
    }
    else {
        $('#txtProgramLinkEditError').html('');
    }
    if ($("#txtIconClassEdit").val().trim() == "" || $("#txtIconClassEdit").val().trim() == null) {
        $('#txtIconClassEditError').html('Required field *');
        isError = true;
    }
    else {
        $('#txtIconClassEditError').html('');
    }
    if ($("#txtSortOrderEdit").val().trim() == "" || $("#txtSortOrderEdit").val().trim() == null) {
        $('#txtSortOrderEditError').html('Required field *');
        isError = true;
    }
    else if (!$.isNumeric($("#txtSortOrderEdit").val().trim())) {
        $('#txtSortOrderEditError').html('Required number *');
        isError = true;
    }
    else {
        $('#txtSortOrderEditError').html('');
    }
    if ($("#ddlCategoryIdEdit option:selected").val() == 0 || $("#ddlCategoryIdEdit option:selected").val().trim() == null) {
        isError = true;
    }
    else {
        $('#ddlCategoryIdEditError').html('');
    }
    if ($("#ddlHierarchyIdEdit option:selected").val() == 0 || $("#ddlHierarchyIdEdit option:selected").val().trim() == null) {
        isError = true;
    }
    if (!validateTextOnly($("#txtNameEdit").val())) {
        $('#txtNameEditError').html('Text only *');
        isError = true;
    }
    if (!validateTextOnly($("#txtDisplayNameEdit").val())) {
        $('#txtDisplayNameEditError').html('Text only *');
        isError = true;
    }
    if (!validateURL($("#txtProgramLinkEdit").val())) {
        $('#txtProgramLinkEditError').html('Invalid URL *');
        isError = true;
    }
    if (!validateIconClass($("#txtIconClassEdit").val())) {
        $('#txtIconClassEditError').html('Text only *');
        isError = true;
    }


    if (isError) {
        return false;
    }
    ShowProgress();
    var postData = {
        Id: $("#hiddenId").val(),
        CreatedDate: $("#hiddenCreatedDate").val(),
        Name: $("#txtNameEdit").val(),
        DisplayName: $("#txtDisplayNameEdit").val(),
        IconClass: $("#txtIconClassEdit").val(),
        SortOrder: $("#txtSortOrderEdit").val(),
        ProgramLink: $("#txtProgramLinkEdit").val(),
        HierarchyId: $("#ddlHierarchyIdEdit option:selected").val(),
        CategoryId: $("#ddlCategoryIdEdit option:selected").val(),
        IsActive: $("#chkIsActiveEdit").prop("checked")
    }
    var hid = $("#ddlHierarchyIdEdit option:selected").val();
    $.ajax({
        url: '@Url.Action("EditFeature", "SPFeature")',
        type: 'POST',
        data: postData,
        success: function (data) {
            debugger;
            if (data.Status == 1) {
                hideProgress();
                $('#featureEditPopup').modal('hide');
                hideProgress();
                ShowAlert(data.Message, 'success');
                $('#feature_Grid').empty();
                $('#feature_Grid').html(data.Data);
                $("li.active").removeClass("active");
                $('#' + hid).addClass('active');
                collapseTable();
            }
            else {
                hideProgress();
                //$('#featureEditPopup').modal('hide');
                ShowAlert(data.Message, 'error');
            }

        },

        error: function (data) {
            hideProgress();
            //$('#featureEditPopup').modal('hide');
            ShowAlert('Something wrong!', 'error');
        }
    });
});


$("#btn_cancelEdit").click(function () {
    $("#txtNameEdit").val('');
    $("#txtPrgLinkEdit").val('');
    $("#txtNameErrorEdit").html('');
    $("#txtLinkErrorEdit").html('');
    $("#statuscheckboxEdit").prop('checked', false);
    $('#featureEditPopup').modal('hide');
});

function GetFeatures(HierarchyId) {
    ShowProgress();
    $.ajax({
        url: '@Url.Action("GetFeatureList", "SPFeature")',
        data: { 'hierarchyId': HierarchyId },
        type: 'POST',
        success: function (data) {
            if (data.Status == 1) {
                hideProgress();
                $('#feature_Grid').empty();
                $('#feature_Grid').html(data.Data);
                collapseTable();
            }
            else {
                hideProgress();
                ShowAlert('Something wrong!', 'error');
            }
        },
        error: function (data) {
            hideProgress();
            ShowAlert('Something wrong!', 'error');
        }
    });
}
    $(document).ready(function () {

        var mSortingString = [];
        mSortingString.push({ "bSortable": false, "aTargets": [1, 4] });
        InitialiseDataTableForCollpase(mSortingString);
        $.ajax({
            url: '@Url.Action("LoadHierarchies", "SPFeature")',
            type: 'POST',
            success: function (data) {
                $('#hi-ul').html(data.Data);
            },
            error: function (data) {
                hideProgress();
                ShowAlert('Something wrong!', 'error');
            }
        });
        //-----------------------------------// Add Feature PopUp //-----------------------------------//
        $('#btn_AddPopUp').click(function () {
            $('#featureAddPopup').modal({ backdrop: 'static', keyboard: false });
            $.ajax({
                url: '@Url.Action("LoadAddPopUp", "SPFeature")',
                type: 'POST',
                success: function (data) {
                    if (data.Status == 1) {
                        $('#featureAdd').empty();
                        $('#featureAdd').html(data.Data);
                        hideProgress();
                    }
                    else {
                        hideProgress();
                        ShowAlert('Something wrong!', 'error');
                    }
                },
                error: function (data) {
                    hideProgress();
                    ShowAlert('Something wrong!', 'error');
                }
            });
        });


        //-----------------------------------// Fill Feature grid //-----------------------------------//
            
        function CheckCheckboxCheckedOrUnchecked() {
            var id;
            $(".checkbox_click").each(function () {
                if ($(this).prop('checked') == true) {
                    id = $(this).attr('id');
                    var arr = id.split('_');
                    id = arr[1];
                }
            });
            return id;
        }

        $("#btn_EditPopup").click(function () {
            var id = CheckCheckboxCheckedOrUnchecked();
            if (id != null) {
                ShowProgress();
                $.ajax({
                    url: '@Url.Action("GetFeatureById", "SPFeature")',
                    type: 'POST',
                    data: { featureId: id },
                    success: function (data) {
                        if (data.Status == 1) {
                            hideProgress();
                            $('#featureEditPopup').modal({ backdrop: 'static', keyboard: false });
                            $('#featureEdit').empty();
                            $('#featureEdit').html(data.Data);
                        }
                        else {
                            hideProgress();
                            ShowAlert('Something wrong!', 'error');
                        }

                    },

                    error: function (data) {
                        hideProgress();
                        ShowAlert('Something wrong!', 'error');
                    }
                });
            }
        });

        $("#btn_Delete").click(function () {
            var idForDelete = CheckCheckboxCheckedOrUnchecked();
            if (idForDelete != null) {
                bootbox.confirm("Are you sure you want to delete?", function (result) {
                    if (result) {
                        var hierarchyid = $("#hierarchyList li.active").attr('id');
                        ShowProgress();
                        $.ajax({
                            url: '@Url.Action("DeleteFeatureById", "SPFeature")',
                            type: 'POST',
                            data: { featureId: idForDelete, hierarchyId: hierarchyid },
                            success: function (data) {
                                if (data.Status == 1) {
                                    hideProgress();
                                    ShowAlert(data.Message, 'success');
                                    $('#feature_Grid').empty();
                                    $('#feature_Grid').html(data.Data);
                                    collapseTable();
                                    ShowAlert(data.Message, 'success');
                                }
                                else {
                                    hideProgress();
                                    ShowAlert(data.Message, 'error');
                                }
                            },
                            error: function (data) {
                                hideProgress();
                                ShowAlert(data.Message, 'error');
                            }
                        });
                    }
                });
            }
        });


        $("#btn_closeAdd").click(function () {
            $("#txtName").val('');
            $("#txtPrgLink").val('');
            $("#txtNameError").html('');
            $("#txtLinkError").html('');
            $("#statuscheckbox").prop('checked', false);
            $('#featureAddPopup').modal('hide');
        });
        $("#btn_closeEdit").click(function () {
            $("#txtName").val('');
            $("#txtPrgLink").val('');
            $("#txtNameError").html('');
            $("#txtLinkError").html('');
            $("#statuscheckboxEdit").prop('checked', false);
            $('#featureEditPopup').modal('hide');
        });

        $('#btnActivate').click(function () {
            var id = CheckCheckboxCheckedOrUnchecked();
            if (id != null) {
                bootbox.confirm("Are you sure you want to Activate this feature?", function (result) {
                    if (result) {
                        ShowProgress();
                        var hierarchyid = $("#hierarchyList li.active").attr('id');
                        $.ajax({
                            url: '@Url.Action("ActivateDeactivate", "SPFeature")',
                            type: 'POST',
                            data: { featureId: id, flag: 1, hierarchyId: hierarchyid },
                            success: function (data) {
                                if (data.Status == 1) {
                                    hideProgress();
                                    ShowAlert(data.Message, 'success');
                                    $('#feature_Grid').empty();
                                    $('#feature_Grid').html(data.Data);
                                    collapseTable();
                                    ShowAlert(data.Message, 'success');
                                }
                                else {
                                    hideProgress();
                                    ShowAlert('Something wrong!', 'error');
                                    ShowAlert(data.Message, 'error');
                                }
                            },
                            error: function (data) {
                                hideProgress();
                                ShowAlert('Something wrong!', 'error');
                                ShowAlert(data.Message, 'error');
                            }
                        });
                    }
                });
            }
        });


        $('#btnDeactivate').click(function () {
            var id = CheckCheckboxCheckedOrUnchecked();
            if (id != null) {
                bootbox.confirm("Are you sure you want to Deactivate this feature?", function (result) {
                    if (result) {
                        ShowProgress();
                        var hierarchyid = $("#hierarchyList li.active").attr('id');
                        $.ajax({
                            url: '@Url.Action("ActivateDeactivate", "SPFeature")',
                            type: 'POST',
                            data: { featureId: id, flag: 0, hierarchyId: hierarchyid },
                            success: function (data) {
                                if (data.Status == 1) {
                                    hideProgress();
                                    $('#feature_Grid').empty();
                                    $('#feature_Grid').html(data.Data);
                                    collapseTable();
                                    ShowAlert(data.Message, 'success');
                                }
                                else {
                                    hideProgress();
                                    ShowAlert(data.Message, 'error');
                                }
                            },
                            error: function (data) {
                                hideProgress();
                                ShowAlert(data.Message, 'error');
                            }
                        });
                    }
                });
            }
        });
    });
function collapseTable(){
    $('#tblFeature').aCollapTable({
        // startCollapsed: true,
        addColumn: true,
        plusButton: '<i class="glyphicon glyphicon-plus"></i> ',
        minusButton: '<i class="glyphicon glyphicon-minus"></i> '
    });
}
