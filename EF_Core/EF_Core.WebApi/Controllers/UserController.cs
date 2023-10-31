using EF_Core.WebApi.Data;
using EF_Core.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EF_Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        EF_CoreContext db = new EF_CoreContext();   

        public UserController() { }

        [HttpPost]
        public async ValueTask<User> PostUserAsync(User user)
        {
            try
            {
                EntityEntry<User> addedUser =
                    await db.Users.AddAsync(user);

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
