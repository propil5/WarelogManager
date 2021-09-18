using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WarelogManager.Client.Resources.Sales;
using WarelogManager.Model.DataTransfer.Sales;
using WarelogManager.Model.Services.Sales.Interface;

namespace WarelogManager.Client.Controllers.Sales
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketItemService _basketItemService;
        private readonly IMapper _mapper;

        public BasketController(IBasketItemService basketItemService, IMapper mapper)
        {
            _basketItemService = basketItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BaseBasketItemResource>> Get()
        {
            var queryResult = await _basketItemService.GetUserBasketItems(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return _mapper.Map<IEnumerable<BasketItemDto>, IEnumerable<BaseBasketItemResource>>(queryResult);
        }
    }
}
