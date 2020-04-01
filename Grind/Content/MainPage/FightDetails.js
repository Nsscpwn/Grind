var uri = 'api/lupta';

$(document).ready(function () {
    // Send an AJAX request
    $.getJSON(uri)
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>'{ text: formatItem(item) }).appendTo($('#fightdet'));
            });
        });
});

function formatItem(item) {
    return item.textMessage;
}
