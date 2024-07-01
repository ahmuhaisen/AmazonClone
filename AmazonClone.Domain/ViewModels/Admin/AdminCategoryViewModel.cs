using System.ComponentModel.DataAnnotations;

namespace AmazonClone.Domain.ViewModels.Admin;

public class AdminCategoryViewModel
{
    public int Id { get; set; }

    [MinLength(4)]
    public string Name { get; set; }

    public string IconString { get; set; }

    public bool HasSize { get; set; }

}
