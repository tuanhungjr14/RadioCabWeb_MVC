var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/api/users' },
        "columns": [
            { "data": "name" },
            { "data": "experience" },
            { "data": "streetAddress" },
            { "data": "city" },
            { "data": "phoneNumber" }
        ]
    });
}

