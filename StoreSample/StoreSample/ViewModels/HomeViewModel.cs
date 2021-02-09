using MvvmHelpers.Commands;
using StoreSample.Database;
using StoreSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace StoreSample.ViewModels
{
    public class HomeViewModel : BaseCollectionViewModel<Product, ProductsManager>
    {
        private PanManager pansManager;

        public Pan PanNConcl { get; set; }
        public ICommand command { get; set; }
        public ICommand Addcommand { get; set; }

        public HomeViewModel()
        {
            Title = "EStore";
            command = new AsyncCommand(add);
            Addcommand = new Command(async (object obj) => await Addcommands(obj as Product));
            pansManager = new PanManager();
        }

        private async Task Addcommands(Product product)
        {
            var itemPan = PanNConcl.ItemsPan.Where(i => i.Product == product).FirstOrDefault();
            
            if (itemPan == null)
            {
                itemPan = new ItemPan
                {
                    Pan = PanNConcl,
                    Product = product,
                    Quantite = 1
                };

                PanNConcl.ItemsPan.Add(itemPan);
            }
            else
            {
                itemPan.Quantite = itemPan.Quantite + 1;
            }

            pansManager.Update(PanNConcl);
        }

        private async Task add()
        {
            if (PanNConcl?.ItemsPan?.Count == 0)
            {
                await Shell.Current.DisplayAlert("please!", "Add a product.", "ok");
                return;
            }
        
            await Shell.Current.GoToAsync("/valPage");
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            PanNConcl = pansManager.GetpanNConcl();

            if (PanNConcl == null)
            {
                PanNConcl = new Pan() 
                { 
                    ItemsPan = new List<ItemPan>()
                };

                pansManager.Add(PanNConcl);
            }
        }
    }
}
