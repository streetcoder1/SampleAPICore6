namespace SampleAPICore6.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public int? Qty { get; set; }
        public int Price { get; set; }

        public int MoviesId { get; set; }
        public int UserId { get; set; }

    }
}
