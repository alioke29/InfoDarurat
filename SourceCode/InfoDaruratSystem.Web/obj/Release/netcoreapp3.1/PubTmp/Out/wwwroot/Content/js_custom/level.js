
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

    var levelName = $("#txtLevelName").val();
    var desc = $("#txtDesc").val();

    if (levelName == '') $("#txtLevelName").css("border", "1px solid red")
    else $("#txtLevelName").css("border", "");

    if (desc == '') $("#txtDesc").css("border", "1px solid red")
    else $("#txtDesc").css("border", "");
}

function getSave() {

    var id = $("#hdnId").val();

    var levelName = $("#txtLevelName").val();
    var desc = $("#txtDesc").val();

    var paramAll = levelName + '~' + desc;


    $("#mask").show();

    var levelId = '';
    if (id != null)
        levelId = id;
    else
        levelId = '';


    $.ajax({
        url: '/Level/AddEditLevel/?id=' + levelId,
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
                    text: "Level Name has already exist.",
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
                    text: "Edit Level has been saved.",
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
                    text: "Add Level has been saved.",
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

function getDelete(id, levelName) {

    swal({
        title: "Konfirmasi",
        text: "Apakah anda yakin ingin menghapus level ini ?",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "NO",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "YES",
        closeOnConfirm: false
    }, function () {

        $("#mask").show();

        $.ajax({
            url: '/Level/DeleteLevel/?id=' + id,
            type: 'GET',
            dataType: 'json',
            cache: false,
            success: function (json) {
                
                $("#mask").hide();

                if (json.error == '1') {

                    swal({
                        title: "Confirmation",
                        text: "Cannnot delete Level Name  = '" + levelName + "', this Level is being used.",
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
                        text: "Selected Level has been deleted.",
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

    var levelName = $("#txtLevelNameFilter").val();

    $("#mask").show();

    window.location = '/Home/LevelList/?id=14_15&isFilter=true&levelName=' + levelName;

}

function getView(id, levelName, desc) {

    $("#txtLevelName").css("border", "");
    $("#txtDesc").css("border", "");
    
    $("#hdnId").val(id);
    $("#txtLevelName").val(levelName);
    $("#txtDesc").val(desc);

    if (id == '') {
        $("#title").html('Add Level');
    }
    else {
        $("#title").html('Edit Level');
    }

    $("#modal-form-leveldetail").modal('show');
}

function getReset() {

    window.location = '/Home/LevelList/14_15';
}

function getClose() {

    $("#modal-form-leveldetail").modal('hide');
}

