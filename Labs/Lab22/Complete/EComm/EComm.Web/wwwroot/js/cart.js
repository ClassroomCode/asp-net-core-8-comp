$(document).ready(function () {
    $('form').submit(function (event) {
        var formData = {
            'quantity': $('input[name=quantity]').val()
        };
        $.ajax({
            type: 'POST',
            url: $('#addToCartForm').attr('action'),
            data: formData
        })
            .done(function (response) {
                $('#message').html(response);
            });
        event.preventDefault();
    });
});
