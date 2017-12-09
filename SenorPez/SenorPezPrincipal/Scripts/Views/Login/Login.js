$(document).ready(function () {
    $('#returnUrl').val(getParameterByName('ReturnUrl'));

    /*
        Form validation
    */
    $('.login-form input[type="text"], .login-form input[type="password"], .login-form textarea').on('focus', function () {
        $(this).removeClass('input-error');
    });

    $('.login-form').on('submit', function (e) {

        $(this).find('input[type="text"], input[type="password"], textarea').each(function () {
            if ($(this).val() == "") {
                e.preventDefault();
                $(this).addClass('input-error');
            }
            else {
                $(this).removeClass('input-error');
            }
        });

    });

});


function getParameterByName(name) {
    var regexS = "[\\?&]" + name + "=([^&#]*)",
  regex = new RegExp(regexS),
  results = regex.exec(window.location.search);
    if (results == null) {
        return "";
    } else {
        return decodeURIComponent(results[1].replace(/\+/g, " "));
    }
}

$("#olvidelacontra").click(function () {
    var usuario = $('#modelusername').val();
    if (usuario == '') {
        $.alert({
            title: 'Error!',
            content: 'Debe ingresar un usuario!',
            type: 'red',
            typeAnimated: true,
            onClose: function () {
                $('#modelusername').focus();
            },
        });

    } else {
        var obj = {'Usuario': usuario};
        $.ajax({
            type: "POST",
            url: $("#UrlEnviarMailRecuperacion").val(),
            traditional: true,
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ obj: obj }),
            success: function (data) {
                $.each(data, function (index, ladata) {
                    if (ladata[0]['vEmailHidden'] != '' && ladata[0]['vEmailHidden'] != 'No Existe') {
                        $.alert({
                            title: 'Todo Bien!',
                            content: 'Se le envio su contraseña al correo: ' + ladata[0]['vEmailHidden'],
                            type: 'green',
                            typeAnimated: true,
                        });
                    } else {
                        $.alert({
                            title: 'Error!',
                            content: 'El Usuario no existe',
                            type: 'red',
                            typeAnimated: true,
                        });
                    }
                });

            }
        });
    }
});
