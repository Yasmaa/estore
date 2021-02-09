using MvvmHelpers;
using MvvmHelpers.Commands;
using StoreSample.Database;
using StoreSample.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoreSample.ViewModels
{
    public class PanierViewModel : BaseItemViewModel<Pan, PanManager>
    {
        public ObservableRangeCollection<ItemPan> ItemsPan { get; set; }
        public ICommand RemoveProductCommand { get; set; }
        public ICommand FinalCommand { get; set; }
        public PanierViewModel()
        {
            
            Item = DataManager.GetpanNConcl();
            ItemsPan = new ObservableRangeCollection<ItemPan>();
            ItemsPan.AddRange(Item.ItemsPan);

            Title = $"Pr N° {Item.Id:000}";

            RemoveProductCommand = new MvvmHelpers.Commands.Command(async (object obj) => await RemoveProduct(obj as ItemPan));
            FinalCommand = new AsyncCommand(Final);
        }

        private async Task RemoveProduct(ItemPan itemPedido)
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                await Task.Delay(100);
                DataManager.RemoveItemPan(itemPedido);
                ItemsPan.Remove(itemPedido);
                Item.CalculTotal();
                IsBusy = false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                IsBusy = false;
            }
        }

        private async Task Final()
        {
            await Shell.Current.GoToAsync("/ShowClientPage");
     
        }
    }
}
