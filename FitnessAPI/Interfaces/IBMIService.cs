using FitnessAPI.DTOs;

namespace FitnessAPI.Interfaces
{
    public interface IBMIService
    {
        Task<string> AddBMIAsync(BMIRecordDTO dto);

        Task<List<object>> GetAllBMIAsync();
        Task<string> UpdateBMIAsync(
         int id,
         BMIRecordDTO dto);
    }
}