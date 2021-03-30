
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

    var kartuId = $("#ddlKartu").val();
    var jamMasuk = $("#txtJamMasuk").val();
    var jamKeluar = $("#txtJamKeluar").val();

    if (kartuId == '') $("#ddlKartu").css("border", "1px solid red")
    else $("#ddlKartu").css("border", "");

    if (jamMasuk == '') $("#txtJamMasuk").css("border", "1px solid red")
    else $("#txtJamMasuk").css("border", "");

    if (jamKeluar == '') $("#txtJamKeluar").css("border", "1px solid red")
    else $("#txtJamKeluar").css("border", "");
}

function getSave() {

    var id = $("#hdnId").val();

    var kartuId = $("#ddlKartu").val();
    var jamMasuk = $("#txtJamMasuk").val();
    var jamKeluar = $("#txtJamKeluar").val();

    var paramAll = kartuId + '~' + jamMasuk + '~' + jamKeluar;

    $("#mask").show();

    var aktivitasId = '';
    if (id != null)
        aktivitasId = id;
    

    $.ajax({
        url: '/Aktivitas/AddEditAktivitas/?id=' + aktivitasId,
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
                    text: "Edit aktivitas has been saved.",
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
                    text: "Add aktivitas has been saved.",
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
        text: "Apakah anda yakin ingin menghapus aktivitas ini ?",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "NO",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "YES",
        closeOnConfirm: false
    }, function () {

        $("#mask").show();

        $.ajax({
            url: '/Aktivitas/DeleteAktivitas/?id=' + id,
            type: 'GET',
            dataType: 'json',
            cache: false,
            success: function (json) {
                

                $("#mask").hide();

                if (json.error == '0') {

                    swal({
                        title: "Deleted!",
                        text: "Selected aktivitas has been deleted.",
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

    var jamMasuk = $("#txtJamMasukFilter").val();

    $("#mask").show();

    window.location = '/Home/AktivitasList/?id=9_11&isFilter=true&jamMasuk=' + jamMasuk;

}
 
function getView(id, kartuId, jamMasuk, jamKeluar) {

    $("#ddlKartu").css("border", "");
    $("#txtJamMasuk").css("border", "");
    $("#txtJamKeluar").css("border", "");
    
    $("#hdnId").val(id);
    $("#ddlKartu").val(kartuId);
    $("#txtJamMasuk").val(jamMasuk);
    $("#txtJamKeluar").val(jamKeluar);

    if (id == '') {
        $("#title").html('Add Aktivitas');
    }
    else {
        $("#title").html('Edit Aktivitas');
    }

    $("#modal-form-aktivitasdetail").modal('show');
}

function getReset() {

    window.location = '/Home/AktivitasList/9_11';
}

function getClose() {

    $("#modal-form-aktivitasdetail").modal('hide');
}

