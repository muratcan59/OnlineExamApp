function AddExam() {
    $.ajax({
        url: '/Exam/Add',
        type: 'POST',
        data: {
            name: $("#Name").val(),
            questionCount: parseInt($("#QuestionCount").val())
        },
        async: false,
        timeout: 600000,
        dataType: "json",
        success: function (result) {
            if (result.isSuccess) {
                Swal.fire(
                    'Sınav Ekleme',
                    result.message,
                    'success'
                )
                setTimeout(function () {
                    window.location.href = "/Exam/List";
                }, 2000);
            }
            else {
                Swal.fire(
                    'Sınav Ekleme',
                    result.message,
                    'danger'
                )
            }
        }
    })
}

function UpdateExam() {
    $.ajax({
        url: '/Exam/Update',
        type: 'POST',
        data: {
            id: parseInt($("#Id").val()),
            name: $("#Name").val(),
            questionCount: parseInt($("#QuestionCount").val())
        },
        timeout: 600000,
        success: function (result) {
            if (result.isSuccess) {
                Swal.fire(
                    'Sınav Güncelleme',
                    result.message,
                    'success'
                )
                setTimeout(function () {
                    window.location.href = "/Exam/List";
                }, 2000);
            }
            else {
                Swal.fire(
                    'Sınav Güncelleme',
                    result.message,
                    'danger'
                )
            }
        }
    })
}

function DeleteExam(id) {
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
                data: { id: id },
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

function FinishExam() {
    var score = 0;
    var ele = document.getElementsByClassName('options');

    for (var i = 0; i < ele.length; i++) {
        var correctAnswer = ele[i].children(i);
        var checkedData = ele[i].closest("radio").val();
        if (ele[i].checked && checkedData == correctAnswer) {
            score += 5;
        }
    }

    $.ajax({
        url: '/Exam/EnterExam',
        type: 'POST',
        data: {
            score: score
        },
        async: false,
        timeout: 600000,
        dataType: "json",
        success: function (result) {
            if (result.isSuccess) {
                Swal.fire(
                    'Sınav Tamamlama',
                    result.message,
                    'success'
                )
                setTimeout(function () {
                    window.location.href = "/Exam/List";
                }, 2000);
            }
            else {
                Swal.fire(
                    'Sınav Tamamlama',
                    result.message,
                    'danger'
                )
            }
        }
    })
}