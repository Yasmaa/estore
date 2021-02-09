using StoreSample.Database;
using StoreSample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoreSample.ViewModels
{
    public class ShowClientViewModel : BaseItemViewModel<Client, ClientsManager>
    {
        private PanManager panManager;

        public ShowClientViewModel()
        {
            Title = "save";
            Item = DataManager.GetCliente();
            panManager = new PanManager();

            if (Item == null)
                Item = new Client();
        }

        protected override async Task OnSave()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                await Task.Delay(100);
                var validate = new List<string>();

                if (string.IsNullOrWhiteSpace(Item.Nom))
                    validate.Add("nom");

                if (string.IsNullOrWhiteSpace(Item.Email))
                    validate.Add("e-mail");

                if (string.IsNullOrWhiteSpace(Item.Tele))
                    validate.Add("tele");

                if (validate.Count > 0)
                {
                    await Shell.Current.DisplayAlert(Title, $"fill in the forms please: {string.Join(", ", validate)}", "ok");
                    IsBusy = false;
                    return;
                }

                if (Item.Id == 0)
                    DataManager.Add(Item);
                else
                    DataManager.Update(Item);

                var pan = panManager.GetpanNConcl();
                pan.Client = Item;
                pan.Concl = true;
                panManager.Update(pan);
                
                await Shell.Current.GoToAsync("../../PanPage");

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
