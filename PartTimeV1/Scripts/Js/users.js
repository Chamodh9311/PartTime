$(document).ready(function () {
    $('#myTable').DataTable({
        "ajax": {
            "url": "/Admin/GetUserProfileData",
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

//$(document).ready(function () {

//    window.auditLogTable = $('#myTable').DataTable({
//        destroy: true,
//        "bFilter": false,
//        "pagingType": "simple_numbers",
//        "pageLength": 25,
//        "processing": true,
//        "language": {
//            "processing": "<img src='/images/loader.gif'>  <div style='font-weight: 700; font-size: 14px; display: inline-block;'> &nbsp; &nbsp; Loading... </div>"
//        },
//        "serverSide": true,
//        "deferRender": true,
//        "stateSave": false,
//        "ajax": {
//            "url": "/Admin/GetUserProfileData",
//            "type": "GET",
//            "datatype": "json",
//            "error": function (xhr, error, thrown) {
//                $("#AuditLogTable_processing").css({ "height": "47px", "font-size": "15px" }).text(" " + thrown);
//                //ShowPageContent();
//            }
//        },
//        "columns": [
//            { "data": "FullName", "autoWidth": true },
//            { "data": "NIC", "autoWidth": true },
//            { "data": "Mobile1", "autoWidth": true }

//        ],
//        //"columnDefs": [
//        //    {
//        //        "targets": 2,
//        //        "data": 'TriggerdDate',
//        //        "render": function (data, type, full, meta) {

//        //            var dateTimeparts = data.split("T");
//        //            var date = dateTimeparts[0];
//        //            var time = dateTimeparts[1];
//        //            date = date.split("-");
//        //            time = time.split(":");
//        //            return date[2] + "/" + date[1] + "/" + date[0] + " : " + time[0] + ":" + time[1];
//        //        }
//        //    }]
//    });
//});