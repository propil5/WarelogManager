using AutoMapper;
using IronPython.Compiler.Ast;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Client.Resources.Sales;
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
        private readonly IMapper _mapper;

        public BasketItemService(IBasketItemRepository basketItemRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _basketItemRepository = basketItemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DtoResponse> Add(BasketItemDto basketItem)
        {
            try
            {
                if (await _basketItemRepository.Add(basketItem))
                {
                    await _unitOfWork.CompleteAsync();
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

        public async Task<IEnumerable<BasketItemDto>> GetUserBasketItems(string userId)
        {
            return await _basketItemRepository.Get(userId);
        }

        public async Task<BasketItemDto> Get(int id)
        {
            return await _basketItemRepository.Get(id);
        }

        public async Task<DtoResponse> Update(int id, BasketItemDto basketItem)
        {
            var existingBasketItem = await _basketItemRepository.Get(id);

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

        public async Task<DtoResponse> ApplyPatch(int id, JsonPatchDocument<BaseBasketItemResource> basketItemPatchResource)
        {
            var existingBasketItem = await _basketItemRepository.Get(id);

            if (existingBasketItem == null)
            {
                return new DtoResponse($"Could not find basketItem to apply patch for basket item with id:{id}.");
            }

            try
            {
                var basketItemEntity = await _basketItemRepository.Get(id);
                var basketItemToPatch = _mapper.Map<BaseBasketItemResource>(basketItemEntity);
                basketItemPatchResource.ApplyTo(basketItemToPatch);
                _mapper.Map(basketItemToPatch, basketItemEntity);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(basketItemEntity);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the basketItem: {ex.Message}");
            }
        }

        public async Task<DtoResponse> DeleteAsync(int id)
        {
            var existingBasketItem = await _basketItemRepository.Get(id);

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
