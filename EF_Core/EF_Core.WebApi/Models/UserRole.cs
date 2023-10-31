namespace EF_Core.WebApi.Models
{
    public class UserRole
    {
        public int UserId { get; set; } 
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }  
    }
}
