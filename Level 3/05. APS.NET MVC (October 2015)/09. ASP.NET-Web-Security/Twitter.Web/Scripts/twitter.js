$(function () {
    $(document).ready(function () {
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

        $(document).on('click', '.follow', function (e) {
            var that = $(this);

            $.ajax({
                method: "POST",
                url: "/Users/FollowUser",
                data: { userId: e.target.id },
                success: function (message) {
                    that.text('Unfollow');
                    that.removeClass('follow');
                    that.addClass('unfollow');
                    that.removeClass('btn-sucess');
                    that.addClass('btn-danger');

                    $.ajax({
                        method: "POST",
                        url: "/Notifications/AddNotification",
                        data: { userId: that.attr('id'), message: message },
                        success: function () {
                            var notificationsHub = $.connection.notifications;
                            $.connection.hub.start();
                            notificationsHub.server.sendNotification(that.attr('id'));
                        }
                    });
                }
            });
        });

        $(document).on('click', '.unfollow', function (e) {
            var that = $(this);

            $.ajax({
                method: "POST",
                url: "/Users/UnfollowUser",
                data: { userId: e.target.id },
                success: function (message) {
                    that.text('Follow');
                    that.removeClass('unfollow');
                    that.addClass('follow');
                    that.removeClass('btn-danger');
                    that.addClass('btn-success');
                }
            });
        });
    });
});