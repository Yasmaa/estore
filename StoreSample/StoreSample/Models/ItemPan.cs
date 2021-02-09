using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSample.Models
{
    public class ItemPan : BaseModel
    {
        Pan pan;
        public Pan Pan

        {
            get => pan;
            set => SetProperty(ref pan, value);
        }

        int panId;
        public int PanId
        {
            get => panId;
            set => SetProperty(ref panId, value);
        }

        Product product;
        public Product Product

        {
            get => product;
            set => SetProperty(ref product, value);
        }

        int productId;
        public int ProductId
        {
            get => productId;
            set => SetProperty(ref productId, value);
        }

        double quantite;
        public double Quantite
        {
            get => quantite;
            set
            {
                if (SetProperty(ref quantite, value))
                {
                    OnPropertyChanged(nameof(Total));
                    Pan?.CalculTotal();
                }
            }

        }


        public double? Total => Quantite * Product?.Pr;
    }
}
