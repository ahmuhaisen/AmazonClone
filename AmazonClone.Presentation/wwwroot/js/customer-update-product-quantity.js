$(document).ready(function () {
    $(document).on('change', '.quantity-input', function () {

        var $input = $(this);
        var productId = $input.data('productid');
        var newQuantity = $input.val();

        if (newQuantity < 1 || newQuantity > 100) {
            Swal.fire({
                title: "Invalid Quantity",
                text: "Please enter a quantity between 1 and 100.",
                icon: "warning"
            });

            $input.val($input.data('previousValue') || 1);
            return;
        }

        $input.data('previousValue', newQuantity);

        $.ajax({
            url: '/Customer/Cart/UpdateProductQuantity',
            type: 'PUT',
            data: {
                productId: productId,
                newQuantity: newQuantity
            },
            success: function (response) {
                if (response.success) {

                   
                    updateCheckoutSection();
                


                } else {
                    Swal.fire({
                        title: "Error!",
                        text: response.message || "An error occurred while updating the quantity.",
                        icon: "error"
                    });
                }
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    title: "Error!",
                    text: "An error occurred while updating the quantity.",
                    icon: "error"
                });
            }
        });
    });

    $('.quantity-input').each(function () {
        $(this).data('previousValue', $(this).val());
    });
});
