
function removeElementsFromArray(someArray, filter) {
    var newArray = [];
    for (var index = 0; index < someArray.length; index++) {
        if (filter(someArray[index]) == false) {
            newArray.push(someArray[index]);
        }
    }
    return newArray;
}

function isNullOrUndefined(item) {
    return (item == null || typeof (item) == "undefined");
}

function getBaseURL() {

    var baseURL;

    if (location.href.indexOf('localhost') !== -1)
        baseURL = location.protocol + "//" + window.location.host;
    else {

        if (location.href.indexOf('s://') !== -1)
            baseURL = "https://" + location.hostname + (location.port && ":" + location.port) + getAppPath();
        else
            baseURL = location.protocol + "//" + location.hostname + (location.port && ":" + location.port) + getAppPath();

        baseURL = baseURL.replace('/Pages', '');
        baseURL = baseURL.replace('/Home', '');
    }

    return baseURL;
}

function getBaseURLFixing() {

    var baseURL;
    if (getBaseURL().indexOf('localhost') !== -1)
        baseURL = getBaseURL() + "/";
    else
        baseURL = getBaseURL();

    return baseURL
}


window.onload = function () {

    if ($("#hiddenStatusFilter").val() != '')
        $("#ddlStatusFilter").val($("#hiddenStatusFilter").val());
    else
        $("#ddlStatusFilter").val('');

    if ($("#hiddenRoleFilter").val() != '')
        $("#ddlRoleFilter").val($("#hiddenRoleFilter").val());
    else
        $("#ddlRoleFilter").val('');

}

//function getMessageValidation() {

//    var userName = $("#txtUserName").val();
//    var password = $("#txtPassword").val();
//    var confirmPass = $("#txtConfirmPassword").val();
//    var fullname = $("#txtFullname").val();
//    var email = $("#txtEmail").val();
//    var roleId = $("#ddlRole").val();

//    var message = new Array();

//    if (userName == '') message[0] = "User Name is required.";
//    if (password == '') message[1] = 'Password is required.';
//    if (confirmPass == '') message[2] = 'Confirm Password is required.';
//    if (fullname == '') message[3] = "Fullname is required.";
//    if (email == '') message[4] = 'Email is required.';
//    if (validateEmail(email)) message[5] = "Invalid email.";
//    if (roleId == '') message[6] = 'Please select role.';

//    return removeElementsFromArray(message, isNullOrUndefined);
//}

function getMessageValidationBorder() {

    var userName = $("#txtUserName").val();
    var password = $("#txtPassword").val();
    var confirmPass = $("#txtConfirmPassword").val();
    var fullname = $("#txtFullname").val();
    var email = $("#txtEmail").val();
    var roleId = $("#ddlRole").val();

    if (userName == '') $("#txtUserName").css("border", "1px solid red")
    else $("#txtUserName").css("border", "");

    if (password == '') $("#txtPassword").css("border", "1px solid red")
    else $("#txtPassword").css("border", "");

    if (confirmPass == '') $("#txtConfirmPassword").css("border", "1px solid red")
    else $("#txtConfirmPassword").css("border", "");

    if (fullname == '') $("#txtFullname").css("border", "1px solid red")
    else $("#txtFullname").css("border", "");

    if (email == '') $("#txtEmail").css("border", "1px solid red")
    else $("#txtEmail").css("border", "");

    if (roleId == '') $("#ddlRole").css("border", "1px solid red")
    else $("#ddlRole").css("border", "");


}

