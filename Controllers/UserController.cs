using AirApi.Database.Interface;
using AirApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataContext _data;

        public UserController(IDataContext data)
        {
            _data = data;
        }

        [HttpPost]
        [Authorize(Policy = "BasicAuthentication")]
        public ActionResult Post(User user)
        {
            _data.AddUser(user);
            return Ok("User posted");
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "BasicAuthentication", Roles = "admin")]
        public ActionResult Delete(int id)
        {
            _data.DeleteUser(id);
            return Ok("User deleted");
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_data.GetUsers());
        }

        [HttpGet("Search")]
        public ActionResult<IEnumerable<User>> GetByWordInTitle(string word)
        {
            return Ok(_data.GetUsersByWord(word));
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetByID(int id)
        {
            User temp = _data.GetUserById(id);
            if (temp == null) return NotFound("Id not found");
            return Ok(temp);
        }
    }
}
