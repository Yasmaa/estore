using MvvmHelpers.Commands;
using StoreSample.Database;
using StoreSample.Helpers;
using StoreSample.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StoreSample.ViewModels
{
    public class BaseItemViewModel<TModel, TDataManager> : BaseViewModel<TModel, TDataManager> where TModel : BaseModel, new() where TDataManager : BaseDataManager<TModel>, new()
    {
        TModel item;
        public TModel Item
        {
            get => item;
            set => SetProperty(ref item, value);
        }

        public BaseItemViewModel()
        {
            SaveCommand = new AsyncCommand(OnSave);
        }

        protected async virtual Task OnSave()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                await Task.Delay(100);

                DataManager.Update(Item);
                IsBusy = false;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                IsBusy = false;
            }
        }
    }
}
