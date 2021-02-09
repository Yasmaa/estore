using StoreSample.Helpers;
using StoreSample.Models;
using StoreSample.Database;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StoreSample.ViewModels
{
    public class BaseCollectionViewModel<TModel, TDataManager> : BaseViewModel<TModel, TDataManager> where TModel : BaseModel, new() where TDataManager : BaseDataManager<TModel>, new()
    {
        public ObservableRangeCollection<TModel> Items { get; set; }

        private TModel selectedItem;
        public TModel SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }

        public ICommand RemoveCommand { get; set; }

        public BaseCollectionViewModel()
        {
            Items = new ObservableRangeCollection<TModel>();
            RemoveCommand = new AsyncCommand(OnRemove);
            SaveCommand = new AsyncCommand(OnSave);
        }

        public async override void OnAppearing()
        {
            await OnLoad();
        }

        protected virtual async Task OnRemove()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                await Task.Delay(100);
                DataManager.Remove(SelectedItem);
                Items.Remove(SelectedItem);
                SelectedItem = null;
                IsBusy = false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                IsBusy = false;
            }
        }

        protected virtual async Task OnSave()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                await Task.Delay(100);
                DataManager.Update(SelectedItem);

                IsBusy = false;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                IsBusy = false;
            }
        }

        protected virtual async Task OnLoad()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                await Task.Delay(100);

                SelectedItem = null;

                if (Items.Count == 0)
                {
                    var newItems = DataManager.GetAll().ToList();

                    if (newItems.Count > 0)
                    {
                        Items.ReplaceRange(newItems);
                        IsBusy = false;
                    }
                }
                else IsBusy = false;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                IsBusy = false;
            }
        }

    }
}