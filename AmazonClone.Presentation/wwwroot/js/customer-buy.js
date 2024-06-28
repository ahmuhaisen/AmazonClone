$(document).ready(function () {
    $('#buy-button').click(function (e) {
        e.preventDefault();


        var productId = $(this).data('productid');

        $.ajax({
            url: '/Customer/Cart/AddToCart',
            type: 'POST',
            data: { productId: productId },
            success: function (response) {


                window.location.href = '/Customer/Cart/Index';
                
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    title: "Error!",
                    text: "An error occurred while adding the product to the cart.",
                    icon: "error"
                });
            }
        });
    });
});
