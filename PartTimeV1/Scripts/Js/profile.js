

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
        rowReorder: {
            selector: 'td:nth-child(2)'
        },
        responsive: true,
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

            $("label[for='fullname']").text(response.FullName);
            document.getElementById("Image1").innerHTML = response.Photo1;
            $("label[for='fullname']").text(response.FullName);
            $("label[for='nic']").text(response.NIC);
            $("label[for='location']").text(response.HomeDistrict);

            if (response.Role == "User") {
                $('a[href*="profileView"]').attr('href', '/Profile/Promoter');
            }
            else {
                $('a[href*="profileView"]').attr('href', '/Profile/Coordinator');
            }

            window.UserId = response.UserId;
        }
    }).fail(function (error) {
        alert(error);
    });
}
