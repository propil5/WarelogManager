using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Client.Resources.Sales;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Sales;

namespace WarelogManager.Model.Services.Sales.Interface
{
    public interface IBasketItemService
    {
        Task<DtoResponse> Add(BasketItemDto basketItem);
        Task<DtoResponse> DeleteAsync(int id);
        Task<IEnumerable<BasketItemDto>> Get();
        Task<BasketItemDto> Get(int id);
        Task<IEnumerable<BasketItemDto>> GetUserBasketItems(string userId);
        Task<DtoResponse> Update(int id, BasketItemDto basketItem);
        Task<DtoResponse> ApplyPatch(int id, JsonPatchDocument<BaseBasketItemResource> basketItemPatchResource);
    }
}
