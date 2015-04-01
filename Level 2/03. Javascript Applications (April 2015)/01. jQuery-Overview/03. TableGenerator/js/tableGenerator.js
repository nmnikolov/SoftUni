$(document).ready(function () {
    $('#generator').click(function () {
        $("#cars").remove();

        if ($('#input').val() && $.parseJSON($('#input').val())) {
            var input = $.parseJSON($('#input').val());
            generateTable();

            function generateTable() {
                if (input.length) {
                    var table = $('<table id="cars"><thead><tr><th>Manufacturer</th><th>Model</th><th>Year</th><th>Price</th><th>Class</th></tr></thead><tbody></tbody></table>');
                    $(input).each(function (index, el) {
                        var row = '<tr><td>' +
                            el.manufacturer + '</td><td>' +
                            el.model + '</td><td>' +
                            el.year + '</td><td>' +
                            el.price + '</td><td>' +
                            el.class + '</td></tr>';

                        table.append($(row));
                    });

                    table.hide().appendTo($('#wrapper')).fadeIn(1500);
                }
            }
        }
    });
});