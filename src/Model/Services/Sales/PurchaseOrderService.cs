using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Sales;
using WarelogManager.Model.Repositories.Sales.Interface;
using WarelogManager.Model.Repositories.UnitOfWork;
using WarelogManager.Model.Services.Sales.Interface;

namespace WarelogManager.Model.Services.Sales
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository, IUnitOfWork unitOfWork)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DtoResponse> Add(PurchaseOrderDto purchaseOrder)
        {
            try
            {
                if (await _purchaseOrderRepository.Add(purchaseOrder))
                {
                    await _unitOfWork.CompleteAsync();
                    return new DtoResponse(purchaseOrder);
                }
                else
                {
                    return new DtoResponse("Could now add new basket item for unknow reasons.");
                }
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the product do the database: {ex.Message}");
            }
        }

        public async Task<IEnumerable<PurchaseOrderDto>> Get()
        {
            return await _purchaseOrderRepository.Get();
        }

        public async Task<PurchaseOrderDto> Get(int id)
        {
            return await _purchaseOrderRepository.GetById(id);
        }

        public async Task<DtoResponse> Update(int id, PurchaseOrderDto purchaseOrder)
        {
            var existingPurchaseOrder = await _purchaseOrderRepository.GetById(id);

            if (existingPurchaseOrder == null)
            {
                return new DtoResponse($"Could not find purchaseOrder to update with id:{id}.");
            }
            try
            {
                _purchaseOrderRepository.Update(purchaseOrder);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(purchaseOrder);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the purchaseOrder: {ex.Message}");
            }
        }

        public async Task<DtoResponse> DeleteAsync(int id)
        {
            var existingPurchaseOrder = await _purchaseOrderRepository.GetById(id);

            if (existingPurchaseOrder == null)
            {
                return new DtoResponse($"Could not find purchaseOrder to update with id: {id}.");
            }

            try
            {
                _purchaseOrderRepository.Delete(existingPurchaseOrder);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(existingPurchaseOrder);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when deleting purchaseOrder. {ex.Message}");
            }
        }
    }
}
