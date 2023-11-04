var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/Adertisment/getalls' },
        "columns": [
            { data: 'email', "width": "25%" },
            { data: 'name', "width": "15%" },

        ]
    });
}
