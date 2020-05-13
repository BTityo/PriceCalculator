using PriceCalculator.DAL.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PriceCalculator.Windows.ViewModels.Maps
{
    public static class BaseCalculationMap
    {
        public static BaseCalculation MapToEntity(BaseCalculationViewModel viewModel)
        {
            if (viewModel != null)
            {
                return new BaseCalculation()
                {
                    Id = viewModel.Id,
                    InsertDate = viewModel.InsertDate,
                    LastChangeDate = viewModel.LastChangeDate,
                    Name = viewModel.Name,
                    WithoutTaxSum = viewModel.WithoutTaxSum,
                    WithTaxSum = viewModel.WithTaxSum
                };
            }
            else
            {
                return null;
            }
        }

        public static BaseCalculationViewModel MapToViewModel(BaseCalculation entity)
        {
            if (entity != null)
            {
                return new BaseCalculationViewModel()
                {
                    Id = entity.Id,
                    InsertDate = entity.InsertDate,
                    LastChangeDate = entity.LastChangeDate,
                    Name = entity.Name,
                    WithoutTaxSum = entity.WithoutTaxSum,
                    WithTaxSum = entity.WithTaxSum
                };
            }
            else
            {
                return new BaseCalculationViewModel();
            }
        }

        public static ObservableCollection<BaseCalculationViewModel> MapToViewModelList(List<BaseCalculation> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                ObservableCollection<BaseCalculationViewModel> viewModels = new ObservableCollection<BaseCalculationViewModel>();
                foreach (BaseCalculation entity in entities)
                {
                    viewModels.Add(new BaseCalculationViewModel
                    {
                        Id = entity.Id,
                        InsertDate = entity.InsertDate,
                        LastChangeDate = entity.LastChangeDate,
                        Name = entity.Name,
                        WithoutTaxSum = entity.WithoutTaxSum,
                        WithTaxSum = entity.WithTaxSum
                    });
                }

                return viewModels;
            }
            else
            {
                return null;
            }
        }

        public static List<BaseCalculation> MapToEntityList(ObservableCollection<BaseCalculationViewModel> viewModels)
        {
            List<BaseCalculation> entities = new List<BaseCalculation>();
            if (viewModels != null && viewModels.Count > 0)
            {
                foreach (BaseCalculationViewModel viewModel in viewModels)
                {
                    entities.Add(new BaseCalculation
                    {
                        Id = viewModel.Id,
                        InsertDate = viewModel.InsertDate,
                        LastChangeDate = viewModel.LastChangeDate,
                        Name = viewModel.Name,
                        WithoutTaxSum = viewModel.WithoutTaxSum,
                        WithTaxSum = viewModel.WithTaxSum
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
