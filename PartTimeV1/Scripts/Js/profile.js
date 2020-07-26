

function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json'
    });
}  

$(document).ready(function () {

    $('#SchedulerTable').DataTable({
        "ajax": {
            "url": "/Scheduler/GetActiveEvents",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "GigName", "autoWidth": true },
            { "data": "Brands", "autoWidth": true },
            { "data": "FromDate", "autoWidth": true },
            { "data": "ToDate", "autoWidth": true },
            { "data": "PromoterCount", "autoWidth": true },
            { "data": "Town", "autoWidth": true },
            { "data": "Comments", "autoWidth": true }
        ]
    });
});

window.onload = function () {

    var obj = { userId: window.location.href.split('#')[1] };
    AjaxCall('/Admin/GetUserProfile', JSON.stringify(obj), 'POST').done(function (response) {
        if (response != null) {

            document.getElementById("userName").value = response.FullName;
            document.getElementById("shortname").value = response.ShortName;
            document.getElementById("nicno").value = response.NIC;
            document.getElementById("Image1").innerHTML = response.Photo1;

            window.UserId = response.UserId;
        }
    }).fail(function (error) {
        alert(error);
    });
}
