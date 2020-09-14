$(document).ready(function () {
    $('.datepicker').datepicker({
        format: 'dd.mm.yyyy',
    });
    $(".selectpicker").selectpicker();

    //searchbox lardan girilen tuşları yakalayıp backend e sorgualama için gönderiyoruz, dönen cevapla select içlerini dolduruyoruz.
    $("input[type='search']").keyup(function () {

        var combox = $(this);
        var comboId = combox.parent().parent().parent().children('select').attr('id');
        var val = combox.val();

        $.ajax({
            url: "home/buslocations",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ text: val }),
            success: function (data) {
                var html = '';
                for (var i = 0; i < data.length; i++) {
                    html += '<option value=' + data[i].id + '>' + data[i].name + '</option>';
                }

                $("#" + comboId).html(html);
                $("#" + comboId).selectpicker('refresh');
            }
        });

    });
});

//parametre geçilen değeri bugünün üstüne gün olarak ekleyip datepicker a set eder.
function SetDateAfterToDay(value) {
    var toDay = new Date();
    var newDate = AddDays(toDay, value);

    $('.datepicker').datepicker('update', newDate);
}

//parametre geçilen tarih ve gün sayısını ekleyip geri döndürür
function AddDays(date, days) {
    var result = new Date(date);
    result.setDate(result.getDate() + days);
    return result;
}

//kalkış ve varış seçimlerini yer değiştirir
function SwapLocations() {
    var originValue = $('#OriginId').val();
    var destinationValue = $('#DestinationId').val();

    $('#OriginId').selectpicker('val', destinationValue);
    $('#DestinationId').selectpicker('val', originValue);
}