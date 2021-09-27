using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarelogManager.Client.Resources.Inbound;
using WarelogManager.Model.DataTransfer.Inbound;
using WarelogManager.Model.Extensions;
using WarelogManager.Model.Services.Inbound;

namespace WarelogManager.Client.Controllers.Inbound
{

    [Route("api/transport/incoming")]
    [ApiController]
    public class IncomingTransportController : ControllerBase
    {
        private readonly IIncomingTransportService _incomingTransportService;
        private readonly IMapper _mapper;

        public IncomingTransportController(IIncomingTransportService incomingTransportService, IMapper mapper)
        {
            _incomingTransportService = incomingTransportService;
            _mapper = mapper;
        }

        // GET api/incomingTransport
        [HttpGet]
        public async Task<IEnumerable<IncomingTransportDto>> Get()
        {
            var incomingTransports = await _incomingTransportService.Get();
            return incomingTransports;
        }

        // GET api/incomingTransport/5
        [HttpGet("{id:int}")]
        public async Task<IncomingTransportDto> GetById(int id)
        {
            return await _incomingTransportService.Get(id);
        }

        // POST api/incomingTransport
        [HttpPost]
        public async Task<IActionResult> Add(BaseIncomingTransportResource incomingTransport)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var incomingTransportDto = _mapper.Map<BaseIncomingTransportResource, IncomingTransportDto>(incomingTransport);
            var result = await _incomingTransportService.Add(incomingTransportDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var incomingTransportResorce = _mapper.Map<IncomingTransportDto, IncomingTransportResource>(result.Dto as IncomingTransportDto);
            return Ok(incomingTransportResorce);
        }

        // PUT api/incomingTransport
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] IncomingTransportResource incomingTransport)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var incomingTransportDto = _mapper.Map<IncomingTransportResource, IncomingTransportDto>(incomingTransport);
            var result = await _incomingTransportService.Update(id, incomingTransportDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var incomingTransportResource = _mapper.Map<IncomingTransportDto, IncomingTransportResource>(result.Dto as IncomingTransportDto);
            return Ok(incomingTransportResource);
        }

        // DELETE api/incomingTransport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _incomingTransportService.Delete(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var incomingTransportResource = _mapper.Map<IncomingTransportDto, IncomingTransportResource>(result.Dto as IncomingTransportDto);
            return Ok(incomingTransportResource);
        }
    }
}
