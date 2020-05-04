$(function () {
    //Initialize Select2 Elements
    $('.select2').select2();

    //Datemask2 mm/dd/yyyy
    $('#dob').inputmask('mm/dd/yyyy', { 'placeholder': 'mm/dd/yyyy' });

});


$(function () {

    AjaxCall('/Admin/GetDistricts', null).done(function (response) {
        if (response.length > 0) {
            $('#currentdistrict').html('');
            $('#homedistrict').html('');
            var options = '';
            options += '<option value="Select">Select</option>';
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
                options += '<option value="Select">Select</option>';
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
                options += '<option value="Select">Select</option>';
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

function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json'
    });
}  

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
            $("#sumbitprofile").attr("disabled", "disabled").off('click');
        }
        else {
            $("#sumbitprofile").removeAttr('disabled');
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

