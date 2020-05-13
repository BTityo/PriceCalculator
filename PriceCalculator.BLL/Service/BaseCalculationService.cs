using PriceCalculator.DAL.Context;
using PriceCalculator.DAL.Models;
using PriceCalculator.DAL.Repository;
using PriceCalculator.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceCalculator.BLL.Service
{
    public class BaseCalculationService
    {
        private IBaseCalculationRepo<BaseCalculation> baseCalculationRepo;

        public BaseCalculationService(string connectionString)
        {
            this.baseCalculationRepo = new BaseCalculationRepo(new PriceCalculatorDbContext(connectionString));
        }

        public BaseCalculationService(IBaseCalculationRepo<BaseCalculation> baseCalculationRepo)
        {
            this.baseCalculationRepo = baseCalculationRepo;
        }

        /// <summary>
        /// Get all BaseCalculation-s async
        /// </summary>
        /// <returns>Task<List<BaseCalculation>></returns>
        public async Task<List<BaseCalculation>> GetBaseCalculationsAsync()
        {
            return await baseCalculationRepo.GetAllAsync();
        }

        /// <summary>
        /// Get BaseCalculation by Id async
        /// </summary>
        /// <param name="baseCalculationId"></param>
        /// <returns>Task<BaseCalculation></returns>
        public async Task<BaseCalculation> GetBaseCalculationByIdAsync(int baseCalculationId)
        {
            return await baseCalculationRepo.GetByIdAsync(baseCalculationId);
        }

        /// <summary>
        /// Get BaseCalculation by Name async
        /// </summary>
        /// <param name="baseCalculationName"></param>
        /// <returns>Task<BaseCalculation></returns>
        public async Task<BaseCalculation> GetBaseCalculationByNameAsync(string baseCalculationName)
        {
            return await baseCalculationRepo.GetByNameAsync(baseCalculationName);
        }

        /// <summary>
        /// Insert BaseCalculation to database async
        /// </summary>
        /// <param name="baseCalculation"></param>
        /// <returns>Task<BaseCalculation></returns>
        public async Task<BaseCalculation> InsertBaseCalculationAsync(BaseCalculation baseCalculation)
        {
            return await baseCalculationRepo.InsertAsync(baseCalculation);
        }

        /// <summary>
        /// Update BaseCalculation in database async
        /// </summary>
        /// <param name="baseCalculation"></param>
        /// <returns>Task<BaseCalculation></returns>
        public async Task<BaseCalculation> UpdateBaseCalculationAsync(BaseCalculation baseCalculation)
        {
            baseCalculation.LastChangeDate = DateTime.Now;
            return await baseCalculationRepo.UpdateAsync(baseCalculation);
        }

        /// <summary>
        /// Delete BaseCalculation by id async
        /// </summary>
        /// <param name="baseCalculationId"></param>
        /// <returns>Task<bool></returns>
        public async Task<bool> DeleteBaseCalculationByIdAsync(int baseCalculationId)
        {
            return await baseCalculationRepo.DeleteByIdAsync(baseCalculationId);
        }
    }
}
