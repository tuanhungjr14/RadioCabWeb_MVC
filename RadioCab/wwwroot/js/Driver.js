var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/api/users',
            dataSrc: ''
        },
        "columns": [
            { "data": "name" },
            { "data": "experience" },
            { "data": "streetAddress" },
            { "data": "city" },
            { "data": "phoneNumber" }
        ]
    });
}