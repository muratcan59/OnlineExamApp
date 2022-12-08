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
                url: '/Exam/Delete/' + id,
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