
using StoreSample.Database;
using StoreSample.Models;
using StoreSample.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidoPage : PedidoXaml
    {
        public PedidoPage()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            InitializeComponent();
            base.Initialize();
        }
    }

    public class PedidoXaml : BasePage<PanViewModel, Pan, PanManager> { }
}