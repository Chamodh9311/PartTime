$(function () {
    //Initialize Select2 Elements
    $('.select2').select2();

    //Input mask
    $('[data-mask]').inputmask()

});


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// Promoter //////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
            $("#freelanceYes").attr("disabled", "disabled").off('click');
            $("#freelancerdetails").attr("disabled", "disabled").off('click');
            $("#professionalYes").attr("disabled", "disabled").off('click');
            $("#professionaldetails").attr("disabled", "disabled").off('click');
        }
        else {
            $('#studentdetails').fadeOut('slow');
            $("#employee").removeAttr('disabled');
            $("#employeedetails").removeAttr('disabled');
            $("#parttime").removeAttr('disabled');
            $("#freelanceYes").removeAttr('disabled');
            $("#freelancerdetails").removeAttr('disabled');
            $("#professionalYes").removeAttr('disabled');
            $("#professionaldetails").removeAttr('disabled');
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
            $("#freelanceYes").attr("disabled", "disabled").off('click');
            $("#freelancerdetails").attr("disabled", "disabled").off('click');
            $("#professionalYes").attr("disabled", "disabled").off('click');
            $("#professionaldetails").attr("disabled", "disabled").off('click');
        }
        else {
            $('#employeedetails').fadeOut('slow');
            $("#student").removeAttr('disabled');
            $("#studentdetails").removeAttr('disabled');
            $("#parttime").removeAttr('disabled');
            $("#freelanceYes").removeAttr('disabled');
            $("#freelancerdetails").removeAttr('disabled');
            $("#professionalYes").removeAttr('disabled');
            $("#professionaldetails").removeAttr('disabled');
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
            $("#freelanceYes").attr("disabled", "disabled").off('click');
            $("#parttime").removeAttr('disabled');
            $("#freelancerdetails").attr("disabled", "disabled").off('click');
            $("#professionalYes").attr("disabled", "disabled").off('click');
            $("#professionaldetails").attr("disabled", "disabled").off('click');
        }
        else {
            $("#student").removeAttr('disabled');
            $("#studentdetails").removeAttr('disabled');
            $("#employee").removeAttr('disabled');
            $("#employeedetails").removeAttr('disabled');
            $("#freelanceYes").removeAttr('disabled');
            $("#freelancerdetails").removeAttr('disabled');
            $("#professionalYes").removeAttr('disabled');
            $("#professionaldetails").removeAttr('disabled');
        }
    });
});

$(document).ready(function () {
    $('#freelanceYes').change(function () {
        if ($(this).is(":checked")) {
            $('#freelancerdetails').fadeIn('slow');
            $("#student").attr("disabled", "disabled").off('click');
            $("#studentdetails").attr("disabled", "disabled").off('click');
            $("#employee").attr("disabled", "disabled").off('click');
            $("#employeedetails").attr("disabled", "disabled").off('click');
            $("#parttime").attr("disabled", "disabled").off('click');
            $("#professionalYes").attr("disabled", "disabled").off('click');
            $("#professionaldetails").attr("disabled", "disabled").off('click');
        }
        else {
            $('#freelancerdetails').fadeOut('slow');
            $("#student").removeAttr('disabled');
            $("#studentdetails").removeAttr('disabled');
            $("#employee").removeAttr('disabled');
            $("#employeedetails").removeAttr('disabled');
            $("#parttime").removeAttr('disabled');
            $("#professionalYes").removeAttr('disabled');
            $("#professionaldetails").removeAttr('disabled');
        }
    });
});

$(document).ready(function () {
    $('#professionalYes').change(function () {
        if ($(this).is(":checked")) {
            $('#professionaldetails').fadeIn('slow');
            $("#student").attr("disabled", "disabled").off('click');
            $("#studentdetails").attr("disabled", "disabled").off('click');
            $("#employee").attr("disabled", "disabled").off('click');
            $("#employeedetails").attr("disabled", "disabled").off('click');
            $("#parttime").attr("disabled", "disabled").off('click');
            $("#freelanceYes").attr("disabled", "disabled").off('click');
            $("#freelancerdetails").attr("disabled", "disabled").off('click');
        }
        else {
            $('#professionaldetails').fadeOut('slow');
            $("#student").removeAttr('disabled');
            $("#studentdetails").removeAttr('disabled');
            $("#employee").removeAttr('disabled');
            $("#employeedetails").removeAttr('disabled');
            $("#parttime").removeAttr('disabled');
            $("#freelanceYes").removeAttr('disabled');
            $("#freelancerdetails").removeAttr('disabled');
        }
    });
});


