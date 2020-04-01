var uri = 'api/mesaj';
$(document).ready(function () {
    // Send an AJAX request
    $.getJSON(uri)
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $({ text: item }).appendTo($('#fightdet'));
            });
        });
});

