$(function () {
    //Initialize Select2 Elements
    $('.select2').select2();

    //Input mask
    $('[data-mask]').inputmask()

});

function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json'
    });
}  

function AjaxCallSelect2(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json'
    });
}  

//Load town dropdown values 
$(function () {

    AjaxCallSelect2('/Admin/GetBrands', null).done(function (response) {
        if (response.length > 0) {
            $('#brandnames').html('');
            var options = '';
            for (var i = 0; i < response.length; i++) {
                options += '<option value="' + response[i].Brand + '">' + response[i].Brand + '</option>';
            }
            $('#brandnames').append(options);
        }
    }).fail(function (error) {
        alert(error.StatusText);
    });
});

//Load town dropdown values 
$(function () {

    AjaxCall('/Admin/GetDistricts', null).done(function (response) {
        if (response.length > 0) {
            $('#currentdistrict').html('');
            $('#homedistrict').html('');
            var options = '';
            options += '<option value="Select">-Select District-</option>';
            for (var i = 0; i < response.length; i++) {
                options += '<option value="' + response[i].DistrictId + '">' + response[i].Name + '</option>';
            }
            $('#currentdistrict').append(options);
            $('#homedistrict').append(options);

        }
    }).fail(function (error) {
        alert(error.StatusText);
    });

    $('#currentdistrict').on("change", function () {
        var town = $('#currentdistrict').val();
        var obj = { districtId: town };
        AjaxCall('/Admin/GetTowns', JSON.stringify(obj), 'POST').done(function (response) {
            if (response.length > 0) {
                $('#currentcity').html('');
                var options = '';
                options += '<option value="Select">-Select Town-</option>';
                for (var i = 0; i < response.length; i++) {
                    options += '<option value="' + response[i].Id + '">' + response[i].Name + '</option>';
                }
                $('#currentcity').append(options);
            }
        }).fail(function (error) {
            alert(error.StatusText);
        });
    });

    $('#homedistrict').on("change", function () {
        var town = $('#homedistrict').val();
        var obj = { districtId: town };
        AjaxCall('/Admin/GetTowns', JSON.stringify(obj), 'POST').done(function (response) {
            if (response.length > 0) {
                $('#hometown').html('');
                var options = '';
                options += '<option value="Select">-Select Town-</option>';
                for (var i = 0; i < response.length; i++) {
                    options += '<option value="' + response[i].Id + '">' + response[i].Name + '</option>';
                }
                $('#hometown').append(options);
            }
        }).fail(function (error) {
            alert(error.StatusText);
        });
    });

});

//Show hide I am section
$(document).ready(function () {
    $('#student').change(function () {
        if ($(this).is(":checked")) {
            $('#studentdetails').fadeIn('slow');
            $("#employee").attr("disabled", "disabled").off('click');
            $("#employeedetails").attr("disabled", "disabled").off('click');
            $("#parttime").attr("disabled", "disabled").off('click');
        }
        else {
            $('#studentdetails').fadeOut('slow');
            $("#employee").removeAttr('disabled');
            $("#employeedetails").removeAttr('disabled');
            $("#parttime").removeAttr('disabled');
        }
    });
});

$(document).ready(function () {
    $('#employee').change(function () {
        if ($(this).is(":checked")) {
            $('#employeedetails').fadeIn('slow');
            $("#student").attr("disabled", "disabled").off('click');
            $("#studentdetails").attr("disabled", "disabled").off('click');
            $("#parttime").attr("disabled", "disabled").off('click');
        }
        else {
            $('#employeedetails').fadeOut('slow');
            $("#student").removeAttr('disabled');
            $("#studentdetails").removeAttr('disabled');
            $("#parttime").removeAttr('disabled');
        }
    });
});

$(document).ready(function () {
    $('#parttime').change(function () {
        if ($(this).is(":checked")) {
            $("#student").attr("disabled", "disabled").off('click');
            $("#studentdetails").attr("disabled", "disabled").off('click');
            $("#employee").attr("disabled", "disabled").off('click');
            $("#employeedetails").attr("disabled", "disabled").off('click');
        }
        else {
            $("#student").removeAttr('disabled');
            $("#studentdetails").removeAttr('disabled');
            $("#employee").removeAttr('disabled');
            $("#employeedetails").removeAttr('disabled');
        }
    });
});

//Submit button show hide
$(document).ready(function () {
    $('#submit').change(function () {
        if ($(this).is(":checked")) {
            $("#sumbitprofile").removeAttr('disabled');
        }
        else {
            $("#sumbitprofile").attr("disabled", "disabled").off('click');
        }
    });
});



//Profile Submit
function submitFunction() {

    $("#sumbitprofile").attr("disabled", "disabled").off('click');

    //var std = {};
    //std.studentName = "qq";
    //std.studentAddress = "test"; 

    $.ajax({
        type: "POST",
        url: '/Admin/ProfileSubmit',
        data: '{std: ' + JSON.stringify(std) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",

        success: function (result) {
            $("#sumbitprofile").removeAttr('disabled');
            alert('ok');
        },
        error: function (result) {
            $("#sumbitprofile").removeAttr('disabled');
            alert('error');
        }
    });
}

