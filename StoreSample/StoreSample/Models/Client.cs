using System;
using System.Collections.Generic;
using System.Text;

namespace StoreSample.Models
{
    public class Client : BaseModel
    {
        string nom;
        public string Nom
        {
            get => nom;
            set => SetProperty(ref nom, value);
        }

        string email;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        string tele;
        public string Tele
        {
            get => tele;
            set => SetProperty(ref tele, value);
        }

        bool at;
        public bool At
        {
            get => at;
            set => SetProperty(ref at, value);
        }

        List<Pan> pans;
        public List<Pan> Pans
        {
            get => pans;
            set => SetProperty(ref pans, value);
        }

    }
}
