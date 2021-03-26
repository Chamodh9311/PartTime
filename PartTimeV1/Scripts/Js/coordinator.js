$(function () {
    //Initialize Select2 Elements
    $('.select2').select2();

    //Input mask
    $('[data-mask]').inputmask()

});

$(window).on('load', function () {
    $('#validateModel').modal('show');
});

$("#validateModel").on("hidden.bs.modal", function () {
    if ($('#secretCode').val() == "Part2019@") {
        $("#sumbitprofile").removeAttr('disabled');
    }
});

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// Coordinator //////////////////////////////////////////////////////////////////////////////////////////
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
            document.getElementById('studentdetails1').value = "";
            document.getElementById('studentdetails2').value = "";
            document.getElementById('studentdetails3').value = "";
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
            document.getElementById('employeedetails1').value = "";
            document.getElementById('employeedetails2').value = "";
            document.getElementById('employeedetails3').value = "";
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
            document.getElementById('freelancerdetailsdrp').value = "-Select-";
            document.getElementById('otherExp').value = "";
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
            document.getElementById('professionaldetailsdrp').value = "-Select-";
            document.getElementById('professionalexp').value = "";
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


function experiencehandleClick(value) {
    if (value == "2") {
        $('#experiencecheck').fadeIn('slow');
    }
    else {
        $('#experiencecheck').fadeOut('slow');
        document.getElementById('promoexperience').value = "";
        $("#brandnames").val('').change();
        document.getElementById('otherbrandnames').value = "";
        $("#otherpromoexperience").val('').change();
        document.getElementById('otherexperience').value = "";
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

    var coordinatorRequest = {};
    coordinatorRequest.FullName = $('#fullname').val();
    coordinatorRequest.ShortName = $('#shortname').val();
    coordinatorRequest.NIC = $('#nicno').val();


    coordinatorRequest.Photo1 = document.getElementById("Image1").innerHTML;
    coordinatorRequest.Photo2 = document.getElementById("Image2").innerHTML;
    coordinatorRequest.Photo3 = document.getElementById("Image3").innerHTML;
    coordinatorRequest.Photo4 = document.getElementById("Image4").innerHTML;
    coordinatorRequest.Photo5 = document.getElementById("Image5").innerHTML;


    coordinatorRequest.Mobile1 = $('#mobile01').val();
    if (document.getElementById('whatsApp1').checked) {
        coordinatorRequest.Mobile1Whatsapp = true;
    }
    else {
        coordinatorRequest.Mobile1Whatsapp = false;
    }

    if (document.getElementById('viber1').checked) {
        coordinatorRequest.Mobile1Viber = true;
    }
    else {
        coordinatorRequest.Mobile1Viber = false;
    }

    coordinatorRequest.Mobile2 = $('#mobile02').val();
    if (document.getElementById('whatsApp2').checked) {
        coordinatorRequest.Mobile2Whatsapp = true;
    }
    else {
        coordinatorRequest.Mobile2Whatsapp = false;
    }

    if (document.getElementById('viber2').checked) {
        coordinatorRequest.Mobile2Viber = true;
    }
    else {
        coordinatorRequest.Mobile2Viber = false;
    }

    coordinatorRequest.Mobile3 = $('#mobile03').val();
    if (document.getElementById('whatsApp3').checked) {
        coordinatorRequest.Mobile3Whatsapp = true;
    }
    else {
        coordinatorRequest.Mobile3Whatsapp = false;
    }

    if (document.getElementById('viber3').checked) {
        coordinatorRequest.Mobile3Viber = true;
    }
    else {
        coordinatorRequest.Mobile3Viber = false;
    }

    coordinatorRequest.DOB = $('#dob').val();
    coordinatorRequest.Age = $('#age').val();

    if (document.getElementById('genderM').checked) {
        coordinatorRequest.GenderMale = true;
    }
    else {
        coordinatorRequest.GenderMale = false;
    }

    if (document.getElementById('genderF').checked) {
        coordinatorRequest.GenderFemale = true;
    }
    else {
        coordinatorRequest.GenderFemale = false;
    }

    coordinatorRequest.CurrentDistrict = $('#currentdistrict option:selected').text();
    coordinatorRequest.CurrentTown = $('#currentcity option:selected').text();
    coordinatorRequest.HomeDistrict = $('#homedistrict option:selected').text();
    coordinatorRequest.HomeTown = $('#hometown option:selected').text();

    if (document.getElementById('tsizeS').checked) {
        coordinatorRequest.ShirtSizeS = true;
    }
    else {
        coordinatorRequest.ShirtSizeS = false;
    }

    if (document.getElementById('tsizeM').checked) {
        coordinatorRequest.ShirtSizeM = true;
    }
    else {
        coordinatorRequest.ShirtSizeM = false;
    }

    if (document.getElementById('tsizeL').checked) {
        coordinatorRequest.ShirtSizeL = true;
    }
    else {
        coordinatorRequest.ShirtSizeL = false;
    }

    if (document.getElementById('tsizeXS').checked) {
        coordinatorRequest.ShirtSizeXS = true;
    }
    else {
        coordinatorRequest.ShirtSizeXS = false;
    }

    //
    //12. I am SECTION - START
    //
    if (document.getElementById('student').checked) {
        coordinatorRequest.Student = true;
    }
    else {
        coordinatorRequest.Student = false;
    }

    coordinatorRequest.University = $('#studentdetails1').val();
    coordinatorRequest.Course = $('#studentdetails2').val();
    coordinatorRequest.UniYear = $('#studentdetails3').val();

    if (document.getElementById('employee').checked) {
        coordinatorRequest.Employeed = true;
    }
    else {
        coordinatorRequest.Employeed = false;
    }

    coordinatorRequest.Company = $('#employeedetails1').val();
    coordinatorRequest.Branch = $('#employeedetails2').val();
    coordinatorRequest.Designation = $('#employeedetails3').val();

    if (document.getElementById('parttime').checked) {
        coordinatorRequest.FullTimePromoter = true;
    }
    else {
        coordinatorRequest.FullTimePromoter = false;
    }

    if (document.getElementById('freelanceYes').checked) {
        coordinatorRequest.IsFreelancer = true;
    }
    else {
        coordinatorRequest.IsFreelancer = false;
    }

    coordinatorRequest.Freelancer = $('#freelancerdetailsdrp').val();
    coordinatorRequest.FreelancerOther = $('#otherExp').val();


    if (document.getElementById('professionalYes').checked) {
        coordinatorRequest.IsSelfemployed = true;
    }
    else {
        coordinatorRequest.IsSelfemployed = false;
    }

    coordinatorRequest.Selfemployed = $('#professionaldetailsdrp').val();
    coordinatorRequest.SelfemployedOther = $('#professionalexp').val();

    if (document.getElementById('freelance').checked) {
        coordinatorRequest.PartTimePromoter = true;
    }
    else {
        coordinatorRequest.PartTimePromoter = false;
    }
    //
    //12. I am SECTION -END
    //

    if (document.getElementById('englishA').checked) {
        coordinatorRequest.EnglishA = true;
    }
    else {
        coordinatorRequest.EnglishA = false;
    }

    if (document.getElementById('englishB').checked) {
        coordinatorRequest.EnglishB = true;
    }
    else {
        coordinatorRequest.EnglishB = false;
    }

    if (document.getElementById('englishC').checked) {
        coordinatorRequest.EnglishC = true;
    }
    else {
        coordinatorRequest.EnglishC = false;
    }

    if (document.getElementById('tamilA').checked) {
        coordinatorRequest.TamilA = true;
    }
    else {
        coordinatorRequest.TamilA = false;
    }

    if (document.getElementById('tamilB').checked) {
        coordinatorRequest.TamilB = true;
    }
    else {
        coordinatorRequest.TamilB = false;
    }

    if (document.getElementById('tamilC').checked) {
        coordinatorRequest.TamilC = true;
    }
    else {
        coordinatorRequest.TamilC = false;
    }

    if (document.getElementById('experienceno').checked) {
        coordinatorRequest.SalesExperienceNo = true;
    }
    else {
        coordinatorRequest.SalesExperienceYes = false;
    }

    if (document.getElementById('experienceYes').checked) {
        coordinatorRequest.SalesExperienceYes = true;
    }
    else {
        coordinatorRequest.SalesExperienceNo = false;
    }

    coordinatorRequest.SalesExperienceYears = $('#promoexperience').val();
    coordinatorRequest.Brands = $('#brandnames').select2("val");
    coordinatorRequest.BrandsOther = $('#otherbrandnames').val();
    coordinatorRequest.OtherExperience = $('#otherpromoexperience').select2("val");
    coordinatorRequest.OtherExperienceOther = $('#otherexperience').val();
    coordinatorRequest.PreviousAdvertisingCompany = $('#company').val();
    coordinatorRequest.PreviousAdvertisingSupervisors = $('#peoplenames').val();

    coordinatorRequest.AccountHolder = $('#accountholder').val();
    coordinatorRequest.AccountNumber = $('#accountnumber').val();
    coordinatorRequest.Bank = $('#bank').val();
    coordinatorRequest.BankBranch = $('#branch').val();


        $.ajax({
            type: "POST",
            url: '/Admin/CoordinatorProfileSubmit',
            data: '{coordinatorRequest: ' + JSON.stringify(coordinatorRequest) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",

            success: function (result) {

                if (result != "Error") {
                    $("#sumbitprofile").attr("disabled", "disabled").off('click');
                    $("#successModel").modal()
                }
                else {
                    $("#sumbitprofile").removeAttr('disabled');
                    $("#failModel").modal()
                }
            },
            error: function (result) {
                $("#sumbitprofile").removeAttr('disabled');
                $("#failModel").modal()
            }
        });
}
