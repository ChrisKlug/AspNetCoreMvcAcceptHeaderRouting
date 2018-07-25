using AcceptHeaderRoutingDemo.Web.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AcceptHeaderRoutingDemo.Web.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers _users;

        public UserController(IUsers users)
        {
            _users = users;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _users.All());
        }
    }
}
