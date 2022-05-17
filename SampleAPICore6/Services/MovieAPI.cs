using Microsoft.EntityFrameworkCore;
using SampleAPICore6.Data;
using SampleAPICore6.Interfaces;
using SampleAPICore6.Model;

namespace SampleAPICore6.Services
{
    public class MovieAPI : IMovie
    {

        DbContextCinema _DbContext;

        public MovieAPI(DbContextCinema dbcontext)
        {
            _DbContext = dbcontext;
        }
 

        public async Task<(bool isok, string msg)> AddNew(Movies movie)
        {
            if (movie != null)
            {
                var movies = await _DbContext.Movie.AddAsync(movie);
                await _DbContext.SaveChangesAsync();
                return (true, null);

            }
            return (false, "No Data");
     
        }

        public async Task<(bool isok, string msg)> Del(int id)
        {
            var movie = await _DbContext.Movie.FindAsync(id);
            if (movie != null)
            {
                _DbContext.Movie.Remove(movie);
                await _DbContext.SaveChangesAsync();

                return(true, null);
            }

            return (false, "No Data");

        }

        public async Task<(bool isok, List<Movies> movie, string msg)> GetAll()
        {
            var movies = await _DbContext.Movie.ToListAsync();
            if (movies != null)

            {
                return (true, movies, null);
            }

            return (false, null, "No Data");
        }


 

        public async Task<(bool isok, Movies movie, string msg)> GetById(int id)
        {
            var movies = await _DbContext.Movie.FindAsync(id);
            if (movies != null)
            {
                return (true,movies, null);
            }
            return (false, null, "No Data");

        }

 

        public async Task<(bool isok, string msg)> Update(Movies movie, int id)
        {
            var movies = await _DbContext.Movie.FindAsync(id);
            if (movies != null)
            {
                movies.Name = movie.Name;
                movies.Rating = movie.Rating;
                movies.ImageUrl = movie.ImageUrl;

                await _DbContext.SaveChangesAsync();

                return (true, null);
            }

            return (false, "No Data");
        }
    }
}
