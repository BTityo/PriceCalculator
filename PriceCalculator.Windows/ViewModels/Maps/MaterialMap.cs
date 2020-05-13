using PriceCalculator.DAL.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PriceCalculator.Windows.ViewModels.Maps
{
    public static class MaterialMap
    {
        public static Material MapToEntity(MaterialViewModel viewModel)
        {
            if (viewModel != null)
            {
                return new Material()
                {
                    Id = viewModel.Id,
                    InsertDate = viewModel.InsertDate,
                    LastChangeDate = viewModel.LastChangeDate,
                    Name = viewModel.Name,
                    TwoCM = viewModel.TwoCM,
                    ThreeCM = viewModel.ThreeCM,
                    FiveCM = viewModel.FiveCM,
                    EightCM = viewModel.EightCM,
                    NineCM = viewModel.NineCM,
                    TenCM = viewModel.TenCM
                };
            }
            else
            {
                return null;
            }
        }

        public static MaterialViewModel MapToViewModel(Material entity)
        {
            if (entity != null)
            {
                return new MaterialViewModel()
                {
                    Id = entity.Id,
                    InsertDate = entity.InsertDate,
                    LastChangeDate = entity.LastChangeDate,
                    Name = entity.Name,
                    TwoCM = entity.TwoCM,
                    ThreeCM = entity.ThreeCM,
                    FiveCM = entity.FiveCM,
                    EightCM = entity.EightCM,
                    NineCM = entity.NineCM,
                    TenCM = entity.TenCM
                };
            }
            else
            {
                return new MaterialViewModel();
            }
        }

        public static ObservableCollection<MaterialViewModel> MapToViewModelList(List<Material> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                ObservableCollection<MaterialViewModel> viewModels = new ObservableCollection<MaterialViewModel>();
                foreach (Material entity in entities)
                {
                    viewModels.Add(new MaterialViewModel
                    {
                        Id = entity.Id,
                        InsertDate = entity.InsertDate,
                        LastChangeDate = entity.LastChangeDate,
                        Name = entity.Name,
                        TwoCM = entity.TwoCM,
                        ThreeCM = entity.ThreeCM,
                        FiveCM = entity.FiveCM,
                        EightCM = entity.EightCM,
                        NineCM = entity.NineCM,
                        TenCM = entity.TenCM
                    });
                }

                return viewModels;
            }
            else
            {
                return null;
            }
        }

        public static List<Material> MapToEntityList(ObservableCollection<MaterialViewModel> viewModels)
        {
            List<Material> entities = new List<Material>();
            if (viewModels != null && viewModels.Count > 0)
            {
                foreach (MaterialViewModel viewModel in viewModels)
                {
                    entities.Add(new Material
                    {
                        Id = viewModel.Id,
                        InsertDate = viewModel.InsertDate,
                        LastChangeDate = viewModel.LastChangeDate,
                        Name = viewModel.Name,
                        TwoCM = viewModel.TwoCM,
                        ThreeCM = viewModel.ThreeCM,
                        FiveCM = viewModel.FiveCM,
                        EightCM = viewModel.EightCM,
                        NineCM = viewModel.NineCM,
                        TenCM = viewModel.TenCM
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
