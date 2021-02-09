using System.Collections.Generic;

namespace StoreSample.Models
{
    public class Product : BaseModel
    {
        string nom;
        public string Nom
        {
            get => nom;
            set => SetProperty(ref nom, value);
        }

        string imagem;
        public string Imagem
        {
            get => imagem;
            set => SetProperty(ref imagem, value);
        }

        double pr;
        public double Pr
        {
            get => pr;
            set => SetProperty(ref pr, value);
        }

        List<ItemPan> itemsPan;
        public List<ItemPan> ItemsPan
        {
            get => itemsPan;
            set => SetProperty(ref itemsPan, value);
        }

    }
}
