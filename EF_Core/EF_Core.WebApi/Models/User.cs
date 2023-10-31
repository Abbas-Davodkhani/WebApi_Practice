namespace EF_Core.WebApi.Models
{
    public class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
