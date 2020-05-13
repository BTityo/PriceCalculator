using Microsoft.EntityFrameworkCore;
using PriceCalculator.DAL.Context;
using PriceCalculator.DAL.Models;
using PriceCalculator.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator.DAL.Repository
{
    public class CalculationRepo : BaseRepo<Calculation>, ICalculationRepo<Calculation>
    {
        private readonly PriceCalculatorDbContext context;

        public CalculationRepo(PriceCalculatorDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteCalculationsByBaseCalculationIdAsync(int baseCalculationId)
        {
            bool isSuccessDelete = false;
            List<Calculation> calculations = await context.Set<Calculation>().Where(c => c.BaseCalculationId == baseCalculationId).ToListAsync();

            foreach (Calculation calculation in calculations)
            {
                context.Set<Calculation>().Remove(calculation);
                isSuccessDelete = true;
            }

            await SaveAsync();

            return isSuccessDelete;
        }

        public async Task<List<Calculation>> GetCalculationsByBaseCalculationIdAsync(int baseCalculationId)
        {
            return await context.Set<Calculation>().Where(c => c.BaseCalculationId == baseCalculationId).ToListAsync();
        }
    }
}
