using EF_Core.WebApi.Data;
using EF_Core.WebApi.Models;
using EF_Core.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EF_Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        EF_CoreContext db = new EF_CoreContext();   

        public UserController() { }

        [HttpGet]
        public async ValueTask<User> GetUserAsync() =>
            await db.Users.FirstOrDefaultAsync();

        [HttpPost]
        public async ValueTask<User> PostUserAsync(CreateUserViewModel user)
        {
            try
            {
                EntityEntry<User> addedUser =
                    await db.Users.AddAsync(new Models.User
                    {
                        Name = user.Name,   
                        Email = user.Email,
                    });

                await db.SaveChangesAsync();

                return addedUser.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }
    }
}
