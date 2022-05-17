using Microsoft.AspNetCore.Mvc;
using SampleAPICore6.Interfaces;
using SampleAPICore6.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleAPICore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        IMovie _Imovie;

        public MovieController(IMovie imovie)
        {
            _Imovie = imovie;
        }


        // GET: api/<MovieController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _Imovie.GetAll();
            if (result.isok)
            {
                return Ok(result.movie);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOnlyName()
        {

            var result = await _Imovie.GetAll();

            var OnlyName = from myMovies in result.movie
                           select new
                           {
                               Id = myMovies.Id,
                               Name = myMovies.Name
                           };


            if (result.isok)
            {
                return Ok(OnlyName);
            }
            return BadRequest();
        }


        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           var result = await _Imovie.GetById(id);
            if (result.isok)
            {
                return Ok(result.movie);
            }
            return NotFound();

        }

        // POST api/<MovieController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Movies movie)
        {
            var result = await _Imovie.AddNew(movie);
            if (result.isok)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Movies movie)
        {
            var result = await _Imovie.Update(movie, id);

            if (result.isok)
            {
                return StatusCode(StatusCodes.Status200OK);
            }

            return BadRequest();
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _Imovie.Del(id);
            if (result.isok)
            {
                return Ok("Deleted");
            }
            return BadRequest();
        }
    }
}
