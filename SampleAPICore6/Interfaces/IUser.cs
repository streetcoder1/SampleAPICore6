using SampleAPICore6.Model;

namespace SampleAPICore6.Interfaces
{
    public interface IUser
    {
        Task<(bool isok, string Msg)> AddUser(User user);
        Task<(bool isok, List<User> user, string Msg)> GetAll();
    }
}
