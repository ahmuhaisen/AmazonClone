
$(document).ready(function () {
    $('#page_effect').fadeIn(500);
});



$(document).ready(function () {
    console.log("Document is ready.");

    // Use event delegation to handle dynamically added elements
    $(document).on('click', '.wishlist-button', function (e) {
        e.preventDefault(); // Prevent default action

        var productId = $(this).data('productid');
        console.log("Wishlist button clicked. Product ID:", productId);

        $.ajax({
            url: '/Customer/Wishlist/AddToWishlist',
            type: 'POST',
            data: { productId: productId },
            success: function (response) {
                console.log("AJAX call successful. Response:", response);
                if (response.success) {
                    Swal.fire({
                        title: "Added!",
                        text: response.message,
                        icon: "success"
                    });
                } else {
                    Swal.fire({
                        title: "Oops!",
                        text: response.message,
                        icon: "info"
                    });
                }
            },
            error: function (xhr, status, error) {
                console.error("AJAX call failed. Status:", status, "Error:", error);
                Swal.fire({
                    title: "Error!",
                    text: "An error occurred while adding the product to the wishlist.",
                    icon: "error"
                });
            }
        });
    });
});
