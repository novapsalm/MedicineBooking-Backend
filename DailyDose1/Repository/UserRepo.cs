using DailyDose1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace DailyDose1.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly EmedicineContext _context;
        private readonly IConfiguration configuration;
        public UserRepo(EmedicineContext context, IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }
        public async Task<List<Users>> GetAllUsers()
        {
            List<Users> UserList = new List<Users>();
            try
            {
                UserList = await _context.Users.ToListAsync();
                return UserList;
            }
            catch (Exception ex)
            {
                return UserList;
            }
        }

        public async Task<List<Users>> GetUserById(int id)
        {
            List<Users> userById = new List<Users>();
            try
            {
                userById = await _context.Users.Where(x => x.Id == id).ToListAsync();
                return userById;
            }
            catch (Exception ex)
            {
                return userById;
            }
        }

        public async Task<Users> PostUser(Users user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string Login(string email, string password)
        {
            var userExist = _context.Users.FirstOrDefault(t => t.Email == email && t.Password== password);
            if (userExist != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]

              {

                  new Claim("Email",userExist.Email),

                  new Claim("firstName",userExist.FirstName.ToString()),

                  new Claim("Role",userExist.Type)

};

                var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);

            }
            return null;
        }
       /* private bool UserExit(Users users)
        {
            return _context.Users.Any(t => t.Email == users.Email);
        }*/
    }
}
