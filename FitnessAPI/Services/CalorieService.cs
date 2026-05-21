using FitnessAPI.Data;
using FitnessAPI.DTOs;
using FitnessAPI.Interfaces;
using FitnessAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessAPI.Services
{
    public class CalorieService : ICalorieService
    {
        private readonly FitnessDBContext _context;

        public CalorieService(FitnessDBContext context)
        {
            _context = context;
        }

        public async Task<string> AddAsync(CalorieDTO dto)
        {
            CalorieTracker entity = new CalorieTracker()
            {
                CalorieId =
                    _context.CalorieTracker.Any()
                    ? _context.CalorieTracker.Max(x => x.CalorieId) + 1
                    : 1,

                UserId = dto.UserId,
                FoodName = dto.FoodName,
                MealType = dto.MealType,
                Calories = dto.Calories,
                Quantity = dto.Quantity,
                CreatedDate = DateTime.Now
            };

            await _context.CalorieTracker.AddAsync(entity);
            await _context.SaveChangesAsync();

            return "Calorie Added Successfully";
        }

        public async Task<List<object>> GetAllAsync()
        {
            return await _context.CalorieTracker
                .Select(x => new
                {
                    x.CalorieId,
                    x.FoodName,
                    x.MealType,
                    x.Calories,
                    x.Quantity,
                    x.CreatedDate
                })
                .Cast<object>()
                .ToListAsync();
        }

        public async Task<List<object>> GetByUserAsync(int userId)
        {
            return await _context.CalorieTracker
                .Where(x => x.UserId == userId)
                .Select(x => new
                {
                    x.FoodName,
                    x.MealType,
                    x.Calories,
                    x.Quantity
                })
                .Cast<object>()
                .ToListAsync();
        }
    }
}