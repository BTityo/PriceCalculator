using PriceCalculator.DAL.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PriceCalculator.Windows.ViewModels.Maps
{
    public static class SettingMap
    {
        public static Setting MapToEntity(SettingViewModel viewModel)
        {
            if (viewModel != null)
            {
                return new Setting()
                {
                    Id = viewModel.Id,
                    InsertDate = viewModel.InsertDate,
                    LastChangeDate = viewModel.LastChangeDate,
                    IsStartWithWindows = viewModel.IsStartWithWindows,
                    UserName = viewModel.UserName,
                    Platform = viewModel.Platform
                };
            }
            else
            {
                return null;
            }
        }

        public static SettingViewModel MapToViewModel(Setting entity)
        {
            if (entity != null)
            {
                return new SettingViewModel()
                {
                    Id = entity.Id,
                    InsertDate = entity.InsertDate,
                    LastChangeDate = entity.LastChangeDate,
                    IsStartWithWindows = entity.IsStartWithWindows,
                    UserName = entity.UserName,
                    Platform = entity.Platform
                };
            }
            else
            {
                return new SettingViewModel();
            }
        }

        public static ObservableCollection<SettingViewModel> MapToViewModelList(List<Setting> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                ObservableCollection<SettingViewModel> viewModels = new ObservableCollection<SettingViewModel>();
                foreach (Setting entity in entities)
                {
                    viewModels.Add(new SettingViewModel
                    {
                        Id = entity.Id,
                        InsertDate = entity.InsertDate,
                        LastChangeDate = entity.LastChangeDate,
                        IsStartWithWindows = entity.IsStartWithWindows,
                        UserName = entity.UserName,
                        Platform = entity.Platform
                    });
                }

                return viewModels;
            }
            else
            {
                return null;
            }
        }

        public static List<Setting> MapToEntityList(ObservableCollection<SettingViewModel> viewModels)
        {
            List<Setting> entities = new List<Setting>();
            if (viewModels != null && viewModels.Count > 0)
            {
                foreach (SettingViewModel viewModel in viewModels)
                {
                    entities.Add(new Setting
                    {
                        Id = viewModel.Id,
                        InsertDate = viewModel.InsertDate,
                        LastChangeDate = viewModel.LastChangeDate,
                        IsStartWithWindows = viewModel.IsStartWithWindows,
                        UserName = viewModel.UserName,
                        Platform = viewModel.Platform
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
