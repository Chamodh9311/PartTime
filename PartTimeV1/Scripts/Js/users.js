$(document).ready(function () {
    $('#myTable').DataTable({
        "ajax": {
            "url": "/Search/GetUserProfileData",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "FullName", "autoWidth": true },
            { "data": "NIC", "autoWidth": true },
            { "data": "Mobile1", "autoWidth": true }
        ]
    });
});