function getSave() {

    var id = $("#hdnId").val();

    var userName = $("#txtUserName").val();
    var password = $("#txtPassword").val();
    var confirmPass = $("#txtConfirmPassword").val();
    var fullname = $("#txtFullname").val();
    var noKartuId = $("#ddlKartu").val();
    var email = $("#txtEmail").val();
    var roleId = $("#ddlRole").val();

    var isLogin;
    if ($("#chkIsLogin").prop("checked"))
        isLogin = 'true';
    else
        isLogin = 'false';

    var isActive = $("#ddlIsActive").val();

    var paramAll = userName + '~' + password + '~' + confirmPass + '~' +
                fullname + "~" + noKartuId + "~" + email + "~" + roleId + "~" + isLogin + "~" + isActive;


    $("#mask").show();

    var userId = '';
    if (id != null)
        userId = id;
    else
        userId = '';


    $.ajax({
        url: '/User/AddEditUser/?id=' + userId,
        method: 'POST',
        dataType: "json",
        data: {
                paramAll: paramAll
        },
        cache: false,
        success: function (json) {

            $("#mask").hide();

            if (json.error == '1') {

                getMessageValidationBorder();
                return;
            }
            else if (json.error == '2') {

                swal({
                    title: "Confirmation",
                    text: "User Name has already exist.",
                    type: "warning",
                    timer: 3000
                },
                function () {
                    return;
                });

            }
            else if (json.error == '3') {

                swal({
                    title: "Confirmation",
                    text: "Password must include alpha and numeric.",
                    type: "warning",
                    timer: 3000
                },
                    function () {
                        return;
                    });
            }
            else if (json.error == '4') {

                swal({
                    title: "Confirmation",
                    text: "Password and Confirm Password does not match.",
                    type: "warning",
                    timer: 3000
                },
                    function () {
                        return;
                    });
            }
            else if (json.error == '5') {

                swal({
                    title: "Confirmation",
                    text: "Email has already exist.",
                    type: "warning",
                    timer: 3000
                },
                    function () {
                        return;
                    });
            }
            else if (json.error == '6') {

                swal({
                    title: "Confirmation",
                    text: "Invalid email.",
                    type: "warning",
                    timer: 3000
                },
                    function () {
                        return;
                    });
            }


            if (json.error == 'Edit') {

                swal({
                    title: "Save success!",
                    text: "Edit user has been saved.",
                    type: "success",
                    timer: 3000
                },
                    function () {
                        getReset();
                    });
            }
            else if (json.error == 'Add') {

                swal({
                    title: "Save success!",
                    text: "Add user has been saved.",
                    type: "success",
                    timer: 3000
                },
                function () {
                    getReset();
                });
            }

        },
        error: function (json) {
            alert(json);
        }
    });   
}

function getDelete(id, UserName) {

    swal({
        title: "Are you sure want to delete?",
        text: "Name = '" + UserName + "' \n\n You will not be able to recover this selected data!",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "NO",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "YES",
        closeOnConfirm: false
    }, function () {

        $("#mask").show();

        $.ajax({
            url: '/User/DeleteUser/?id=' + id,
            type: 'GET',
            dataType: 'json',
            cache: false,
            success: function (json) {
                
                $("#mask").hide();

                if (json.error == '0') {

                    swal({
                        title: "Deleted!",
                        text: "Selected user has been deleted.",
                        type: "success",
                        timer: 3000
                    },
                    function () {
                        getReset();
                    });

                }
            },
            error: function (json) {
                alert(json);
            }
        });


    });
}

function getFilter() {

    var fullname = $("#txtFullnameFilter").val();
    var email = $("#txtEmailFilter").val();
    var isActive = $("#ddlStatusFilter").val();
    var roleId = $("#ddlRoleFilter").val();

    $("#mask").show();

    window.location = '/Home/UserList/?id=4_5&isFilter=true&fullname=' + fullname + '&email=' + email +
                      '&isActive=' + isActive + '&roleId=' + roleId;

}

function getView(id, userName, password, confirmPass, fullname, kartuId, email, roleId, isLogin, isActive) {

    $("#txtUserName").css("border", "");
    $("#txtPassword").css("border", "");
    $("#txtConfirmPassword").css("border", "");
    $("#txtFullname").css("border", "");
    $("#txtEmail").css("border", "");
    $("#ddlRole").css("border", "");
    
    $("#hdnId").val(id);
    $("#txtUserName").val(userName);
    $("#txtPassword").val(password);
    $("#txtConfirmPassword").val(confirmPass);
    $("#txtFullname").val(fullname);
    $("#ddlKartu").val(kartuId);
    $("#txtEmail").val(email);
    $("#ddlRole").val(roleId);

    if (id == '') {
        $("#chkIsLogin").prop("checked", false)
        $("#chkIsLogin").prop("disabled", true)
        $("#ddlIsActive").val('False');
        $("#title").html('Add User');
    }
    else {

        if (isLogin == 'True')
            $("#chkIsLogin").prop("checked", true);
        else
            $("#chkIsLogin").prop("checked", false);

        $("#chkIsLogin").prop("disabled", false)

        $("#ddlIsActive").val(isActive);
        $("#title").html('Edit User');
    }

    $("#modal-form-userdetail").modal('show');
}

function getReset() {

    window.location = '/Home/UserList/4_5';
}

function getClose() {

    $("#modal-form-userdetail").modal('hide');
}

