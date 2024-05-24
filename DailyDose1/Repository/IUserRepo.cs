using DailyDose1.Models;

namespace DailyDose1.Repository
{
    public interface IUserRepo
    {
        public Task<List<Users>> GetAllUsers();
        public Task<Users> PostUser(Users med);
        public Task<List<Users>> GetUserById(int id);
        string Login(string username, string password);
        //private bool UserExit(Users users);
    }
}
