using SampleAPICore6.Model;

namespace SampleAPICore6.Interfaces
{
    public interface IMovie
    {
        Task<(bool isok, Movies movie, string msg)> GetById(int id);
        Task<(bool isok, List<Movies> movie, string msg)> GetAll();
        Task<(bool isok, string msg)> Del(int id);
        Task<(bool isok, string msg)> AddNew(Movies movie);
        Task<(bool isok, string msg)> Update(Movies movie, int id);


    }
}
