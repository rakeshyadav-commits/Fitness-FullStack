using FitnessAPI.DTOs;

namespace FitnessAPI.Interfaces
{
    public interface ICalorieService
    {
        Task<string> AddAsync(CalorieDTO dto);

        Task<List<object>> GetAllAsync();

        Task<List<object>> GetByUserAsync(int userId);
    }
}