using PriceCalculator.DAL.Context;
using PriceCalculator.DAL.Models;
using PriceCalculator.DAL.Repository;
using PriceCalculator.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceCalculator.BLL.Service
{
    public class PieceService
    {
        private IBaseRepo<Piece> pieceRepo;

        public PieceService(string connectionString)
        {
            this.pieceRepo = new BaseRepo<Piece>(new PriceCalculatorDbContext(connectionString));
        }

        public PieceService(IBaseRepo<Piece> pieceRepo)
        {
            this.pieceRepo = pieceRepo;
        }

        /// <summary>
        /// Get all Piece-s async
        /// </summary>
        /// <returns>Task<List<Piece>></returns>
        public async Task<List<Piece>> GetPiecesAsync()
        {
            return await pieceRepo.GetAllAsync();
        }

        /// <summary>
        /// Get Piece by Id async
        /// </summary>
        /// <param name="pieceId"></param>
        /// <returns>Task<Piece></returns>
        public async Task<Piece> GetPieceByIdAsync(int pieceId)
        {
            return await pieceRepo.GetByIdAsync(pieceId);
        }

        /// <summary>
        /// Insert Piece to database async
        /// </summary>
        /// <param name="piece"></param>
        /// <returns>Task<Piece></returns>
        public async Task<Piece> InsertPieceAsync(Piece piece)
        {
            return await pieceRepo.InsertAsync(piece);
        }

        /// <summary>
        /// Update Piece in database async
        /// </summary>
        /// <param name="piece"></param>
        /// <returns>Task<Piece></returns>
        public async Task<Piece> UpdatePieceAsync(Piece piece)
        {
            piece.LastChangeDate = DateTime.Now;
            return await pieceRepo.UpdateAsync(piece);
        }

        /// <summary>
        /// Delete Piece by id async
        /// </summary>
        /// <param name="pieceId"></param>
        /// <returns>Task<bool></returns>
        public async Task<bool> DeletePieceByIdAsync(int pieceId)
        {
            return await pieceRepo.DeleteByIdAsync(pieceId);
        }
    }
}
