using PriceCalculator.DAL.Context;
using PriceCalculator.DAL.Models;
using PriceCalculator.DAL.Repository;
using PriceCalculator.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceCalculator.BLL.Service
{
    public class ThicknessService
    {
        private IBaseRepo<Thickness> thicknessRepo;

        public ThicknessService(string connectionString)
        {
            this.thicknessRepo = new BaseRepo<Thickness>(new PriceCalculatorDbContext(connectionString));
        }

        public ThicknessService(IBaseRepo<Thickness> thicknessRepo)
        {
            this.thicknessRepo = thicknessRepo;
        }

        /// <summary>
        /// Get all Thickness-s async
        /// </summary>
        /// <returns>Task<List<Thickness>></returns>
        public async Task<List<Thickness>> GetThicknessesAsync()
        {
            return await thicknessRepo.GetAllAsync();
        }

        /// <summary>
        /// Get Thickness by Id async
        /// </summary>
        /// <param name="thicknessId"></param>
        /// <returns>Task<Thickness></returns>
        public async Task<Thickness> GetThicknessByIdAsync(int thicknessId)
        {
            return await thicknessRepo.GetByIdAsync(thicknessId);
        }

        /// <summary>
        /// Insert Thickness to database async
        /// </summary>
        /// <param name="thickness"></param>
        /// <returns>Task<Thickness></returns>
        public async Task<Thickness> InsertThicknessAsync(Thickness thickness)
        {
            return await thicknessRepo.InsertAsync(thickness);
        }

        /// <summary>
        /// Update Thickness in database async
        /// </summary>
        /// <param name="thickness"></param>
        /// <returns>Task<Thickness></returns>
        public async Task<Thickness> UpdateThicknessAsync(Thickness thickness)
        {
            thickness.LastChangeDate = DateTime.Now;
            return await thicknessRepo.UpdateAsync(thickness);
        }

        /// <summary>
        /// Delete Thickness by id async
        /// </summary>
        /// <param name="thicknessId"></param>
        /// <returns>Task<bool></returns>
        public async Task<bool> DeleteThicknessByIdAsync(int thicknessId)
        {
            return await thicknessRepo.DeleteByIdAsync(thicknessId);
        }
    }
}
