using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreSample.Models
{
    public class Pan : BaseModel
    {
        Client client;
        public Client Client
        {
            get => client;
            set => SetProperty(ref client, value);
        }

        int? clientId;
        public int? ClientId
        {
            get => clientId;
            set => SetProperty(ref clientId, value);
        }

        public double? Total => ItemsPan?.Sum(s => s.Total);

        bool concl;
        public bool Concl
        {
            get => concl;
            set => SetProperty(ref concl, value);
        }

        List<ItemPan> itemsPan;
        public List<ItemPan> ItemsPan
        {
            get => itemsPan;
            set => SetProperty(ref itemsPan, value);
        }

        public void CalculTotal()
        {
            OnPropertyChanged(nameof(Total));
        }

    }
}
