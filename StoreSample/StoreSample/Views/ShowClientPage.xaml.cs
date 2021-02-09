using StoreSample.Database;
using StoreSample.Models;
using StoreSample.ViewModels;
using System;
using Xamarin.Forms.Xaml;

namespace StoreSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowClientPage : ShowClientXaml
    {
        public ShowClientPage()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            InitializeComponent();
            base.Initialize();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }

    public class ShowClientXaml : BasePage<ShowClientViewModel, Client, ClientsManager> { }
}