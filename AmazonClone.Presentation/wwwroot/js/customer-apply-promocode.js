$('#promocode-button').on('click', function () {

    var promocode = $('.promocode-input').val();

    if (!promocode) {
        Swal.fire({
            title: "Error!",
            text: "Please enter a promocode.",
            icon: "error"
        });
        return;
    }

    $.ajax({
        url: '/Customer/Cart/ApplyPromocode',
        type: 'POST',
        data: { promocode: promocode },
        success: function (response) {
            if (response.success) {
                Swal.fire({
                    title: "Success!",
                    text: response.message,
                    icon: "success"
                });

                $('.promocode-input').prop('disabled', true);
                $('#promocode-button').prop('disabled', true);

                updateCheckoutSection();

            } else {
                Swal.fire({
                    title: "Error!",
                    text: response.message || "Invalid promocode.",
                    icon: "error"
                });
            }
        },
        error: function (xhr, status, error) {
            console.error("Failed to apply promocode. Status:", status, "Error:", error);
            Swal.fire({
                title: "Error!",
                text: "An error occurred while applying the promocode.",
                icon: "error"
            });
        }
    });
});