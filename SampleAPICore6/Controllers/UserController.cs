using Microsoft.AspNetCore.Mvc;
using SampleAPICore6.Interfaces;
using SampleAPICore6.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleAPICore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUser _iuser;

        public UserController(IUser iuser)
        {
            _iuser = iuser;
        }



        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
             var result = await _iuser.GetAll();
            if (result.isok)
            {
                return Ok(result.user);
            }
            return BadRequest();
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetName()
        {
            var result = await _iuser.GetAll();

            var users = from myuser in result.user
                        select new
                        {
                            Id = myuser.Id,
                            Name = myuser.Name
                        };

            if (result.isok)
            {
                return Ok(users);
            }
            return BadRequest();
        }



        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
             user.Role = "Admin";
            var result = await _iuser.AddUser(user);
            if (result.isok)
            {
                return StatusCode(StatusCodes.Status200OK);
            }

            return BadRequest();

        }

 

  
    }
}
