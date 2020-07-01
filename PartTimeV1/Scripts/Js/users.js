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
            { "data": "Role", "autoWidth": true }
        ]
    });
});
