using PriceCalculator.DAL.Context;
using PriceCalculator.DAL.Models;
using PriceCalculator.DAL.Repository.IRepository;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculator.DAL.Repository
{
    public class BaseCalculationRepo : BaseRepo<BaseCalculation>, IBaseCalculationRepo<BaseCalculation>
    {
        private readonly PriceCalculatorDbContext context;

        public BaseCalculationRepo(PriceCalculatorDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<BaseCalculation> GetByNameAsync(string baseCalculationName)
        {
            return await Task.FromResult(context.Set<BaseCalculation>().FirstOrDefault(b => b.Name == baseCalculationName));
        }
    }
}
