using DailyDose1.Models;

namespace DailyDose1.Repository
{
    public interface IMedRepo
    {
        public Task<List<Medicine>> GetAllMedicine();
        public Task<Medicine> PostMedicine(Medicine med);
        public Task<List<Medicine>> GetMedicineByName(string name);
        public void UpdateMedicine(int id, Medicine med);
        public void DeleteMedicineById(int id);

    }
}
