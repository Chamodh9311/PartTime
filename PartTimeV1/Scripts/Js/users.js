$(function () {
    //Initialize Select2 Elements
    $('.select2').select2();

    //Input mask
    $('[data-mask]').inputmask()

});

$(document).ready(function () {

    $('#userTable').DataTable({
        "ajax": {
            "url": "/Search/GetUserProfileData",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "FullName", "autoWidth": true },
            { "data": "NIC", "autoWidth": true },
            { "data": "DOB", "autoWidth": true },
            { "data": "Mobile", "autoWidth": true },
            { "data": "Age", "autoWidth": true },
            { "data": "CurrentCity", "autoWidth": true },
            { "data": "HomeTown", "autoWidth": true },
            { "data": "Role", "autoWidth": true },
            { "data": "Approved", "autoWidth": true }
        ],
        "columnDefs": [{
            "targets": 8,
            "data": 'Approved',
            "render": function (data, type, full, meta) {
                var rtnvalue = "";
                if (full.Role == "Promoter") {
                    rtnvalue = '&nbsp;&nbsp;&nbsp;&nbsp;<a href="/Admin/Index/#' + full.UserId + '" role="button" class="btn btn-success btn-xs">View</a> &nbsp;&nbsp;  ';
                }
                else {
                    rtnvalue = '&nbsp;&nbsp;&nbsp;&nbsp;<a href="/Admin/Coordinator/#' + full.UserId + '" role="button" class="btn btn-success btn-xs">View</a> &nbsp;&nbsp;  ';
                }

                if (data == "False") {
                    rtnvalue = rtnvalue + '<a href="javascript: void(0);" class="btn btn-primary btn-xs" data-id=' + full.UserId + ' onclick="javascript: approveUser(this);">Approve</a> &nbsp;&nbsp;';
                }
                rtnvalue = rtnvalue + '<a href="javascript: void(0);" class="btn btn-danger btn-xs" data-id=' + full.UserId + ' onclick="javascript: banUser(this);">Ban</a>';
                return rtnvalue;
            }
        }]
    });
});


function approveUser(element) {
    var obj = { userId: $(element).data('id') };
    AjaxCall('/Search/ApproveUser', JSON.stringify(obj), 'POST').done(function (response) {
        location.reload();
    }).fail(function (error) {
        alert(error.StatusText);
    });
}

function banUser(element) {
    var obj = { userId: $(element).data('id') };
    AjaxCall('/Search/BanUser', JSON.stringify(obj), 'POST').done(function (response) {
        location.reload();
    }).fail(function (error) {
        alert(error.StatusText);
    });
}


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