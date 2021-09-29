using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarelogManager.Client.Resources.Employee;
using WarelogManager.Model.DataTransfer.Employee;
using WarelogManager.Model.Extensions;
using WarelogManager.Model.Services.Employee.Interface;

namespace WarelogManager.Client.Controllers.Employee
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET api/employee
        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> Get()
        {
            var employees = await _employeeService.Get();
            return employees;
        }

        // GET api/employee/5
        [HttpGet("{id:int}")]
        public async Task<EmployeeDto> GetById(int id)
        {
            return await _employeeService.Get(id);
        }

        // POST api/employee
        [HttpPost]
        public async Task<IActionResult> Add(BaseEmployeeResource employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employeeDto = _mapper.Map<BaseEmployeeResource, EmployeeDto>(employee);
            var result = await _employeeService.Add(employeeDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var employeeResorce = _mapper.Map<EmployeeDto, EmployeeResource>(result.Dto as EmployeeDto);
            return Ok(employeeResorce);
        }

        // PUT api/employee
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeResource employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employeeDto = _mapper.Map<EmployeeResource, EmployeeDto>(employee);
            var result = await _employeeService.Update(id, employeeDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var employeeResource = _mapper.Map<EmployeeDto, EmployeeResource>(result.Dto as EmployeeDto);
            return Ok(employeeResource);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var employeeResource = _mapper.Map<EmployeeDto, EmployeeResource>(result.Dto as EmployeeDto);
            return Ok(employeeResource);
        }
    }
}
