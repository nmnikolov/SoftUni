$(function () {
    $('.tweet-add-form').submit(function () {
        if ($(this).valid()) {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (prepend === true) {
                        $(".tweets").prepend(result);
                        $('.total-tweets').html(parseInt($('.total-tweets').html(), 10) + 1);
                    }

                    $('.tweet-add').val('');
                }
            });
        }
        return false;
    });
});