using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Mapping;

namespace WarelogManager.Model.Repositories.Warehouse
{
    public class PlantRepository : BaseRepository, IPlantRepository
    {
        public PlantRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool Add(PlantDto pallet)
        {
            _context.Plants.Add(pallet);
            var saveResult = _context.SaveChanges();
            return saveResult == 1;
        }

        public IEnumerable<PlantDto> Get()
        {
            return _context.Plants;
        }

        public IEnumerable<PlantDto> GetById(int id)
        {
            return _context.Plants.Where(x => x.Id == id);
        }

        public bool Update(PlantDto Pallet)
        {
            var exisitngPallet = _context.Plants
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
