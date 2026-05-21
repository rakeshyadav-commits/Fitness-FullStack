using FitnessAPI.Data;
using FitnessAPI.DTOs;
using FitnessAPI.Interfaces;
using FitnessAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessAPI.Services
{
    public class BMIService : IBMIService
    {
        private readonly FitnessDBContext _context;

        public BMIService(FitnessDBContext context)
        {
            _context = context;
        }

        public async Task<string> AddBMIAsync(BMIRecordDTO dto)
        {
            decimal heightInMeter = dto.Height / 100;

            decimal bmi =
                dto.Weight /
                (heightInMeter * heightInMeter);

            string status = "";

            if (bmi < 18.5m)
            {
                status = "Underweight";
            }
            else if (bmi < 25)
            {
                status = "Normal";
            }
            else if (bmi < 30)
            {
                status = "Overweight";
            }
            else
            {
                status = "Obese";
            }

            BMIRecord bmiRecord = new BMIRecord()
            {
                BMIRecordId =
                    _context.BMIRecords.Any()
                    ? _context.BMIRecords.Max(x => x.BMIRecordId) + 1
                    : 1,

                UserId = dto.UserId,

                Height = dto.Height,

                Weight = dto.Weight,

                BMIValue = Math.Round(bmi, 2),

                BMIStatus = status,

                CreatedDate = DateTime.Now
            };

            await _context.BMIRecords.AddAsync(bmiRecord);

            await _context.SaveChangesAsync();

            return "BMI Record Added Successfully";
        }

        public async Task<List<object>> GetAllBMIAsync()
        {
            return await _context.BMIRecords
                .Select(x => new
                {
                    x.BMIRecordId,
                    x.Height,
                    x.Weight,
                    x.BMIValue,
                    x.BMIStatus,
                    x.CreatedDate
                })
                .Cast<object>()
                .ToListAsync();
        }
        public async Task<string> UpdateBMIAsync(
    int id,
    BMIRecordDTO dto)
        {
            var record =
                await _context.BMIRecords
                .FindAsync(id);

            if (record == null)
            {
                return "BMI Record Not Found";
            }

            decimal heightInMeter =
                dto.Height / 100;

            decimal bmi =
                dto.Weight /
                (heightInMeter * heightInMeter);

            string status = "";

            if (bmi < 18.5m)
            {
                status = "Underweight";
            }
            else if (bmi < 25)
            {
                status = "Normal";
            }
            else if (bmi < 30)
            {
                status = "Overweight";
            }
            else
            {
                status = "Obese";
            }

            record.Height = dto.Height;

            record.Weight = dto.Weight;

            record.BMIValue =
                Math.Round(bmi, 2);

            record.BMIStatus = status;

            await _context.SaveChangesAsync();

            return "BMI Updated Successfully";
        }
    }
}