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

    var profileRequest = {};
    profileRequest.FullName = $('#fullname').val();
    profileRequest.ShortName = $('#shortname').val();
    profileRequest.NIC = $('#nicno').val();


    profileRequest.Photo1 = $('#Image1').val();
    profileRequest.Photo2 = $('#Image2').val();
    profileRequest.Photo3 = $('#Image3').val();
    profileRequest.Photo4 = $('#Image4').val();
    profileRequest.Photo5 = $('#Image5').val();


    profileRequest.Mobiel1 = $('#mobile01').val();
    profileRequest.Mobile1Whatsapp = $('#whatsApp1').val();
    profileRequest.Mobile1Viber = $('#viber3').val();
    profileRequest.Mobiel2 = $('#mobile02').val();
    profileRequest.Mobile2Whatsapp = $('#whatsApp2').val();
    profileRequest.Mobile2Viber = $('#viber3').val();
    profileRequest.Mobiel3 = $('#mobile03').val();
    profileRequest.Mobile3Whatsapp = $('#whatsApp2').val();
    profileRequest.Mobile3Viber = $('#viber3').val();

    profileRequest.DOB = $('#dob').val();
    profileRequest.Age = $('#age').val();
    profileRequest.GenderMale = $('#genderM').val();
    profileRequest.GenderFemale = $('#genderF').val();
    profileRequest.CurrentDistrict = $('#currentdistrict').val();
    profileRequest.CurrentTown = $('#currentcity').val();
    profileRequest.HomeDistrict = $('#homedistrict').val();
    profileRequest.HomeTown = $('#hometown').val();
    profileRequest.ShirtSizeS = $('#tsizeS').val();
    profileRequest.ShirtSizeM = $('#tsizeM').val();
    profileRequest.ShirtSizeL = $('#tsizeL').val();
    profileRequest.ShirtSizeXS = $('#tsizeXS').val();
    profileRequest.Student = $('#student').val();
    profileRequest.University = $('#studentdetails1').val();
    profileRequest.Course = $('#studentdetails2').val();
    profileRequest.UniYear = $('#studentdetails3').val();
    profileRequest.Employeed = $('#employee').val();
    profileRequest.Company = $('#employeedetails1').val();
    profileRequest.Branch = $('#employeedetails2').val();
    profileRequest.Designation = $('#employeedetails3').val();
    profileRequest.FullTimePromoter = $('#parttime').val();
    profileRequest.PartTimePromoter = $('#freelance').val();
    profileRequest.EnglishSpeaking = $('#englishlan').val();
    profileRequest.TamilSpeaking = $('#tamillan').val();
    profileRequest.SalesExperience = $('#promoexperience').val();


    profileRequest.Brands = $('#brandnames').select2("val"),
    profileRequest.OtherExperience = $('#otherpromoexperience').select2("val"),

    $.ajax({
        type: "POST",
        url: '/Admin/ProfileSubmit',
        data: '{profileRequest: ' + JSON.stringify(profileRequest) + '}',
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

