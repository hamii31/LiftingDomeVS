namespace LiftingDome.Web.ViewModels.User
{
    public class AllUsersViewModel
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int PostCount { get; set; }
    }
}
