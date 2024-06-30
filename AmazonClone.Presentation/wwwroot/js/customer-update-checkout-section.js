function updateCheckoutSection() {
    $.ajax({
        url: '/Customer/Cart/GetUpdatedCheckoutSection',
        type: 'GET',
        success: function (response) {
            // Replace the checkout section with the updated content
            $('.checkout-section').replaceWith(response);

            // If the response is an empty cart message, handle that
            if ($('.checkout-section').length === 0) {
                location.reload(); // Reload page if no items are left
            }
        },
        error: function (xhr, status, error) {
            console.error("Failed to update the checkout section. Status:", status, "Error:", error);
        }
    });
}