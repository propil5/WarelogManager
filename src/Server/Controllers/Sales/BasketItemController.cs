using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WarelogManager.Client.Resources.Sales;
using WarelogManager.Model.DataTransfer.Sales;
using WarelogManager.Model.Extensions;
using WarelogManager.Model.Services.Sales;
using WarelogManager.Model.Services.Sales.Interface;

namespace WarelogManager.Client.Controllers.Sales
{
    [Route("api/basket/item")]
    [ApiController]
    public class BasketItemController : ControllerBase
    {
        private readonly IBasketItemService _basketItemService;
        private readonly IMapper _mapper;

        public BasketItemController(IBasketItemService basketItemService, IMapper mapper)
        {
            _basketItemService = basketItemService;
            _mapper = mapper;
        }

        // GET api/basket/item
        [HttpGet]
        public async Task<IEnumerable<BasketItemResource>> Get()
        {
            var queryResult = await _basketItemService.Get();
            var resource = _mapper.Map<IEnumerable<BasketItemDto>, IEnumerable<BasketItemResource>>(queryResult);
            return resource;
        }

        // GET api/basket/item/5
        [HttpGet("{id:int}")]
        public async Task<BasketItemResource> GetById(int id)
        {
            var queryResult = await _basketItemService.Get(id);
            return _mapper.Map<BasketItemDto, BasketItemResource>(queryResult);
        }

        // POST api/basket/item
        [HttpPost]
        public async Task<IActionResult> Add(BasketItemResource basketItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            
            var basketItemDto = _mapper.Map<BasketItemResource, BasketItemDto>(basketItem);
            basketItemDto.ApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            basketItemDto.AddedAt = DateTime.UtcNow;
            var result = await _basketItemService.Add(basketItemDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var basketItemResorce = _mapper.Map<BasketItemDto, BasketItemResource>(result.Dto as BasketItemDto);
            return Ok(basketItemResorce);
        }

        // PUT api/basket/item
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BasketItemResource basketItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var basketItemDto = _mapper.Map<BasketItemResource, BasketItemDto>(basketItem);
            var result = await _basketItemService.Update(id, basketItemDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var basketItemResource = _mapper.Map<BasketItemDto, BasketItemResource>(result.Dto as BasketItemDto);
            return Ok(basketItemResource);
        }

        // DELETE api/basket/item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _basketItemService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var basketItemResource = _mapper.Map<BasketItemDto, BasketItemResource>(result.Dto as BasketItemDto);
            return Ok(basketItemResource);
        }
    }
}
