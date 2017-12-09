$(document).ready(function () {
    loadInfo();
});

function loadInfo() {
    $.ajax({
        data: { iCodEmpresa: $("#iCodEmpresa").data('value')},
        type: "POST",
        url: $("#UrlLoadInfo").val(),
        success: function (data) {
            if (data.iCodEmpresa != 0) {
                document.getElementById('LbTotalDia').innerText = data.iTotal;
            } else {
                document.getElementById('LbTotalDia').innerText = '0.00';
            }
        }
    });

}