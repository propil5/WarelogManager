using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarelogManager.Client.Resources.Warehouse.Pallet;
using WarelogManager.Client.Warehouse;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Extensions;
using WarelogManager.Model.Services.Warehouse.Interface;

namespace WarelogManager.Client.Controllers.Warehouse
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalletController : ControllerBase
    {
        private readonly IPalletService _palletService;
        private readonly IMapper _mapper;

        public PalletController(IPalletService palletService, IMapper mapper)
        {
            _palletService = palletService;
            _mapper = mapper;
        }

        // GET api/pallet
        [HttpGet]
        public async Task<IEnumerable<PalletDto>> Get()
        {
            var pallets = await _palletService.Get();
            return pallets;
        }

        // GET api/pallet/5
        [HttpGet("{id:int}")]
        public async Task<PalletDto> GetById(int id)
        {
            return await _palletService.Get(id);
        }

        // POST api/pallet
        [HttpPost]
        public async Task<IActionResult> Add(BasePalletResource pallet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var palletDto = _mapper.Map<BasePalletResource, PalletDto>(pallet);
            var result = await _palletService.Add(palletDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var palletResorce = _mapper.Map<PalletDto, PalletResource>(result.Dto as PalletDto);
            return Ok(palletResorce);
        }

        // PUT api/pallet
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PalletResource pallet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var palletDto = _mapper.Map<PalletResource, PalletDto>(pallet);
            var result = await _palletService.Update(id, palletDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var palletResource = _mapper.Map<PalletDto, PalletResource>(result.Dto as PalletDto);
            return Ok(palletResource);
        }

        // DELETE api/pallet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _palletService.Delete(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var palletResource = _mapper.Map<PalletDto, PalletResource>(result.Dto as PalletDto);
            return Ok(palletResource);
        }
    }
}
