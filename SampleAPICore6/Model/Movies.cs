using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleAPICore6.Model
{
    public class Movies
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Rating { get; set; }


        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }



        public ICollection<Reservation>? Reservations { get; set; }



    }
}
