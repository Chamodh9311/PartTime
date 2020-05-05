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


    profileRequest.Mobile1 = $('#mobile01').val();
    if (document.getElementById('whatsApp1').checked) {
        profileRequest.Mobile1Whatsapp = true;
    }
    else {
        profileRequest.Mobile1Whatsapp = false;
    }

    if (document.getElementById('viber1').checked) {
        profileRequest.Mobile1Viber = true;
    }
    else {
        profileRequest.Mobile1Viber = false;
    }

    profileRequest.Mobiel2 = $('#mobile02').val();
    if (document.getElementById('whatsApp2').checked) {
        profileRequest.Mobile2Whatsapp = true;
    }
    else {
        profileRequest.Mobile2Whatsapp = false;
    }

    if (document.getElementById('viber2').checked) {
        profileRequest.Mobile2Viber = true;
    }
    else {
        profileRequest.Mobile2Viber = false;
    }

    profileRequest.Mobiel3 = $('#mobile03').val();
    if (document.getElementById('whatsApp3').checked) {
        profileRequest.Mobile3Whatsapp = true;
    }
    else {
        profileRequest.Mobile3Whatsapp = false;
    }

    if (document.getElementById('viber3').checked) {
        profileRequest.Mobile3Viber = true;
    }
    else {
        profileRequest.Mobile3Viber = false;
    }

    profileRequest.DOB = $('#dob').val();
    profileRequest.Age = $('#age').val();

    if (document.getElementById('genderM').checked) {
        profileRequest.GenderMale = true;
    }
    else {
        profileRequest.GenderMale = false;
    }

    if (document.getElementById('genderF').checked) {
        profileRequest.GenderFemale = true;
    }
    else {
        profileRequest.GenderFemale = false;
    }

    profileRequest.CurrentDistrict = $('#currentdistrict').val();
    profileRequest.CurrentTown = $('#currentcity').val();
    profileRequest.HomeDistrict = $('#homedistrict').val();
    profileRequest.HomeTown = $('#hometown').val();


    if (document.getElementById('tsizeS').checked) {
        profileRequest.ShirtSizeS = true;
    }
    else {
        profileRequest.ShirtSizeS = false;
    }

    if (document.getElementById('tsizeM').checked) {
        profileRequest.ShirtSizeM = true;
    }
    else {
        profileRequest.ShirtSizeM = false;
    }

    if (document.getElementById('tsizeL').checked) {
        profileRequest.ShirtSizeL = true;
    }
    else {
        profileRequest.ShirtSizeL = false;
    }

    if (document.getElementById('tsizeXS').checked) {
        profileRequest.ShirtSizeXS = true;
    }
    else {
        profileRequest.ShirtSizeXS = false;
    }

    if (document.getElementById('student').checked) {
        profileRequest.Student = true;
    }
    else {
        profileRequest.Student = false;
    }

    profileRequest.University = $('#studentdetails1').val();
    profileRequest.Course = $('#studentdetails2').val();
    profileRequest.UniYear = $('#studentdetails3').val();

    if (document.getElementById('employee').checked) {
        profileRequest.Employeed = true;
    }
    else {
        profileRequest.Employeed = false;
    }

    profileRequest.Company = $('#employeedetails1').val();
    profileRequest.Branch = $('#employeedetails2').val();
    profileRequest.Designation = $('#employeedetails3').val();

    if (document.getElementById('parttime').checked) {
        profileRequest.FullTimePromoter = true;
    }
    else {
        profileRequest.FullTimePromoter = false;
    }

    profileRequest.FullTimePromoter = $('#freelance').val();

    if (document.getElementById('tsizeXS').checked) {
        profileRequest.PartTimePromoter = true;
    }
    else {
        profileRequest.PartTimePromoter = false;
    }

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
            //$('body').append('<div id="over" style="position: absolute;top:0;left:0;width: 100%;height:100%;z-index:2;opacity:0.4;filter: alpha(opacity = 50)"></div>');
        },
        error: function (result) {
            $("#sumbitprofile").removeAttr('disabled');
            alert('error');
        }
    });
}

