/// <reference path="../../../Views/Home/Index.cshtml" />


$(document).ready(function () {
});

function loadpage() {


}

function login() {
    debugger
    $.ajax({
        url: '../Login/LoginProcedure',
        type: 'POST',
        data: {
            vNombreCargo : $('#username').val(),
            vPassword : $('#password').val() 
        },
        success: function (result) {
            if (result.data == 'OK') {
                location.href = '../Home/Index'; 
            } 
        }
    });
}