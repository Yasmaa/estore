using MvvmHelpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace StoreSample.Models
{
    public class BaseModel : ObservableObject
    {
        int id;
        [Key]
        public virtual int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        DateTime created;
        public DateTime Created
        {
            get => created;
            set => SetProperty(ref created, value);
        }

        public BaseModel()
        {
            Created = DateTime.Now;
        }
    }
}
