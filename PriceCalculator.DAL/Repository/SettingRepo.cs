using Microsoft.EntityFrameworkCore;
using PriceCalculator.DAL.Context;
using PriceCalculator.DAL.Models;
using PriceCalculator.DAL.Repository.IRepository;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculator.DAL.Repository
{
    public class SettingRepo : BaseRepo<Setting>, ISettingRepo<Setting>
    {
        private readonly PriceCalculatorDbContext context;

        public SettingRepo(PriceCalculatorDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Setting> GetByUserNameAsync(string userName)
        {
            return await Task.FromResult(context.Set<Setting>().FirstOrDefault(s => s.UserName == userName));
        }

        public override async Task<Setting> UpdateAsync(Setting setting)
        {
            var localSetting = context.Set<Setting>().Local.FirstOrDefault(s => s.Id == setting.Id);
            if (localSetting != null)
            {
                context.Entry(localSetting).State = EntityState.Detached;
            }

            context.Entry(setting).State = EntityState.Modified;

            await SaveAsync();

            return setting;
        }
    }
}
