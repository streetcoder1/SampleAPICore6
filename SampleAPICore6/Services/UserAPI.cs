using Microsoft.EntityFrameworkCore;
using SampleAPICore6.Data;
using SampleAPICore6.Interfaces;
using SampleAPICore6.Model;

namespace SampleAPICore6.Services
{
    public class UserAPI : IUser
    {
        DbContextCinema _DbContext;

        public UserAPI(DbContextCinema dbcontext)
        {
            _DbContext = dbcontext;
        }


        public async Task<(bool isok, string Msg)> AddUser(User user)
        {

            if (user != null)
            {

              // user.Role = "Admin";

                var MyUser = await _DbContext.Users.AddAsync(user);
                
                await _DbContext.SaveChangesAsync();
                return(true,null);
            }

            return (false,"No Data");
            

        }

        public async Task<(bool isok, List<User> user, string Msg)> GetAll()
        {
            var MyUser = await _DbContext.Users.ToListAsync();
            if (MyUser != null)
            {
                return (true,MyUser,null);
            }
            return (false, null, "No Data");
        }
    }
}
