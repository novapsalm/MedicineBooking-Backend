using DailyDose1.Models;
using DailyDose1.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DailyDose1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepository;
        public UserController(IUserRepo userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<FirstController>
        [HttpGet]
        public async Task<ActionResult> GetUser()
        {
            List<Users> userList = new List<Users>();
            try
            {
                userList = await _userRepository.GetAllUsers();
                return Ok(userList);

            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // POST api/<FirstController>
        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] Users value)
        {
            try
            {
                Users users = await _userRepository.PostUser(value);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        // GET api/<FirstController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var res = await _userRepository.GetUserById(id);
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost("Login")]
        public string Login(string email, string password)
        {
            var result= _userRepository.Login(email, password);
            if (result != null)
                return result;
            return null;
        }
    }
}
