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
    public class BasketItemService : IBasketItemService
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BasketItemService(IBasketItemRepository basketItemRepository, IUnitOfWork unitOfWork)
        {
            _basketItemRepository = basketItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DtoResponse> Add(BasketItemDto basketItem)
        {
            try
            {
                if (await _basketItemRepository.Add(basketItem))
                {
                    return new DtoResponse(basketItem);
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

        public async Task<IEnumerable<BasketItemDto>> Get()
        {
            return await _basketItemRepository.Get();
        }

        public async Task<BasketItemDto> Get(int id)
        {
            return await _basketItemRepository.GetById(id);
        }

        public async Task<DtoResponse> Update(int id, BasketItemDto basketItem)
        {
            var existingBasketItem = await _basketItemRepository.GetById(id);

            if (existingBasketItem == null)
            {
                return new DtoResponse($"Could not find basketItem to update with id:{id}.");
            }
            try
            {
                _basketItemRepository.Update(basketItem);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(basketItem);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the basketItem: {ex.Message}");
            }
        }

        public async Task<DtoResponse> DeleteAsync(int id)
        {
            var existingBasketItem = await _basketItemRepository.GetById(id);

            if (existingBasketItem == null)
            {
                return new DtoResponse($"Could not find basketItem to update with id: {id}.");
            }

            try
            {
                _basketItemRepository.Delete(existingBasketItem);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(existingBasketItem);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when deleting basketItem. {ex.Message}");
            }
        }
    }
}
