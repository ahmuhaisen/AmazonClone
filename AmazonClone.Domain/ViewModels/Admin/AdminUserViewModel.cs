namespace AmazonClone.Domain.ViewModels.Admin
{
    public class AdminUserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
