using MvvmHelpers;
using MvvmHelpers.Commands;
using StoreSample.Database;
using StoreSample.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoreSample.ViewModels
{
    public class PanViewModel : BaseItemViewModel<Pan, PanManager>
    {
        public ObservableRangeCollection<ItemPan> ItemsPan { get; set; }
        public ICommand FeachCommand { get; }
        public PanViewModel()
        {
            Item = DataManager.GeLastPan();
            ItemsPan = new ObservableRangeCollection<ItemPan>();
            ItemsPan.AddRange(Item.ItemsPan);

            Title = $" price {Item.Id:0:000}";
            FeachCommand = new AsyncCommand(Feach);

        }

        private async Task Feach()
        {
            await Shell.Current.GoToAsync("///HomePage");
        }

    }
}
