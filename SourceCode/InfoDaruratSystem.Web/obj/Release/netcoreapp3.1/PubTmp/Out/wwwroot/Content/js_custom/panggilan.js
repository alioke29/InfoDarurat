
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

    var levelId = $("#ddlLevel").val();
    var nama = $("#txtNama").val();
    var spec = $("#txtSpec").val();
    var noPanggilan = $("#txtNoPanggilan").val();

    if (levelId == '') $("#ddlLevel").css("border", "1px solid red")
    else $("#ddlLevel").css("border", "");

    if (nama == '') $("#txtNama").css("border", "1px solid red")
    else $("#txtNama").css("border", "");

    if (spec == '') $("#txtSpec").css("border", "1px solid red")
    else $("#txtSpec").css("border", "");

    if (noPanggilan == '') $("#txtNoPanggilan").css("border", "1px solid red")
    else $("#txtNoPanggilan").css("border", "");

}

function getSave() {

    var id = $("#hdnId").val();

    var levelId = $("#ddlLevel").val();
    var nama = $("#txtNama").val();
    var spec = $("#txtSpec").val();
    var noPanggilan = $("#txtNoPanggilan").val();

    var paramAll = levelId + '~' + nama + '~' + spec + '~' + noPanggilan;

    $("#mask").show();

    var panggilanId = '';
    if (id != null)
        panggilanId = id;
    

    $.ajax({
        url: '/Panggilan/AddEditPanggilan/?id=' + panggilanId,
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

            if (json.error == 'Edit') {

                swal({
                    title: "Save success!",
                    text: "Editp panggilan has been saved.",
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
                    text: "Add panggilan has been saved.",
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


function getDelete(id) {

    swal({
        title: "Konfirmasi",
        text: "Apakah anda yakin ingin menghapus panggilan ini ?",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "NO",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "YES",
        closeOnConfirm: false
    }, function () {

        $("#mask").show();

        $.ajax({
            url: '/Panggilan/DeletePanggilan/?id=' + id,
            type: 'GET',
            dataType: 'json',
            cache: false,
            success: function (json) {

                $("#mask").hide();

                if (json.error == '0') {

                    swal({
                        title: "Deleted!",
                        text: "Selected panggilan has been deleted.",
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

    var nama = $("#txtNamaFilter").val();

    $("#mask").show();

    window.location = '/Home/PanggilanList/?id=14_16&isFilter=true&nama=' + nama;

}
 
function getView(id, levelId, nama, spec, noPanggilan, isDelete) {

    $("#ddlLevel").css("border", "");
    $("#txtNama").css("border", "");
    $("#txtSpec").css("border", "");
    $("#txtNoPanggilan").css("border", "");

    $("#ddlLevel").prop("disabled", "");
    $("#txtNama").prop("disabled", "");
    $("#txtSpec").prop("disabled", "");
    $("#txtNoPanggilan").prop("disabled", "");
    
    $("#hdnId").val(id);
    $("#ddlLevel").val(levelId);
    $("#txtNama").val(nama);
    $("#txtSpec").val(spec);
    $("#txtNoPanggilan").val(noPanggilan);

    if (id == '') {
        $("#title").html('Add Panggilan');

        $(".btnSave").css("display", "");      
        $(".btnDelete").css("display", "none");       
    }
    else {

        if (isDelete == 'true') {
            $("#title").html('Delete Panggilan');

            $("#ddlLevel").prop("disabled", "true");
            $("#txtNama").prop("disabled", "true");
            $("#txtSpec").prop("disabled", "true");
            $("#txtNoPanggilan").prop("disabled", "true");

            $(".btnSave").css("display", "none");
            $(".btnDelete").css("display", "");      
        }
        else {
            $("#title").html('Edit Panggilan');

            $(".btnSave").css("display", "");
            $(".btnDelete").css("display", "none");          
        }
    }    

    $("#modal-form-panggilandetail").modal('show');
}

function getReset() {

    window.location = '/Home/PanggilanList/14_16';
}

function getClose() {

    $("#modal-form-panggilandetail").modal('hide');
}

