using DailyDose1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DailyDose1.Repository
{
    public class MedRepo : IMedRepo
    {
        private readonly EmedicineContext _context;
        public MedRepo(EmedicineContext context)
        {
            _context = context;
        }
      
        public async Task<List<Medicine>> GetAllMedicine()
        {
            List<Medicine> Medlist = new List<Medicine>();
            try
            {
                Medlist = await _context.Medicines.ToListAsync();
                return Medlist;
            }
            catch (Exception ex)
            {
                return Medlist;
            }
        }

        public async Task<List<Medicine>> GetMedicineByName(string name)
        {
            List<Medicine> medicineByname=new List<Medicine>();
            try
            {
                medicineByname= await _context.Medicines.Where(x => x.Name == name).ToListAsync();
                return medicineByname;
            }
            catch(Exception ex)
            {
                return medicineByname;
            }
        }

        public async Task<Medicine> PostMedicine(Medicine med)
        {
            try
            {
                await _context.Medicines.AddAsync(med);
                _context.SaveChanges();
                return med;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void UpdateMedicine(int id, Medicine med)
        {
            _context.Database.EnsureCreated();
            Medicine medicine =new Medicine();
            medicine = _context.Medicines.Where(r => r.Id == id).FirstOrDefault();
            if(medicine.Name != med.Name) 
            {
                medicine.Name = med.Name;
            }
            if(medicine.Descriptions!=med.Descriptions)
            {
                medicine.Descriptions = med.Descriptions;
            }
            if (medicine.Manufacturer != med.Manufacturer)
            {
                medicine.Manufacturer = med.Manufacturer;
            }
            if (medicine.ExpDate != med.ExpDate)
            {
                medicine.ExpDate = med.ExpDate;
            }
            if (medicine.UnitPrice != med.UnitPrice)
            {
                medicine.UnitPrice = med.UnitPrice;
            }
            if (medicine.Quantity != med.Quantity)
            {
                medicine.Quantity = med.Quantity;
            }
            _context.SaveChanges();
        }
        public void DeleteMedicineById(int id)
        {
            try
            {
                _context.Database.EnsureCreated();
                _context.Medicines.Where(x => x.Id == id).ExecuteDelete();
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
