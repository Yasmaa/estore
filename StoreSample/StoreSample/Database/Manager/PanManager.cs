using Microsoft.EntityFrameworkCore;
using StoreSample.Models;
using System.Linq;

namespace StoreSample.Database
{
    public class PanManager : BaseDataManager<Pan>
    {
        public override IQueryable<Pan> GetIncludes(IQueryable<Pan> entities)
        {
            entities
                .Include(pan => pan.Client)
                .Include(pan => pan.ItemsPan)
                    .ThenInclude(itemPan => itemPan.Product);
            
            return base.GetIncludes(entities);
        }

        public Pan GetpanNConcl()
        {
            return GetIncludes(Database.Pans.Where(p => !p.Concl)).FirstOrDefault();
        }

        public Pan GeLastPan()
        {
            return GetIncludes(Database.Pans.OrderBy(p => p.Id)).LastOrDefault();
        }

        public void AddItemPan(ItemPan itemPan)
        {
            Database.ItemsPan.Add(itemPan);
            Database.SaveChanges();
        }

        public void RemoveItemPan(ItemPan itemPan)
        {
            Database.ItemsPan.Remove(itemPan);
            Database.SaveChanges();
        }
    }
}
