using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zappor.Infrastructure.Persistence;

namespace Zappor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ZapporDbContext _context;
        
        public UsersController(ZapporDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
    }
}
