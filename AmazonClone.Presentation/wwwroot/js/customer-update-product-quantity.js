$(document).ready(function () {
    // Event listener for changes in quantity input
    $(document).on('change', '.quantity-input', function () {
        var $input = $(this);
        var productId = $input.data('productid');
        var newQuantity = $input.val();

        // Ensure the new quantity is within the valid range
        if (newQuantity < 1 || newQuantity > 100) {
            Swal.fire({
                title: "Invalid Quantity",
                text: "Please enter a quantity between 1 and 100.",
                icon: "warning"
            });
            // Reset to previous value or a default valid value
            $input.val($input.data('previousValue') || 1);
            return;
        }

        // Store the new quantity as the previous value for future validation
        $input.data('previousValue', newQuantity);

        $.ajax({
            url: '/Customer/Cart/UpdateProductQuantity',
            type: 'POST',
            data: {
                productId: productId,
                newQuantity: newQuantity
            },
            success: function (response) {
                if (response.success) {
                    
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

    // Store the initial value of the input for comparison
    $('.quantity-input').each(function () {
        $(this).data('previousValue', $(this).val());
    });
});
