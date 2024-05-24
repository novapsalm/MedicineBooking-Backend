using DailyDose1.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyDose1.Repository
{
    public class CartRepo : ICartRepo
    {
        private readonly EmedicineContext _context;
        public CartRepo(EmedicineContext context)
        {
            _context = context;
        }
        public async Task<object> GetAllCart()
        {
            try
            {
               var res = await (from c in _context.Carts
                                  join m in _context.Medicines
                                  on c.MedicineId equals m.Id
                                  select new {c.Id,
                                  c.UserId,
                                  c.MedicineId,
                                  m.Name,
                                  c.UnitPrice,
                                  c.Quantity
                                  }).ToListAsync();

                                 
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<object> GetCartById(int id)
        {
            //List<Cart> CartById = new List<Cart>();
            try
            {
                //CartById = await _context.Carts.Where(x => x.UserId == id).ToListAsync();
                //return CartById;
                var res = await (from c in _context.Carts
                                 join m in _context.Medicines
                                 on c.MedicineId equals m.Id
                                 where c.UserId== id
                                 select new
                                 {
                                     c.Id,
                                     c.UserId,
                                     c.MedicineId,
                                     m.Name,
                                     c.UnitPrice,
                                     c.Quantity
                                 }).ToListAsync();


                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Cart> PostCart(Cart cart)
        {
            try
            {
                await _context.Carts.AddAsync(cart);
                _context.SaveChanges();
                return cart;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void DeleteCartById(int id)
        {
            try
            {
                _context.Database.EnsureCreated();
                _context.Carts.Where(x => x.UserId == id).ExecuteDelete();
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
