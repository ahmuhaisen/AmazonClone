
$(document).ready(function () {
    $('select').select2();

    let wishlistSizeBadge = document.querySelector(".wishlist-size");

    if (wishlistSizeBadge != null) {
        //we are in a customer page
        //[1] Get the wishlist size by thee api
        //[2] Update the wishlistSizeBadge innerText if the result > 0
        $.ajax({
            url: '/Customer/Wishlist/GetWishlistSize',
            type: 'GET',
            success: (response) => {
                console.log("AJAX call to /Customer/Wishlist/GetWishlistSize successful. Response:", response);
                if (+response.size > 0) {
                    wishlistSizeBadge.innerText = response.size;
                }
            }
        });
    }
});