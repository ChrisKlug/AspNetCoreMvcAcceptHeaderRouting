using AcceptHeaderRoutingDemo.Web.Data;
using AcceptHeaderRoutingDemo.Web.Models;
using AcceptHeaderRoutingDemo.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{id:int}")]
        public IActionResult GetUserByIdDefault(int id)
        {
            return StatusCode(406, "Invalid Accept header");
        }

        [HttpGet("{id:int}")]
        [AcceptHeader(UserModel.ContentType)]
        public async Task<IActionResult> GetUserById(int id)
        {
            return await GetUserById(id, UserModel.Create);
        }

        [HttpGet("{id:int}")]
        [AcceptHeader(UserModelV2.ContentType)]
        public async Task<IActionResult> GetUserByIdV2(int id)
        {
            return await GetUserById(id, UserModelV2.Create);
        }

        [HttpGet("{id:int}")]
        [AcceptHeader(ExtendedUserModel.ContentType)]
        public async Task<IActionResult> GetExtendedUserById(int id)
        {
            return await GetUserById(id, ExtendedUserModel.Create);
        }

        private async Task<IActionResult> GetUserById<T>(int id, Func<User, T> formatter)
        {
            var user = await _users.WhereIdIs(id);
            if (user != null)
                return Ok(formatter(user));
            return NotFound();
        }
    }
}
