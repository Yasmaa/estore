using StoreSample.Database;
using StoreSample.Models;
using StoreSample.ViewModels;
using Xamarin.Forms.Xaml;

namespace StoreSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CestaComprasPage : CestadeComprasXaml
    {
        public CestaComprasPage()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            InitializeComponent();
            base.Initialize();
        }
    }

    public class CestadeComprasXaml : BasePage<PanierViewModel, Pan, PanManager> { }
}