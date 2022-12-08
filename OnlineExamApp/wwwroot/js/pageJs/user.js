$(".btnSil").click(function () {
    var id = $(this).data('id');
    Swal.fire({
        title: 'Silmek istediğinizden emin misiniz?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet',
        cancelButtonText: 'Hayır'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: '/User/Delete/' + id,
                type: 'GET',
                enctype: 'multipart/form-data',
                data: { id: id },
                processData: false,
                contentType: false,
                cache: false,
                timeout: 600000,
                success: function (result) {
                    if (result) {
                        Swal.fire(
                            'Silindi!',
                            'Kayıt başarıyla silindi.',
                            'success'
                        )
                        setTimeout(function () {
                            location.reload();
                        }, 2000);
                    }
                }
            });
        }
    })
});

function AddUser() {
    $.ajax({
        url: '/User/Add',
        type: 'POST',
        data: {
            name: $("#Name").val(),
            surname: $("#Surname").val(),
            mail: $("#Mail").val(),
            password: $("#Password").val(),
            userType: $("#userType option:selected").val(),
            examId: parseInt($("#ExamId option:selected").val())
        },
        async: false,
        timeout: 600000,
        dataType: "json",
        success: function (result) {
            if (result.isSuccess) {
                Swal.fire(
                    'Kullanıcı Ekleme',
                    result.message,
                    'success'
                )
                setTimeout(function () {
                    window.location.href = "/User/List";
                }, 2000);
            }
            else {
                Swal.fire(
                    'Kullanıcı Ekleme',
                    result.message,
                    'danger'
                )
            }
        }
    })
}

function UpdateUser() {
    $.ajax({
        url: '/User/Update',
        type: 'POST',
        data: {
            id: parseInt($("#Id").val()),
            name: $("#Name").val(),
            surname: $("#Surname").val(),
            mail: $("#Mail").val(),
            password: $("#Password").val(),
            link: $("#Link").val(),
            userType: $("#userType option:selected").val(),
            examId: parseInt($("#ExamId option:selected").val())
        },
        async: false,
        timeout: 600000,
        dataType: "json",
        success: function (result) {
            if (result.isSuccess) {
                Swal.fire(
                    'Kullanıcı Güncelleme',
                    result.message,
                    'success'
                )
                setTimeout(function () {
                    window.location.href = "/User/List";
                }, 2000);
            }
            else {
                Swal.fire(
                    'Kullanıcı Güncelleme',
                    result.message,
                    'danger'
                )
            }
        }
    })
}