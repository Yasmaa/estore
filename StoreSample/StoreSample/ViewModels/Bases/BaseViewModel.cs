using MvvmHelpers.Commands;
using StoreSample.Database;
using StoreSample.Models;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StoreSample.ViewModels
{
    public class BaseViewModel<TModel, TDataManager> : MvvmHelpers.BaseViewModel where TModel : BaseModel, new() where TDataManager : BaseDataManager<TModel>, new()
    {

        private TDataManager dataManager;
        public TDataManager DataManager => dataManager ?? (dataManager = new TDataManager());

        #region Commands
        public ICommand RefreshCommand { get; }
        public ICommand SaveCommand { get; set; }
        public ICommand BackCommand { get; }
        #endregion

        public BaseViewModel()
        {
            RefreshCommand = new AsyncCommand(OnRefresh);
            BackCommand = new AsyncCommand(OnBack);
        }

        protected virtual Task OnBack()
        {
            return null;
        }

  
        protected virtual Task OnRefresh() { return null; }

        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }


    }
}
