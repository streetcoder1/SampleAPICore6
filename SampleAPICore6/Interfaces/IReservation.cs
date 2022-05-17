

using SampleAPICore6.Model;

namespace SampleAPICore6.Interfaces
{
    public interface IReservation
    {

        Task<(bool isok, string Msg)> AddReservation(Reservation reservation);
        Task<(bool isok, string Msg)> RemoveReservation(int Id);
        Task<(bool isok,List<Reservation> reservation, string Msg)> GetAllReservation();

        Task<(bool isok, List<Reservation> reservation, string Msg)> GetSelectedReservation();

        Task<(bool isok, Reservation reservation, string Msg)> GetByIdReservation(int id);
        Task<(bool isok, string Msg)> UpdateReservationId(Reservation reservation, int Id);
 
    }
}
