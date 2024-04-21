using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testing_Post_Man_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Testing_Post_Man_API.Controllers
{
    [Route("api/[demo]")]
    [ApiController]
    public class DemoApiController : ControllerBase
    {
        private readonly ApiDemoDbContext _apiDemoDbContext;
        public DemoApiController(ApiDemoDbContext apiDemoDbContext)
        {
            _apiDemoDbContext = apiDemoDbContext;
        }
        [HttpGet]
        [Route("get-ssers-list")]
        public async Task<IActionResult> GetAsync()
        {
            var users = await _apiDemoDbContext.users.ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<IActionResult> PostAsync(Users users)
        {
            _apiDemoDbContext.users.Add(users);
            await _apiDemoDbContext.SaveChangesAsync();
            return Created($"/get-user-by-id /{users.Id }",users);
        }
        [HttpPut]
        [Route("update-user")]
        public async Task<IActionResult> PutAsync(Users userToUpdate)
        {
            _apiDemoDbContext.users.Update(userToUpdate);
            await _apiDemoDbContext.SaveChangesAsync();
            return NoContent();
        }
        //
        [Route("{delete-user}/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var userToDelete = await _apiDemoDbContext.users.FindAsync(Id);
            if (userToDelete != null)
            {
                return NotFound();
            }
            _apiDemoDbContext.users.Remove(userToDelete);
            await _apiDemoDbContext.SaveChangesAsync();
            return NoContent();
        }


    }
}
