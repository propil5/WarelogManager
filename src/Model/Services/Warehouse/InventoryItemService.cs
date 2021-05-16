using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Repositories.UnitOfWork;
using WarelogManager.Model.Repositories.Warehouse.Interface;
using WarelogManager.Model.Services.Warehouse.Interface;

namespace WarelogManager.Model.Services.Warehouse
{
    public class InventoryItemService : IInventoryItemService
    {
        private readonly IInventoryItemRepository _inventoryItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InventoryItemService(IInventoryItemRepository inventoryItemRepository, IUnitOfWork unitOfWork)
        {
            _inventoryItemRepository = inventoryItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DtoResponse> Add(InventoryItemDto inventoryItem)
        {
            try
            {
                inventoryItem.AddedDate = DateTime.Now;
                var id = await _inventoryItemRepository.Add(inventoryItem);
                inventoryItem.Id = id ?? 0;

                return new DtoResponse(inventoryItem);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the inventoryItem do the database: {ex.Message}");
            }
        }

        public async Task<IEnumerable<InventoryItemDto>> Get()
        {
            return await _inventoryItemRepository.Get();
        }

        public async Task<InventoryItemDto> Get(int id)
        {
            return await _inventoryItemRepository.GetById(id);
        }

        public async Task<DtoResponse> Update(int id, InventoryItemDto inventoryItem)
        {
            var existingInventoryItem = await _inventoryItemRepository.GetById(id);

            if (existingInventoryItem == null)
            {
                return new DtoResponse($"Could not find inventoryItem to update with id:{id}.");
            }

            existingInventoryItem.SKULabel = inventoryItem.SKULabel;
            existingInventoryItem.UnitOfMeasure = inventoryItem.UnitOfMeasure;
            existingInventoryItem.Descritption = inventoryItem.Descritption;
            existingInventoryItem.SizeId = inventoryItem.SizeId;
            existingInventoryItem.AvailableQuantity = inventoryItem.AvailableQuantity;
            existingInventoryItem.TotalQuantity = inventoryItem.TotalQuantity;
            existingInventoryItem.EditedById = inventoryItem.EditedById;
            existingInventoryItem.EditedDate = DateTime.Now;
            existingInventoryItem.ProductId = inventoryItem.ProductId;

            try
            {
                _inventoryItemRepository.Update(existingInventoryItem);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(inventoryItem);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the inventory item: {ex.Message}");
            }
        }

        public async Task<DtoResponse> Delete(int id)
        {
            var existingCompany = await _inventoryItemRepository.GetById(id);

            if (existingCompany == null)
            {
                return new DtoResponse($"Could not find inventory item to update with id: {id}.");
            }

            try
            {
                _inventoryItemRepository.Delete(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(existingCompany);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when deleting inventoryItem. {ex.Message}");
            }
        }
    }
}
