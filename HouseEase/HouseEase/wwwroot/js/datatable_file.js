$(document).ready(function () {
    var dataTable = $('#pageTable').DataTable({
        dom: '<"top"i>rt<"bottom"flp><"clear">',
        "columnDefs": [
            { "className": "dt-center", "targets": "_all" }
        ],
        /*"dom": 'lrt' */
    });
    $("#filter").keyup(function () {
        dataTable.search(this.value).draw();
    })
    
});
$(document).ready(function () {
    $('.pageSelect').select2({
        allowClear: true,
        width: '100%',
    });
});

function tableToExcel() {
    var table2excel = new Table2Excel();
    table2excel.export(document.querySelectorAll("table.table"));
}
