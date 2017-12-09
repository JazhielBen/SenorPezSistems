var validarSession = true;
$(function () {
    $(this).mousemove(function (e) {
        if (validarSession) {
            $.post($("#UrlControlSession").val(), function (data) {

            });
        }
    });

    $(this).keypress(function (e) {
        if (validarSession) {
            $.post($("#UrlControlSession").val(), function (data) {

            });
        }
    });

    $(document).ajaxComplete(function (a, xhr, c) {
        if (xhr.status === 401) {
            swal('Lo sentimos, su sesión ha caducado');
            location.reload();
        }
    });
});