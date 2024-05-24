using DailyDose1.Models;
using DailyDose1.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DailyDose1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepo _cartRepository;
        public CartController(ICartRepo cartRepository)
        {
            _cartRepository = cartRepository;
        }

        // GET: api/<FirstController>
        [HttpGet]
        
        public async Task<ActionResult> GetCart()
        {
            
            try
            {
                var cartList = await _cartRepository.GetAllCart();
                return Ok(cartList);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // POST api/<FirstController>
        [HttpPost]
        public async Task<ActionResult> PostCart([FromBody] Cart value)
        {
            try
            {
                Cart cart = await _cartRepository.PostCart(value);
                if (cart == null)
                {
                    return NotFound();
                }
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        // GET api/<FirstController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var res = await _cartRepository.GetCartById(id);
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch
            {
                return NotFound();
            }
        }
        // DELETE api/<FirstController>/5
        [HttpDelete("{Userid}")]
        public void Delete(int Userid)
        {
            try
            {
                _cartRepository.DeleteCartById(Userid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //[HttpDelete("{id}")]
        //public void DeleteSingle(int id)
        //{
        //    try
        //    {
        //        _cartRepository.DeleteCartById(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