//Disable Social media selection 

$(document).ready(function () {
    $('#ffacebook').change(function () {
        if ($(this).is(":checked")) {
            $("#finstagram").attr("disabled", "disabled").off('click');
            $('#fstaff').attr("disabled", "disabled").off('click');
            $('#fcordinator').attr("disabled", "disabled").off('click');
            $("#ffriend").attr("disabled", "disabled").off('click'); 
            $("#fgoogle").attr("disabled", "disabled").off('click');
        }
        else {
            $("#finstagram").removeAttr('disabled');
            $('#fstaff').removeAttr('disabled');
            $('#fcordinator').removeAttr('disabled');
            $("#ffriend").removeAttr('disabled'); 
            $("#fgoogle").removeAttr('disabled');
        }
    });
});

$(document).ready(function () {
    $('#finstagram').change(function () {
        if ($(this).is(":checked")) {
            $('#ffacebook').attr("disabled", "disabled").off('click');
            $("#fstaff").attr("disabled", "disabled").off('click');
            $('#fcordinator').attr("disabled", "disabled").off('click');
            $("#ffriend").attr("disabled", "disabled").off('click');
            $("#fgoogle").attr("disabled", "disabled").off('click');
        }
        else {
            $('#ffacebook').removeAttr('disabled');
            $("#fstaff").removeAttr('disabled');
            $('#fcordinator').removeAttr('disabled');
            $("#ffriend").removeAttr('disabled');
            $("#fgoogle").removeAttr('disabled');
        }
    });
});

$(document).ready(function () {
    $('#fstaff').change(function () {
        if ($(this).is(":checked")) {
            $('#fstaffname').fadeIn('slow');
            $('#ffacebook').attr("disabled", "disabled").off('click');
            $("#finstagram").attr("disabled", "disabled").off('click');
            $('#fcordinator').attr("disabled", "disabled").off('click');
            $("#ffriend").attr("disabled", "disabled").off('click');
            $("#fgoogle").attr("disabled", "disabled").off('click');
        }
        else {
            $('#fstaffname').fadeOut('slow');
            $('#ffacebook').removeAttr('disabled');
            $("#finstagram").removeAttr('disabled');
            $('#fcordinator').removeAttr('disabled');
            $("#ffriend").removeAttr('disabled');
            $("#fgoogle").removeAttr('disabled');
        }
    });
});

$(document).ready(function () {
    $('#fcordinator').change(function () {
        if ($(this).is(":checked")) {     
            $('#fcordinatorname').fadeIn('slow');
            $('#ffacebook').attr("disabled", "disabled").off('click');
            $("#finstagram").attr("disabled", "disabled").off('click');
            $('#fstaff').attr("disabled", "disabled").off('click');
            $("#ffriend").attr("disabled", "disabled").off('click');
            $("#fgoogle").attr("disabled", "disabled").off('click');
        }
        else {
            $('#fcordinatorname').fadeOut('slow');
            $('#ffacebook').removeAttr('disabled');
            $("#finstagram").removeAttr('disabled');
            $('#fstaff').removeAttr('disabled');
            $("#ffriend").removeAttr('disabled');
            $("#fgoogle").removeAttr('disabled');
        }
    });
});

$(document).ready(function () {
    $('#ffriend').change(function () {
        if ($(this).is(":checked")) {
            $('#ffacebook').attr("disabled", "disabled").off('click');
            $("#finstagram").attr("disabled", "disabled").off('click');
            $('#fstaff').attr("disabled", "disabled").off('click');
            $("#fcordinator").attr("disabled", "disabled").off('click');
            $("#fgoogle").attr("disabled", "disabled").off('click');
        }
        else {
            $('#ffacebook').removeAttr('disabled');
            $("#finstagram").removeAttr('disabled');
            $('#fstaff').removeAttr('disabled');
            $("#fcordinator").removeAttr('disabled');
            $("#fgoogle").removeAttr('disabled');
        }
    });
});

