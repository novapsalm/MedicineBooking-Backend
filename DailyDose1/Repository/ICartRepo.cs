using DailyDose1.Models;

namespace DailyDose1.Repository
{
    public interface ICartRepo
    {
        public Task<object> GetAllCart();
        public Task<Cart> PostCart(Cart med);
        public Task<object> GetCartById(int id);
        public void DeleteCartById(int id);
    }
}
