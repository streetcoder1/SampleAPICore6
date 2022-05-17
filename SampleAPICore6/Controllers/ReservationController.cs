using Microsoft.AspNetCore.Mvc;
using SampleAPICore6.Data;
using SampleAPICore6.Interfaces;
using SampleAPICore6.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleAPICore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        DbContextCinema _DbContext;
        IReservation _ireservation;
 

        public ReservationController(IReservation ireservation, DbContextCinema dbContext)
        {
            _ireservation = ireservation;
            _DbContext = dbContext;
        }

        // GET: api/<ReservationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var respond = await _ireservation.GetAllReservation();

            if (respond.isok)
            {
                return Ok(respond.reservation);
            }
            return BadRequest();
        }


        [HttpGet("[action]")]
        public  IActionResult GetSelected()
        {

            var reservations = from reservation in _DbContext.Reservations
                               join user in _DbContext.Users on reservation.UserId equals user.Id
                               join move in _DbContext.Movie on reservation.MoviesId equals move.Id
                               select new
                               {
                                   id = reservation.Id,
                                   reservationqty = reservation.Qty,
                                   customername = user.Name,
                                   moviename = move.Name
                               };

            return Ok(reservations);
 
        }



        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var respond = await _ireservation.GetByIdReservation(id);
            if (respond.isok)
            {
                return Ok(respond.reservation);
            }
            return BadRequest();
        }

        // POST api/<ReservationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reservation reservation)
        {
            var respond = await _ireservation.AddReservation(reservation);
            if (respond.isok)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Reservation reservation)
        {
            var respond = await _ireservation.UpdateReservationId(reservation, id);
            if (respond.isok)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return NotFound();
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var respoind = await _ireservation.RemoveReservation(id);   
            if (respoind.isok)
            {
                return Ok("Deleted");
            }
            return BadRequest();
        }
    }
}
