namespace AmazonClone.Domain.ViewModels.Admin
{
    public class UserRolesViewModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }

        public List<AdminRoleVeiwModel> Roles { get; set; }
    }
}
