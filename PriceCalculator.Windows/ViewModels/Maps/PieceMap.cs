using PriceCalculator.DAL.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PriceCalculator.Windows.ViewModels.Maps
{
    public static class PieceMap
    {
        public static Piece MapToEntity(PieceViewModel viewModel)
        {
            if (viewModel != null)
            {
                return new Piece()
                {
                    Id = viewModel.Id,
                    InsertDate = viewModel.InsertDate,
                    LastChangeDate = viewModel.LastChangeDate,
                    Name = viewModel.Name,
                    Value = viewModel.Value
                };
            }
            else
            {
                return null;
            }
        }

        public static PieceViewModel MapToViewModel(Piece entity)
        {
            if (entity != null)
            {
                return new PieceViewModel()
                {
                    Id = entity.Id,
                    InsertDate = entity.InsertDate,
                    LastChangeDate = entity.LastChangeDate,
                    Name = entity.Name,
                    Value = entity.Value
                };
            }
            else
            {
                return new PieceViewModel();
            }
        }

        public static ObservableCollection<PieceViewModel> MapToViewModelList(List<Piece> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                ObservableCollection<PieceViewModel> viewModels = new ObservableCollection<PieceViewModel>();
                foreach (Piece entity in entities)
                {
                    viewModels.Add(new PieceViewModel
                    {
                        Id = entity.Id,
                        InsertDate = entity.InsertDate,
                        LastChangeDate = entity.LastChangeDate,
                        Name = entity.Name,
                        Value = entity.Value
                    });
                }

                return viewModels;
            }
            else
            {
                return null;
            }
        }

        public static List<Piece> MapToEntityList(ObservableCollection<PieceViewModel> viewModels)
        {
            List<Piece> entities = new List<Piece>();
            if (viewModels != null && viewModels.Count > 0)
            {
                foreach (PieceViewModel viewModel in viewModels)
                {
                    entities.Add(new Piece
                    {
                        Id = viewModel.Id,
                        InsertDate = viewModel.InsertDate,
                        LastChangeDate = viewModel.LastChangeDate,
                        Name = viewModel.Name,
                        Value = viewModel.Value
                    });
                }

                return entities;
            }
            else
            {
                return entities;
            }
        }
    }
}
