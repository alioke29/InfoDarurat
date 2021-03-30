
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


window.onload = function () {

}

function getMessageValidationBorder() {

    var roleName = $("#txtRoleName").val();
    var desc = $("#txtDesc").val();

    if (roleName == '') $("#txtRoleName").css("border", "1px solid red")
    else $("#txtRoleName").css("border", "");

    if (desc == '') $("#txtDesc").css("border", "1px solid red")
    else $("#txtDesc").css("border", "");
}

function getSave() {

    var id = $("#hdnId").val();

    var roleName = $("#txtRoleName").val();
    var desc = $("#txtDesc").val();

    var paramAll = roleName + '~' + desc;


    $("#mask").show();

    var roleId = '';
    if (id != null)
        roleId = id;
    else
        roleId = '';


    $.ajax({
        url: '/Role/AddEditRole/?id=' + roleId,
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
                    text: "Role Name has already exist.",
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
                    text: "Edit role has been saved.",
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
                    text: "Add role has been saved.",
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

function getDelete(id, roleName) {

    swal({
        title: "Konfirmasi",
        text: "Apakah anda yakin ingin menghapus role ini ?",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "NO",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "YES",
        closeOnConfirm: false
    }, function () {

        $("#mask").show();

        $.ajax({
            url: '/Role/DeleteRole/?id=' + id,
            type: 'GET',
            dataType: 'json',
            cache: false,
            success: function (json) {
                
                $("#mask").hide();

                if (json.error == '1') {

                    swal({
                        title: "Confirmation",
                        text: "Cannnot delete Role Name  = '" + roleName + "', this role is being used.",
                        type: "warning",
                        timer: 3000
                    },
                        function () {
                            return;
                        });
                }
                else if (json.error == '0') {

                    swal({
                        title: "Deleted!",
                        text: "Selected role has been deleted.",
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

    var roleName = $("#txtRoleNameFilter").val();

    $("#mask").show();

    window.location = '/Home/RoleList/?id=4_6&isFilter=true&roleName=' + roleName;

}

function getView(id, roleName, desc) {

    $("#txtRoleName").css("border", "");
    $("#txtDesc").css("border", "");
    
    $("#hdnId").val(id);
    $("#txtRoleName").val(roleName);
    $("#txtDesc").val(desc);

    if (id == '') {
        $("#title").html('Add Role');
    }
    else {
        $("#title").html('Edit Role');
    }

    $("#modal-form-roledetail").modal('show');
}

function getReset() {

    window.location = '/Home/RoleList/4_6';
}

function getClose() {

    $("#modal-form-roledetail").modal('hide');
}

