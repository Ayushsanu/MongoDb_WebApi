using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDb_WebApi.Interfaces;

namespace MongoDb_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private  IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
            
        }
        [HttpGet(Name = "GetAllUsers")]
        public IActionResult Get()
        {
           var result= _userService.listUsers();
            return Ok(result);
        }
        
    }
}
