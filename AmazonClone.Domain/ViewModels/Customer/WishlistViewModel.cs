using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClone.Domain.ViewModels.Customer
{
    public class WishlistViewModel
    {
        public IEnumerable<CustomerHomeProductViewModel> Products { get; set; } = Enumerable.Empty<CustomerHomeProductViewModel>();
    }
}
