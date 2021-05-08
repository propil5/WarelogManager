using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Repositories.Warehouse.Interface;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Mapping;

namespace WarelogManager.Model.Repositories.Warehouse
{
    public class RackRepository : BaseRepository, IRackRepository
    {
        public RackRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool Add(RackDto pallet)
        {
            _context.Racks.Add(pallet);
            var saveResult = _context.SaveChanges();
            return saveResult == 1;
        }

        public IEnumerable<RackDto> Get()
        {
            return _context.Racks;
        }

        public IEnumerable<RackDto> GetById(int id)
        {
            return _context.Racks.Where(x => x.Id == id);
        }

        public bool Update(RackDto Pallet)
        {
            var exisitngPallet = _context.Racks
                .Where(x => x.Id == Pallet.Id)
                .SingleOrDefault();


            if (exisitngPallet == null)
            {
                return false;
            }

            _context.Update(exisitngPallet);
            var saveResult = _context.SaveChanges();
            return saveResult == 1;
        }

        public bool Delete(int id)
        {
            var deleted = false;
            var Pallet = _context.Companies
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (Pallet != null)
            {
                _context.Remove(Pallet);
                deleted = true;
            }
            else
            {
                deleted = false;
            }

            var saveResult = _context.SaveChanges();
            return saveResult == 1 && deleted == true;
        }
    }
}
