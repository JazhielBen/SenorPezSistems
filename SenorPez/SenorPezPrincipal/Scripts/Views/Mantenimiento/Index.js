$(document).ready(function () {
    LoadTable();
});
function LoadTable() {
    $.fn.dataTable.ext.errMode = function (settings, helpPage, message) { };
    $('#TablaItems').on('page.dt', function () {

    });
    $('#TablaItems').DataTable({
        language: { url: "//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json" },
        responsive: true,
        processing: true,
        serverSide: true,
        searching: false,
        scrollX: true,
        dom: '<"top"i>rt<"bottom"flp><"clear">',
        bInfo: false,
        ajax: {
            url: $("#UrlLoadEmpleados").val(),
            type: "POST",
            data: function (d) {
                //d.iCodConvocatoria = $("#imputConvocatoria").val()
            },
            datatype: "json"
        },
        rowId: 'iCodEmpleado',
        columns: [
                { data: "iCodEmpleado", name: "iCodEmpleado", autoWidth: true, visible: true, className: "hidden" },
                { data: "vUsuario", name: "vUsuario", autoWidth: true, orderable: false, visible: true, className: "hidden-xs" },
                { data: "vNombre", name: "vNombre", autoWidth: true, orderable: false, visible: true, className: "hidden-xs" },
                { data: "vApellido", name: "vApellido", autoWidth: true, orderable: false, visible: true, className: "hidden-xs" },
                { data: "vTelefono", name: "vTelefono", autoWidth: true, orderable: true },
                { data: "vMail", name: "vMail", autoWidth: true, orderable: false, visible: true },
                { data: "vDocPersona", name: "vDocPersona", autoWidth: true, orderable: false, visible: true},
                { data: "vNombrePerfil", name: "vNombrePerfil", autoWidth: true, orderable: false, visible: true },
        ], columnDefs: [
                { className: "text-center", targets: [1, 2, 3, 4] },
                { className: "dt-right", targets: 5 },
        ]
    });

}