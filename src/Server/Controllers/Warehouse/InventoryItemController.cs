using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Extensions;
using WarelogManager.Model.Services.Warehouse.Interface;
using WarelogManager.Shared.Resources.Warehouse.InventoryItem;

namespace WarelogManager.Client.Controllers.Warehouse
{
    [Route("api/inventory/item")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IInventoryItemService _inventoryService;
        private readonly IMapper _mapper;

        public InventoryItemController(UserManager<ApplicationUser> userManager, IInventoryItemService inventoryService, IMapper mapper)
        {
            _userManager = userManager;
            _inventoryService = inventoryService;
            _mapper = mapper;
        }

        // GET api/inventory/item
        [HttpGet]
        public async Task<IEnumerable<InventoryItemResource>> Get()
        {
            var inventories = await _inventoryService.Get();
            var itemResources = new List<InventoryItemResource>();
            foreach (var item in inventories)
            {
                var inventoryItemResource = _mapper.Map<InventoryItemDto, InventoryItemResource>(item);
                //inventoryItemResource.AddedByEmail = (await _userManager.FindByIdAsync(item.AddedById));
                //inventoryItemResource.EdditedByEmail = (await _userManager.FindByIdAsync(item.AddedById))?.Email;
                itemResources.Add(inventoryItemResource);
            }

            return itemResources;
        }

        // GET api/inventory/item/5
        [HttpGet("{id:int}")]
        public async Task<InventoryItemResource> GetById(int id)
        {
            var inventory = await _inventoryService.Get(id);
            var inventoryResource = _mapper.Map<InventoryItemDto, InventoryItemResource>(inventory);
            //inventoryResource.AddedBy.Email = (await _userManager.FindByIdAsync(inventory.AddedById))?.Email;
            //inventoryResource.EdditedByEmail = (await _userManager.FindByIdAsync(inventory.EditedById))?.Email;
            return inventoryResource;
        }

        // POST api/inventory/item
        [HttpPost]
        public async Task<IActionResult> Add(BaseInventoryItemResource inventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var inventoryDto = _mapper.Map<BaseInventoryItemResource, InventoryItemDto>(inventory);
            inventoryDto.AddedById = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _inventoryService.Add(inventoryDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            inventoryDto = result.Dto as InventoryItemDto;
            var inventoryResorce = _mapper.Map<InventoryItemDto, InventoryItemResource>(inventoryDto);
            return Ok(inventoryResorce);
        }

        // PUT api/inventory/item
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InventoryItemResource inventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var inventoryDto = _mapper.Map<InventoryItemResource, InventoryItemDto>(inventory);
            inventoryDto.EditedById = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _inventoryService.Update(id, inventoryDto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var inventoryResource = _mapper.Map<InventoryItemDto, InventoryItemResource>(result.Dto as InventoryItemDto);
            return Ok(inventoryResource);
        }

        // DELETE api/inventory/item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _inventoryService.Delete(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var inventoryResource = _mapper.Map<InventoryItemDto, InventoryItemResource>(result.Dto as InventoryItemDto);
            return Ok(inventoryResource);
        }
    }
}
