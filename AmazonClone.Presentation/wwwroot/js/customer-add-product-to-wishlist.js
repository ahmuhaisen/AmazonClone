$(document).ready(function () {
    $('#wishlist-button').click(function (e) {
        e.preventDefault();

        var productId = $(this).data('productid');

        $.ajax({
            url: '/Customer/Wishlist/AddToWishlist',
            type: 'POST',
            data: { productId: productId },
            success: function (response) {
                if (response.success) {

                    let wishlistSizeBadge = document.querySelector(".wishlist-size");
                    let currentDisplayedSize = +wishlistSizeBadge.innerText;
                    wishlistSizeBadge.innerText = currentDisplayedSize + 1;

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