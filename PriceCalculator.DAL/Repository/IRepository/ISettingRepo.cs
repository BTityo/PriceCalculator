using PriceCalculator.DAL.Models;
using System.Threading.Tasks;

namespace PriceCalculator.DAL.Repository.IRepository
{
    public interface ISettingRepo<T> : IBaseRepo<T> where T : class
    {
        Task<Setting> GetByUserNameAsync(string userName);
        Task<Setting> UpdateAsync(Setting setting);
    }
}
