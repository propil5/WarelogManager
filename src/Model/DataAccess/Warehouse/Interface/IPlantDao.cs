using System.Collections.Generic;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.DataAccess.Warehouse
{
    public interface IPlantDao
    {
        bool Add(PlantDto pallet);
        bool Delete(int id);
        IEnumerable<PlantDto> Get();
        IEnumerable<PlantDto> GetById(int id);
        bool Update(PlantDto Pallet);
    }
}