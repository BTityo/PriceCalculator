using PriceCalculator.DAL.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PriceCalculator.Windows.ViewModels.Maps
{
    public static class ThicknessMap
    {
        public static Thickness MapToEntity(ThicknessViewModel viewModel)
        {
            if (viewModel != null)
            {
                return new Thickness()
                {
                    Id = viewModel.Id,
                    InsertDate = viewModel.InsertDate,
                    LastChangeDate = viewModel.LastChangeDate,
                    Value = viewModel.Value,
                    Name = viewModel.Name
                };
            }
            else
            {
                return null;
            }
        }

        public static ThicknessViewModel MapToViewModel(Thickness entity)
        {
            if (entity != null)
            {
                return new ThicknessViewModel()
                {
                    Id = entity.Id,
                    InsertDate = entity.InsertDate,
                    LastChangeDate = entity.LastChangeDate,
                    Value = entity.Value,
                    Name = entity.Name
                };
            }
            else
            {
                return new ThicknessViewModel();
            }
        }

        public static ObservableCollection<ThicknessViewModel> MapToViewModelList(List<Thickness> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                ObservableCollection<ThicknessViewModel> viewModels = new ObservableCollection<ThicknessViewModel>();
                foreach (Thickness entity in entities)
                {
                    viewModels.Add(new ThicknessViewModel
                    {
                        Id = entity.Id,
                        InsertDate = entity.InsertDate,
                        LastChangeDate = entity.LastChangeDate,
                        Value = entity.Value,
                        Name = entity.Name
                    });
                }

                return viewModels;
            }
            else
            {
                return null;
            }
        }

        public static List<Thickness> MapToEntityList(ObservableCollection<ThicknessViewModel> viewModels)
        {
            List<Thickness> entities = new List<Thickness>();
            if (viewModels != null && viewModels.Count > 0)
            {
                foreach (ThicknessViewModel viewModel in viewModels)
                {
                    entities.Add(new Thickness
                    {
                        Id = viewModel.Id,
                        InsertDate = viewModel.InsertDate,
                        LastChangeDate = viewModel.LastChangeDate,
                        Value = viewModel.Value,
                        Name = viewModel.Name
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
