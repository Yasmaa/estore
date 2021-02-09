using StoreSample.Helpers;
using StoreSample.Models;
using StoreSample.ViewModels;
using MvvmHelpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StoreSample.Database;
using StoreSample.Effects;

namespace StoreSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePage<TViewModel, TModel, TDataManager> : ContentPage where TViewModel : BaseViewModel<TModel, TDataManager>, new() where TModel : BaseModel, new() where TDataManager : BaseDataManager<TModel>, new()
    {
        private TViewModel viewModel;
        public TViewModel ViewModel => viewModel ?? (viewModel = new TViewModel());

        public BasePage(TModel entity = null)
        {
            BackgroundColor = Color.WhiteSmoke;

            if (entity != null)
                (ViewModel as BaseItemViewModel<TModel, TDataManager>).Item = entity;
        }

        protected virtual void Initialize()
        {
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel.OnDisappearing();
        }

    }
}