using EF_Core.WebApi.Common;
using EF_Core.WebApi.Data;
using EF_Core.WebApi.Models;
using EF_Core.WebApi.Utilities;
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
        private readonly ILogger<UserController> logger;
        public UserController(ILogger<UserController> logger) { this.logger = logger; }

        [HttpGet]
        public async ValueTask<User> GetUserAsync()
        {
            this.logger.LogInformation("test");
            return await db.Users.FirstOrDefaultAsync();
        }
            

        [HttpPost]
        public async ValueTask<ApiResult<User>> PostUserAsync(CreateUserViewModel user)
        {
            ApiResponse<User> apiResponse = new ApiResponse<User>();
            try
            {
                EntityEntry<User> addedUser =
                    await db.Users.AddAsync(new Models.User
                    {
                        Name = user.Name,
                        Email = user.Email,
                    });

                await db.SaveChangesAsync();

                apiResponse.Data = addedUser.Entity;
                apiResponse.Success = true;

                return addedUser.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
