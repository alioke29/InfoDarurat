

function clearText()
{

    $('#txtUserNameLogin').val('');
    $('#txtPasswordLogin').val('');
}


function getLogin() {

    $("#mask").show();

    var userName = $('#txtUserNameLogin').val();
    var password = $('#txtPasswordLogin').val();

    if (userName == '') {

        swal({
            title: "User Name  is required!!",
            text: "Please fill user name."
        });

        $("#mask").hide();
        return;
    }

    if (password == '') {

        swal({
            title: "Password is required!!",
            text: "Please fill password."
        });
        $("#mask").hide();
        return;
    }

    $.ajax({
        url: '/User/GetLogin/',
        method: 'POST',
        dataType: "json",
        data: {
            userName: userName,
            password: password
        }, cache: false,
        success: function (json) {

            $("#mask").hide();

            if (json.error == '1') {

                swal({
                    title: "Login Failed!",
                    text: "User name or password incorrect."
                });

                return;
            }
            else if (json.error == '2') {

                swal({
                    title: "User already login!",
                    text: "Please contact call center."
                });

                return;
            }
            else if (json.error == '3') {

                swal({
                    title: "User is inactive!",
                    text: "Please contact call center."
                });

                return;
            }

            window.location = '/Home/Index';

        },
        error: function (json) {
            alert(json.message);
        }
    });

}


function getLogout() 
{


    $.ajax({
        url: '/User/GetLogout',
        type: 'GET',
        dataType: 'json',
        cache: false,
        success: function (json) {
        
            if (json.error == '0') {

                window.location = '/Login/Index';
            }

        },
        error: function (json) {
            alert(json.message);
        }
    });

}