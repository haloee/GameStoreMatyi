using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStoreBeMatyas.Context;
using GameStoreBeMatyas.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameStoreBeMatyas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameUserController : ControllerBase
    {
        //// GET: api/<VideoGameUserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<VideoGameUserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<VideoGameUserController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<VideoGameUserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<VideoGameUserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        private GameStoreContext _gameStoreContext;

        public VideoGameUserController(GameStoreContext GameStoreContext)
        {
            _gameStoreContext = GameStoreContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetVideoGameUsers()
        {
            return Ok(await _gameStoreContext.VideoGameUsers.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideoGameUser(VideoGameUser gameUser)
        {
            await _gameStoreContext.VideoGameUsers.AddAsync(gameUser);
            await _gameStoreContext.SaveChangesAsync();
            return Ok(new { message = "Game User created" });
        }
    }
}
