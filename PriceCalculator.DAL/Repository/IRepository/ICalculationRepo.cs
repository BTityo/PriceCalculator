using PriceCalculator.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceCalculator.DAL.Repository.IRepository
{
    public interface ICalculationRepo<T> : IBaseRepo<T> where T : class
    {
        Task<bool> DeleteCalculationsByBaseCalculationIdAsync(int baseCalculationId);
        Task<List<Calculation>> GetCalculationsByBaseCalculationIdAsync(int baseCalculationId);
    }
}