$(document).ready(function () {
    $('#fgoogle').change(function () {
        if ($(this).is(":checked")) {
            $('#ffacebook').attr("disabled", "disabled").off('click');
            $("#finstagram").attr("disabled", "disabled").off('click');
            $('#fstaff').attr("disabled", "disabled").off('click');
            $("#fcordinator").attr("disabled", "disabled").off('click');
            $("#ffriend").attr("disabled", "disabled").off('click');
        }
        else {
            $('#ffacebook').removeAttr('disabled');
            $("#finstagram").removeAttr('disabled');
            $('#fstaff').removeAttr('disabled');
            $("#fcordinator").removeAttr('disabled');
            $("#ffriend").removeAttr('disabled');
        }
    });
});


function experiencehandleClick(value) {
    if (value == "2") {
        $('#experiencecheck').fadeIn('slow');
    }
    else {
        $('#experiencecheck').fadeOut('slow');
    }
}

//Submit button show hide
//$(document).ready(function () {
//    $('#submit').change(function () {
//        if ($(this).is(":checked")) {
//            $("#sumbitprofile").removeAttr('disabled');
//        }
//        else {
//            $("#sumbitprofile").attr("disabled", "disabled").off('click');
//        }
//    });
//});


function encodeImageFileAsURL(e, a, i) {

    var filesSelected = e.files;
    if (filesSelected["0"].size > 1000000) {
        alert("Unable to proceed upload, File is larger than 1 MB");
        document.getElementById(i).value = null;
    } else {
        if (filesSelected.length > 0) {
            var fileToLoad = filesSelected[0];

            var fileReader = new FileReader();

            fileReader.onload = function (fileLoadedEvent) {
                var srcData = fileLoadedEvent.target.result;

                var newImage = document.createElement('img');
                newImage.src = srcData;

                var $img = null;
                $img = $("<img style=\"width: 95px; height: 95px; vertical-align: middle; \"/>");

                $img.attr("src", srcData)
                $(a).html($img);
            }
            fileReader.readAsDataURL(fileToLoad);
        }
    }
}


//Profile Submit
function submitFunction() {

    $("#sumbitprofile").attr("disabled", "disabled").off('click');

    var profileRequest = {};
    profileRequest.FullName = $('#fullname').val();
    profileRequest.ShortName = $('#shortname').val();
    profileRequest.NIC = $('#nicno').val();


    profileRequest.Photo1 = document.getElementById("Image1").innerHTML;  
    profileRequest.Photo2 = document.getElementById("Image2").innerHTML;  
    profileRequest.Photo3 = document.getElementById("Image3").innerHTML;  
    profileRequest.Photo4 = document.getElementById("Image4").innerHTML;  
    profileRequest.Photo5 = document.getElementById("Image5").innerHTML;  


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

    if (document.getElementById('freelance').checked) {
        profileRequest.PartTimePromoter = true;
    }
    else {
        profileRequest.PartTimePromoter = false;
    }

    if (document.getElementById('englishA').checked) {
        profileRequest.EnglishA = true;
    }
    else {
        profileRequest.EnglishA = false;
    }

    if (document.getElementById('englishB').checked) {
        profileRequest.EnglishB = true;
    }
    else {
        profileRequest.EnglishB = false;
    }

    if (document.getElementById('englishC').checked) {
        profileRequest.EnglishC = true;
    }
    else {
        profileRequest.EnglishC = false;
    }

    if (document.getElementById('tamilA').checked) {
        profileRequest.TamilA = true;
    }
    else {
        profileRequest.TamilA = false;
    }

    if (document.getElementById('tamilB').checked) {
        profileRequest.TamilB = true;
    }
    else {
        profileRequest.TamilB = false;
    }

    if (document.getElementById('tamilC').checked) {
        profileRequest.TamilC = true;
    }
    else {
        profileRequest.TamilC = false;
    }

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
            $("#successModel").modal()
            //alert('ok');
            //$('body').append('<div id="over" style="position: absolute;top:0;left:0;width: 100%;height:100%;z-index:2;opacity:0.4;filter: alpha(opacity = 50)"></div>');
        },
        error: function (result) {
            $("#sumbitprofile").removeAttr('disabled');
            $("#failModel").modal()
        }
    });
}
