using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarelogManager.Client.Resources;
using WarelogManager.Client.Resources.Warehouse.Company;
using WarelogManager.Client.Warehouse.Company;
using WarelogManager.Model.Common.Queries;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Extensions;
using WarelogManager.Model.Services.Warehouse.Interface;

namespace WarelogManager.Client.Controllers.Warehouse
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        // GET api/company
        [HttpGet]
        public async Task<IEnumerable<CompanyResource>> Get()
        {
            var queryResult = await _companyService.Get();
            var resource = _mapper.Map<IEnumerable<CompanyDto>, IEnumerable<CompanyResource>>(queryResult);
            return resource;
        }

        // GET api/company/5
        [HttpGet("{id:int}")]
        public async Task<CompanyResource> GetById(int id)
        {
            var queryResult = await _companyService.Get(id);
            return _mapper.Map<CompanyDto, CompanyResource>(queryResult);
        }

        // POST api/company
        [HttpPost]
        public async Task<IActionResult> Add(BaseCompanyResource company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var companyDto = _mapper.Map<BaseCompanyResource, CompanyDto>(company);
            var result = await _companyService.Add(companyDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var companyResorce = _mapper.Map<CompanyDto, CompanyResource>(result.Dto as CompanyDto);
            return Ok(companyResorce);
        }

        // PUT api/company
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CompanyResource company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var companyDto = _mapper.Map<CompanyResource, CompanyDto>(company);
            var result = await _companyService.Update(id, companyDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var companyResource = _mapper.Map<CompanyDto, CompanyResource>(result.Dto as CompanyDto);
            return Ok(companyResource);
        }

        // DELETE api/company/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _companyService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var companyResource = _mapper.Map<CompanyDto, CompanyResource>(result.Dto as CompanyDto);
            return Ok(companyResource);
        }
    }
}
