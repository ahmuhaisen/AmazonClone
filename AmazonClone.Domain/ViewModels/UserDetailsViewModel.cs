using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClone.Domain.ViewModels
{
    public class UserDetailsViewModel
    {
        public string FullName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
