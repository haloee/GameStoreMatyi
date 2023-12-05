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
    public class VideoGameController : ControllerBase
    {
        //// GET: api/<VideoGameController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<VideoGameController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<VideoGameController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<VideoGameController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<VideoGameController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
       
       
       
            private GameStoreContext _gameStoreContext;

            public VideoGameController(GameStoreContext GameStoreContext)
            {
                _gameStoreContext = GameStoreContext;
            }

            [HttpGet]
            public async Task<IActionResult> GetVideoGames()
            {
                return Ok(await _gameStoreContext.VideoGames.ToListAsync());
            }

            [HttpPost]
            public async Task<IActionResult> CreateVideoGame(VideoGame game)
            {
                await _gameStoreContext.VideoGames.AddAsync(game);
                await _gameStoreContext.SaveChangesAsync();
                return Ok(new { message = "Game created" });
            }

            [HttpGet]
            [Route("{id:int}")]
            public async Task<IActionResult> GetVideoGame([FromRoute] int id)
            {
                var game = await _gameStoreContext.VideoGames.FindAsync(id);
                if (game == null)
                {
                    return NotFound();
                }
                return Ok(game);
            }

            [HttpPut]
            [Route("{id:int}")]
            public async Task<IActionResult> UpdateVideoGame([FromRoute] int id, VideoGame game)
            {
                var newGame = await _gameStoreContext.VideoGames.FindAsync(id);
                if (newGame != null)
                {
                    newGame.Title = game.Title;
                    newGame.Description = game.Description;
                    newGame.Type = game.Type;
                    newGame.Price = game.Price;
                    newGame.Rating = game.Rating;
                    await _gameStoreContext.SaveChangesAsync();
                    return Ok(newGame);
                }
                return NotFound();
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<IActionResult> DeleteVideoGame(int id)
            {
                var game = await _gameStoreContext.VideoGames.FindAsync(id);
                if (game != null)
                {
                    _gameStoreContext.Remove(game);
                    _gameStoreContext.SaveChanges();
                    return Ok(game);
                }
                return NotFound();
            }
        }
}
