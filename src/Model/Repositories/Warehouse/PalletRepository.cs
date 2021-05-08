using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Mapping;

namespace WarelogManager.Model.Repositories.Warehouse
{
    public class PalletRepository : BaseRepository, IPalletRepository
    {
        public PalletRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool Add(PalletDto pallet)
        {
            _context.Pallets.Add(pallet);
            var saveResult = _context.SaveChanges();
            return saveResult == 1;
        }

        public IEnumerable<PalletDto> Get()
        {
            return _context.Pallets;
        }

        public IEnumerable<PalletDto> GetById(int id)
        {
            return _context.Pallets.Where(x => x.Id == id);
        }

        public bool Update(PalletDto Pallet)
        {
            var exisitngPallet = _context.Pallets
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
