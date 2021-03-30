
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

    var panggilanId = $("#ddlPanggilan").val();

    if (panggilanId == '') $("#ddlPanggilan").css("border", "1px solid red")
    else $("#ddlPanggilan").css("border", "");
}

function getSave() {

    var id = $("#hdnId").val();
    var listDaftarAlat = $("#hdnDaftarAlat").val();
    var namaAlat = $("#hdnNamaAlat").val();

    var listNamaAlatSelected = String(namaAlat).split(',');
    var listNamaAlat = String(listDaftarAlat).split('~');


    var arrayNamaAlat = new Array(); // ColIndex = 0
    var countChecked = 0;

    $(".daftarAlatTable tbody tr").each(function () {

        namaAlat = $(this).find("td input[type=checkbox]:eq(0)").val();

        if ($(this).find("td input[type=checkbox]:eq(0)").is(":checked")) {

            countChecked++;
           
            arrayNamaAlat[countChecked] = namaAlat;
        }

    });

    arrayNamaAlat = removeElementsFromArray(arrayNamaAlat, isNullOrUndefined)

    var paramNamaAlat = arrayNamaAlat.join("~");


    var panggilanId = $("#ddlPanggilan").val();
    var paramAll = panggilanId;

    $("#mask").show();

    var persiapanAlatId = '';
    if (id != null)
        persiapanAlatId = id;
    

    $.ajax({
        url: '/PersiapanAlat/AddEditPersiapanAlat/?id=' + persiapanAlatId,
        method: 'POST',
        dataType: "json",
        data: {
            paramAll: paramAll,
            paramNamaAlat: paramNamaAlat
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
                    text: "Edit persiapan alat has been saved.",
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
                    text: "Add persiapan alat has been saved.",
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
        text: "Apakah anda yakin ingin menghapus persiapan alat ini ?",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "NO",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "YES",
        closeOnConfirm: false
    }, function () {

        $("#mask").show();

        $.ajax({
            url: '/PersiapanAlat/DeletePersiapanAlat/?id=' + id,
            type: 'GET',
            dataType: 'json',
            cache: false,
            success: function (json) {

                $("#mask").hide();

                if (json.error == '0') {

                    swal({
                        title: "Deleted!",
                        text: "Selected persiapan alat has been deleted.",
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

    var namaAlat = $("#txtNamaAlatFilter").val();

    $("#mask").show();

    window.location = '/Home/PersiapanAlatList/?id=14_17&isFilter=true&namaAlat=' + namaAlat;

}
 
function getView(id, panggilanId, namaAlat, listDaftarAlat) {

    $("#ddlPanggilan").css("border", "");
    $("#txtNamaAlat").css("border", "");
    
    $("#hdnId").val(id);
    $("#hdnDaftarAlat").val(listDaftarAlat);
    $("#hdnNamaAlat").val(namaAlat);

    $("#ddlPanggilan").val(panggilanId);
    $("#txtNamaAlat").val(namaAlat);

    var listNamaAlatSelected = String(namaAlat).split(',');
    var listNamaAlat = String(listDaftarAlat).split('~');

    var strChecked;

    if (id == '') {

        $(".daftarAlatTable tbody tr").each(function () {

            $(this).find("td input[type=checkbox]:eq(0)").prop("checked", false);

        });

        $("#title").html('Add Persiapan Alat');
    }
    else {

        $(".daftarAlatTable tbody tr").each(function () {

            var namaAlat = $(this).find("td input[type=checkbox]:eq(0)").val();

            for (var y = 0; y < listNamaAlatSelected.length; y++) {

                if (String(namaAlat).trim() == String(listNamaAlatSelected[y]).trim()) {
                    strChecked = true;
                    break;
                }
                else
                    strChecked = false;
            }

            $(this).find("td input[type=checkbox]:eq(0)").prop("checked", strChecked);

        });

        $("#title").html('Edit Persiapan Alat');
    } 

    $("#modal-form-persiapanalatdetail").modal('show');
}

function getViewDaftarAlat() {

    $("#modal-form-daftaralatdetail").modal('show');
}

function getSaveDaftarAlat() {

    var namaAlat = $("#txtNamaAlatDaftarAlat").val();

    var paramAll = namaAlat;

    $.ajax({
        url: '/PersiapanAlat/AddDaftarAlat/',
        method: 'POST',
        dataType: "json",
        data: {
            paramAll: paramAll
        },
        cache: false,
        success: function (json) {

            $("#mask").hide();

            if (json.error == '1') {

                swal({
                    title: "Confirmation",
                    text: "Nama Peralatan is required.",
                    type: "warning",
                    timer: 3000
                },
                    function () {
                        return;
                    });
            }  
            else if (json.error == '2') {

                swal({
                    title: "Confirmation",
                    text: "Nama Peralatan has already exist.",
                    type: "warning",
                    timer: 3000
                },
                    function () {
                        return;
                    });
            }  

            if (json.error == '0') {

                swal({
                    title: "Save success!",
                    text: "Add daftar alat has been saved.",
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

function getReset() {

    window.location = '/Home/PersiapanAlatList/14_17';
}

function getClose() {

    $("#modal-form-persiapanalatdetail").modal('hide');
}

