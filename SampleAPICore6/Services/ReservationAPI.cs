using Microsoft.EntityFrameworkCore;
using SampleAPICore6.Data;
using SampleAPICore6.Interfaces;
using SampleAPICore6.Model;

namespace SampleAPICore6.Services
{

    public class ReservationAPI : IReservation
    {

        DbContextCinema _DbContext;

        public ReservationAPI(DbContextCinema dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<(bool isok, string Msg)> AddReservation(Reservation reservation)
        {
            if (reservation != null)
            {
                var reservations = await _DbContext.Reservations.AddAsync(reservation);
                await _DbContext.SaveChangesAsync();

                return (true, null);
            }

            return (false, "No Data");
        }

        public async Task<(bool isok, List<Reservation> reservation, string Msg)> GetAllReservation()
        {
            var reservations = await _DbContext.Reservations.ToListAsync();
            if (reservations != null)
            {
                return (true, reservations, null);
            }
            return (false, null, "No Data");
        }

        public async Task<(bool isok, Reservation reservation, string Msg)> GetByIdReservation(int id)
        {
          var reservations = await _DbContext.Reservations.FindAsync(id);
            if (reservations != null)
            {
                return (true,reservations, null);
            }
            return (false, null, "NO DATA");
        }

        public async Task<(bool isok, List<Reservation> reservation, string Msg)> GetSelectedReservation()
        {
            var reservations = await (from reservation in _DbContext.Reservations
                               join user in _DbContext.Users on reservation.UserId equals user.Id
                               join move in _DbContext.Movie on reservation.MoviesId equals move.Id
                               select new
                               {
                                   id = reservation.Id,
                                   reservationqty = reservation.Qty,
                                   customername = user.Name,
                                   moviename = move.Name
                               }).ToListAsync();

            if (reservations != null)
            {
                return (true, reservations, null);
            }
            return (false, null, "NO DATA");
        }

        public async Task<(bool isok, string Msg)> RemoveReservation(int Id)
        {
            var reservations = await _DbContext.Reservations.FindAsync(Id);

            if (reservations !=null)
            {
                _DbContext.Reservations.Remove(reservations);
                await _DbContext.SaveChangesAsync();
                return(true, null);
            }
            return (false, "No Data");
            
        }

        public async Task<(bool isok, string Msg)> UpdateReservationId(Reservation reservation, int Id)
        {
            var reservations = await _DbContext.Reservations.FindAsync(Id);
            if (reservations != null)
            {
                reservations.Price = reservation.Price;
                reservations.Qty = reservation.Qty;
                await _DbContext.SaveChangesAsync();

                return (true, null);
            }

            return (false, "NO dATA");
        }

 
 

  
    }
}
