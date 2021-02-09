using StoreSample.ViewModels;
using StoreSample.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StoreSample
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CestaComprasPage), typeof(CestaComprasPage));
            Routing.RegisterRoute(nameof(CadastroClientePage), typeof(CadastroClientePage));
            Routing.RegisterRoute(nameof(PedidoPage), typeof(PedidoPage));
        }


    }
}
