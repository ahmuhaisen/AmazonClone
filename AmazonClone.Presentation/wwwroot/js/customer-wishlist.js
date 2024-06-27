﻿
$(document).ready(function () {
    console.log("Document is ready.");

    $('.wishlist-button i').each(function () {
        $(this).replaceWith('<i class="bi bi-heart-fill"></i>');
    });

    $(document).on('click', '.wishlist-button', function (e) {
        e.preventDefault();

        var productId = $(this).data('productid');
        console.log("Wishlist button clicked. Product ID:", productId);

        var $button = $(this);

        $.ajax({
            url: '/Customer/Wishlist/RemoveFromWishlist',
            type: 'POST',
            data: { productId: productId },
            success: function (response) {
                console.log("AJAX call successful. Response:", response);
                if (response.success) {
                    //Swal.fire({
                    //    title: "Removed!",
                    //    text: response.message,
                    //    icon: "success"
                    //});

                    // Remove the parent .product-home-list-item
                    $button.closest('.product-home-list-item').fadeOut(250, function () {
                        $(this).remove();
                    });


                } else {
                    Swal.fire({
                        title: "Error!",
                        text: response.message,
                        icon: "error"
                    });
                }
            },
            error: function (xhr, status, error) {
                console.error("AJAX call failed. Status:", status, "Error:", error);
                Swal.fire({
                    title: "Error!",
                    text: "An error occurred while removing the product from the wishlist.",
                    icon: "error"
                });
            }
        });
    });
});

