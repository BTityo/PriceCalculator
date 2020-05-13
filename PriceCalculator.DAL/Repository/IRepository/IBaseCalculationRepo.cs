using PriceCalculator.DAL.Models;
using System.Threading.Tasks;

namespace PriceCalculator.DAL.Repository.IRepository
{
    public interface IBaseCalculationRepo<T> : IBaseRepo<T> where T : class
    {
        Task<BaseCalculation> GetByNameAsync(string baseCalculationName);
    }
}
