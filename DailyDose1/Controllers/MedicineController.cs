using DailyDose1.Models;
using DailyDose1.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DailyDose1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedRepo _medRepository;
        public MedicineController(IMedRepo medRepository)
        {
            _medRepository = medRepository;
        }

        // GET: api/<FirstController>
        [HttpGet]
        public async Task<ActionResult> GetMedicine()
        {
            List<Medicine> medicinesList = new List<Medicine>();
            try
            {
                medicinesList = await _medRepository.GetAllMedicine();
                return Ok(medicinesList);

            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // POST api/<FirstController>
        [HttpPost]
        public async Task<ActionResult> PostMedicine([FromBody] Medicine value)
        {
            try
            {
                Medicine medicine = await _medRepository.PostMedicine(value);
                if (medicine == null)
                {
                    return NotFound();
                }
                return Ok(medicine);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        // GET api/<FirstController>/5
        [HttpGet("{name}")]
        public async Task<ActionResult> Get(string name)
        {
            try
            {
                var res = await _medRepository.GetMedicineByName(name);
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



        // PUT api/<FirstController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Medicine value)
        {
            List<Medicine> medicines = new List<Medicine>();
            try
            {
                _medRepository.UpdateMedicine(id, value);
                medicines = await _medRepository.GetAllMedicine();
                return Ok(medicines);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // DELETE api/<FirstController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _medRepository.DeleteMedicineById(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
