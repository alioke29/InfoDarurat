
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

    var jenisKartu = $("#ddlJenisKartu").val();
    var noKartu = $("#txtNoKartu").val();
    var namaPetugas = $("#txtNamaPetugas").val();

    if (jenisKartu == '') $("#ddlJenisKartu").css("border", "1px solid red")
    else $("#ddlJenisKartu").css("border", "");

    if (noKartu == '') $("#txtNoKartu").css("border", "1px solid red")
    else $("#txtNoKartu").css("border", "");

    if (namaPetugas == '') $("#txtNamaPetugas").css("border", "1px solid red")
    else $("#txtNamaPetugas").css("border", "");

}

function getSave() {

    var id = $("#hdnId").val();

    var jenisKartu = $("#ddlJenisKartu").val();
    var noKartu = $("#txtNoKartu").val();
    var namaPetugas = $("#txtNamaPetugas").val();
    var status = $("#ddlStatus").val();

    var paramAll = jenisKartu + '~' + noKartu + '~' + namaPetugas + '~' + status;

    $("#mask").show();

    var kartuId = '';
    if (id != null)
        kartuId = id;
    

    $.ajax({
        url: '/Kartu/AddEditKartu/?id=' + kartuId,
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
                    text: "No. Kartu has already exist.",
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
                    text: "Edit kartu has been saved.",
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
                    text: "Add kartu has been saved.",
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
        text: "Apakah anda yakin ingin menghapus kartu ini ?",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "NO",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "YES",
        closeOnConfirm: false
    }, function () {

        $("#mask").show();

        $.ajax({
            url: '/Kartu/DeleteKartu/?id=' + id,
            type: 'GET',
            dataType: 'json',
            cache: false,
            success: function (json) {
                
                $("#mask").hide();

                if (json.error == '0') {

                    swal({
                        title: "Deleted!",
                        text: "Selected kartu has been deleted.",
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

    var noKartu = $("#txtNoKartuFilter").val();

    $("#mask").show();

    window.location = '/Home/KartuList/?id=9_10&isFilter=true&noKartu=' + noKartu;

}
 
function getView(id, jenisKartu, noKartu, namaPetugas, status) {

    $("#ddlJenisKartu").css("border", "");
    $("#txtNoKartu").css("border", "");
    $("#txtNamaPetugas").css("border", "");
    
    $("#hdnId").val(id);
    $("#ddlJenisKartu").val(jenisKartu);
    $("#txtNoKartu").val(noKartu);
    $("#txtNamaPetugas").val(namaPetugas);
    $("#ddlStatus").val(status);

    if (id == '') {
        $("#title").html('Add Kartu');
    }
    else {
        $("#title").html('Edit Kartu');
    }

    $("#modal-form-kartudetail").modal('show');
}

function getReset() {

    window.location = '/Home/KartuList/9_10';
}

function getClose() {

    $("#modal-form-kartudetail").modal('hide');
}




