$(document).ready(function () {
    var classes = [];

    $('ul').children().each(function (index, el) {
        if ($(el).attr('class')) {
            classes.push($(el).attr('class'));
        }
    });

    $(classes).each(function(index, el) {
        $('#classes').append('<option value="' + el + '">' + el + '</option>');
    });

    $('button').on('click', function () {
        var className = '.' + $("#classes").val();
        var color = $('#color').val();
        $(className).css('background', color);
    });
});