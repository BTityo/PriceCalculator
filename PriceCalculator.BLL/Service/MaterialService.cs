using PriceCalculator.DAL.Context;
using PriceCalculator.DAL.Models;
using PriceCalculator.DAL.Repository;
using PriceCalculator.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceCalculator.BLL.Service
{
    public class MaterialService
    {
        private IBaseRepo<Material> materialRepo;

        public MaterialService(string connectionString)
        {
            this.materialRepo = new BaseRepo<Material>(new PriceCalculatorDbContext(connectionString));
        }

        public MaterialService(IBaseRepo<Material> materialRepo)
        {
            this.materialRepo = materialRepo;
        }

        /// <summary>
        /// Get all Material-s async
        /// </summary>
        /// <returns>Task<List<Material>></returns>
        public async Task<List<Material>> GetMaterialsAsync()
        {
            return await materialRepo.GetAllAsync();
        }

        /// <summary>
        /// Get Material by Id async
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns>Task<Material></returns>
        public async Task<Material> GetMaterialByIdAsync(int materialId)
        {
            return await materialRepo.GetByIdAsync(materialId);
        }

        /// <summary>
        /// Insert Material to database async
        /// </summary>
        /// <param name="material"></param>
        /// <returns>Task<Material></returns>
        public async Task<Material> InsertMaterialAsync(Material material)
        {
            return await materialRepo.InsertAsync(material);
        }

        /// <summary>
        /// Update Material in database async
        /// </summary>
        /// <param name="material"></param>
        /// <returns>Task<Material></returns>
        public async Task<Material> UpdateMaterialAsync(Material material)
        {
            material.LastChangeDate = DateTime.Now;
            return await materialRepo.UpdateAsync(material);
        }

        /// <summary>
        /// Delete Material by id async
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns>Task<bool></returns>
        public async Task<bool> DeleteMaterialByIdAsync(int materialId)
        {
            return await materialRepo.DeleteByIdAsync(materialId);
        }
    }
}
