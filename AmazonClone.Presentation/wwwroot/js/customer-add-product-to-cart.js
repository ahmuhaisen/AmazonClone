$(document).ready(function () {
    $('#cart-button').click(function (e) {
        e.preventDefault(); // Prevent default action

        var productId = $(this).data('productid');

        $.ajax({
            url: '/Customer/Cart/AddToCart',
            type: 'POST',
            data: { productId: productId },
            success: function (response) {
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
                Swal.fire({
                    title: "Error!",
                    text: "An error occurred while adding the product to the wishlist.",
                    icon: "error"
                });
            }
        });
    });
});