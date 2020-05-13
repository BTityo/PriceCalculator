using PriceCalculator.DAL.Context;
using PriceCalculator.DAL.Models;
using PriceCalculator.DAL.Repository;
using PriceCalculator.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceCalculator.BLL.Service
{
    public class CalculationService
    {
        private ICalculationRepo<Calculation> calculationRepo;

        public CalculationService(string connectionString)
        {
            this.calculationRepo = new CalculationRepo(new PriceCalculatorDbContext(connectionString));
        }

        public CalculationService(ICalculationRepo<Calculation> calculationRepo)
        {
            this.calculationRepo = calculationRepo;
        }

        /// <summary>
        /// Get all Calculation-s async
        /// </summary>
        /// <returns>Task<List<Calculation>></returns>
        public async Task<List<Calculation>> GetCalculationsAsync()
        {
            return await calculationRepo.GetAllAsync();
        }

        /// <summary>
        /// Get Calculation by Id async
        /// </summary>
        /// <param name="calculationId"></param>
        /// <returns>Task<Calculation></returns>
        public async Task<Calculation> GetCalculationByIdAsync(int calculationId)
        {
            return await calculationRepo.GetByIdAsync(calculationId);
        }

        /// <summary>
        /// Insert Calculation to database async
        /// </summary>
        /// <param name="calculation"></param>
        /// <returns>Task<Calculation></returns>
        public async Task<Calculation> InsertCalculationAsync(Calculation calculation)
        {
            return await calculationRepo.InsertAsync(calculation);
        }

        /// <summary>
        /// Insert Calculations to database async
        /// </summary>
        /// <param name="calculations"></param>
        /// <returns>Task<Calculation></returns>
        public async Task<List<Calculation>> InsertCalculationsAsync(List<Calculation> calculations, BaseCalculation baseCalculation)
        {
            List<Calculation> insertedCalculations = new List<Calculation>();
            foreach (Calculation calculation in calculations)
            {
                calculation.BaseCalculationId = baseCalculation.Id;
                insertedCalculations.Add(await calculationRepo.InsertAsync(calculation));
            }

            return insertedCalculations;
        }

        /// <summary>
        /// Update Calculation in database async
        /// </summary>
        /// <param name="calculation"></param>
        /// <returns>Task<Calculation></returns>
        public async Task<Calculation> UpdateCalculationAsync(Calculation calculation)
        {
            calculation.LastChangeDate = DateTime.Now;
            return await calculationRepo.UpdateAsync(calculation);
        }

        /// <summary>
        /// Delete Calculation by id async
        /// </summary>
        /// <param name="calculationId"></param>
        /// <returns>Task<bool></returns>
        public async Task<bool> DeleteCalculationByIdAsync(int calculationId)
        {
            return await calculationRepo.DeleteByIdAsync(calculationId);
        }

        /// <summary>
        /// Delete Calculations by baseCalculationId async
        /// </summary>
        /// <param name="baseCalculationId"></param>
        /// <returns>Task<bool></returns>
        public async Task<bool> DeleteCalculationsByBaseCalculationIdAsync(int baseCalculationId)
        {
            return await calculationRepo.DeleteCalculationsByBaseCalculationIdAsync(baseCalculationId);
        }

        /// <summary>
        /// Get Calculations by baseCalculationId async
        /// </summary>
        /// <param name="baseCalculationId"></param>
        /// <returns>Task<List<Calculation>></returns>
        public async Task<List<Calculation>> GetCalculationsByBaseCalculationIdAsync(int baseCalculationId)
        {
            return await calculationRepo.GetCalculationsByBaseCalculationIdAsync(baseCalculationId);
        }
    }
}
