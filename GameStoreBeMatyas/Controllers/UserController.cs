using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using GameStoreBeMatyas.Context;
using GameStoreBeMatyas.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameStoreBeMatyas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //{
        //    // GET: api/<UserController>
        //    [HttpGet]
        //    public IEnumerable<string> Get()
        //    {
        //        return new string[] { "value1", "value2" };
        //    }

        //    // GET api/<UserController>/5
        //    [HttpGet("{id}")]
        //    public string Get(int id)
        //    {
        //        return "value";
        //    }

        //    // POST api/<UserController>
        //    [HttpPost]
        //    public void Post([FromBody] string value)
        //    {
        //    }

        //    // PUT api/<UserController>/5
        //    [HttpPut("{id}")]
        //    public void Put(int id, [FromBody] string value)
        //    {
        //    }

        //    // DELETE api/<UserController>/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //    }
        private GameStoreContext _gameStoreContext;

        public UserController(GameStoreContext GameStoreContext)
        {
            _gameStoreContext = GameStoreContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _gameStoreContext.Users.Include(a => a.VideoGames).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _gameStoreContext.Users.AddAsync(user);
            await _gameStoreContext.SaveChangesAsync();
            return Ok(new { message = "User created" });
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var user = await _gameStoreContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, User user)
        {
            var newUser = await _gameStoreContext.Users.FindAsync(id);
            if (newUser != null)
            {
                newUser.Email = user.Email;
                newUser.PasswordHash = user.PasswordHash;
                await _gameStoreContext.SaveChangesAsync();
                return Ok(newUser);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _gameStoreContext.Users.FindAsync(id);
            if (user != null)
            {
                _gameStoreContext.Remove(user);
                _gameStoreContext.SaveChanges();
                return Ok(user);
            }
            return NotFound();
        }
    }
}

