function AddQuestion() {
    $.ajax({
        url: '/Question/Add',
        type: 'POST',
        data: {
            title: $("#Title").val(),
            content: $("#Content").val(),
            content: $("#Content").val(),
            answers: $("#Answers").val(),
            correctAnswer: $("#CorrectAnswer").val(),
            examId: parseInt($("#ExamId option:selected").val())
        },
        timeout: 600000,
        dataType: "json",
        success: function (result) {
            if (result.isSuccess) {
                Swal.fire(
                    'Soru Ekleme',
                    result.message,
                    'success'
                )
                setTimeout(function () {
                    window.location.href = "/Question/List";
                }, 2000);
            }
            else {
                Swal.fire(
                    'Soru Ekleme',
                    result.message,
                    'danger'
                )
            }
        }
    })
}

function UpdateQuestion() {
    $.ajax({
        url: '/Question/Update',
        type: 'POST',
        data: {
            id: parseInt($("#Id").val()),
            title: $("#Title").val(),
            content: $("#Content").val(),
            content: $("#Content").val(),
            answers: $("#Answers").val(),
            correctAnswer: $("#CorrectAnswer").val(),
            examId: parseInt($("#ExamId option:selected").val())
        },
        timeout: 600000,
        success: function (result) {
            if (result.isSuccess) {
                Swal.fire(
                    'Soru Güncelleme',
                    result.message,
                    'success'
                )
                setTimeout(function () {
                    window.location.href = "/Question/List";
                }, 2000);
            }
            else {
                Swal.fire(
                    'Soru Güncelleme',
                    result.message,
                    'danger'
                )
            }
        }
    })
}

function DeleteQuestion(id) {
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
                url: '/Question/Delete/' + id,
                type: 'GET',
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
}