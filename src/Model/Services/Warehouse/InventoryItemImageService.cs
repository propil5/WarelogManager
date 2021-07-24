using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Repositories.Warehouse.Interface;

namespace WarelogManager.Model.Services.Warehouse
{
    public class InventoryItemImageService
    {
        private readonly IInventoryItemImageRepository _inventoryItemImageRepository;

        public InventoryItemImageService(IInventoryItemImageRepository inventoryItemImageRepository)
        {
            _inventoryItemImageRepository = inventoryItemImageRepository;
        }
    }
}
