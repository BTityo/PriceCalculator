using PriceCalculator.BLL.Constants;
using PriceCalculator.BLL.Service;
using PriceCalculator.DAL.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PriceCalculator.Windows.ViewModels.Maps
{
    public static class CalculationMap
    {
        private static readonly MaterialService materialService = new MaterialService(Constants.LocalDBPath);
        private static readonly PieceService pieceService = new PieceService(Constants.LocalDBPath);
        private static readonly ThicknessService thicknessService = new ThicknessService(Constants.LocalDBPath);
        private static readonly BaseCalculationService baseCalculationService = new BaseCalculationService(Constants.LocalDBPath);
        public static Calculation MapToEntity(CalculationViewModel viewModel)
        {
            if (viewModel != null)
            {
                return new Calculation()
                {
                    Id = viewModel.Id,
                    InsertDate = viewModel.InsertDate,
                    LastChangeDate = viewModel.LastChangeDate,
                    Length = viewModel.Length,
                    Width = viewModel.Width,
                    //Material = MaterialMap.MapToEntity(viewModel.SelectedMaterial),
                    MaterialId = viewModel.SelectedMaterial.Id,
                    //Piece = PieceMap.MapToEntity(viewModel.SelectedPiece),
                    PieceId = viewModel.SelectedPiece.Id,
                    //Thickness = ThicknessMap.MapToEntity(viewModel.SelectedThickness),
                    ThicknessId = viewModel.SelectedThickness.Id,
                    BaseCalculationId = viewModel.BaseCalculation.Id,
                    //BaseCalculation = BaseCalculationMap.MapToEntity(viewModel.BaseCalculation)

                };
            }
            else
            {
                return null;
            }
        }

        public static CalculationViewModel MapToViewModel(Calculation entity)
        {
            if (entity != null)
            {
                return new CalculationViewModel()
                {
                    Id = entity.Id,
                    InsertDate = entity.InsertDate,
                    LastChangeDate = entity.LastChangeDate,
                    Length = entity.Length,
                    Width = entity.Width,
                    SelectedMaterial = MaterialMap.MapToViewModel(entity.Material),
                    SelectedPiece = PieceMap.MapToViewModel(entity.Piece),
                    SelectedThickness = ThicknessMap.MapToViewModel(entity.Thickness),
                    BaseCalculation = BaseCalculationMap.MapToViewModel(entity.BaseCalculation)
                };
            }
            else
            {
                return new CalculationViewModel();
            }
        }

        public async static Task<ObservableCollection<CalculationViewModel>> MapToViewModelList(List<Calculation> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                ObservableCollection<CalculationViewModel> viewModels = new ObservableCollection<CalculationViewModel>();
                foreach (Calculation entity in entities)
                {
                    viewModels.Add(new CalculationViewModel
                    {
                        Id = entity.Id,
                        InsertDate = entity.InsertDate,
                        LastChangeDate = entity.LastChangeDate,
                        Length = entity.Length,
                        Width = entity.Width,
                        SelectedMaterial = MaterialMap.MapToViewModel(await materialService.GetMaterialByIdAsync(entity.MaterialId)),
                        SelectedPiece = PieceMap.MapToViewModel(await pieceService.GetPieceByIdAsync(entity.PieceId)),
                        SelectedThickness = ThicknessMap.MapToViewModel(await thicknessService.GetThicknessByIdAsync(entity.ThicknessId)),
                        BaseCalculation = BaseCalculationMap.MapToViewModel(await baseCalculationService.GetBaseCalculationByIdAsync(entity.BaseCalculationId))
                    });
                }

                return viewModels;
            }
            else
            {
                return null;
            }
        }

        public static List<Calculation> MapToEntityList(ObservableCollection<CalculationViewModel> viewModels)
        {
            List<Calculation> entities = new List<Calculation>();
            if (viewModels != null && viewModels.Count > 0)
            {
                foreach (CalculationViewModel viewModel in viewModels)
                {
                    entities.Add(new Calculation
                    {
                        Id = viewModel.Id,
                        InsertDate = viewModel.InsertDate,
                        LastChangeDate = viewModel.LastChangeDate,
                        Length = viewModel.Length,
                        Width = viewModel.Width,
                        //Material = MaterialMap.MapToEntity(viewModel.SelectedMaterial),
                        MaterialId = viewModel.SelectedMaterial.Id,
                        //Piece = PieceMap.MapToEntity(viewModel.SelectedPiece),
                        PieceId = viewModel.SelectedPiece.Id,
                        //Thickness = ThicknessMap.MapToEntity(viewModel.SelectedThickness),
                        ThicknessId = viewModel.SelectedThickness.Id
                        //BaseCalculation = BaseCalculationMap.MapToEntity(viewModel.BaseCalculation),
                        //BaseCalculationId = viewModel.BaseCalculation.Id
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
