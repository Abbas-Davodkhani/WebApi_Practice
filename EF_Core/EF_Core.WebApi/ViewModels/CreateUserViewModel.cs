using System.ComponentModel.DataAnnotations;

namespace EF_Core.WebApi.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
