using StoreSample.Database;
using StoreSample.Models;
using StoreSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : InicioXaml
    {
        public InicioPage()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            InitializeComponent();
            base.Initialize();
        }

    }

    public class InicioXaml : BasePage<HomeViewModel, Product, ProductsManager> { }
}