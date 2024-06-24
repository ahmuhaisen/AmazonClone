using System.ComponentModel.DataAnnotations;

namespace AmazonClone.Domain.ViewModels.Admin
{
    public class AdminRoleFormViewModel
    {
        [Required, StringLength(256)]
        public string? Name { get; set; }
    }
}
