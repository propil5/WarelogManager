using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Repositories.Employee.Interface;
using WarelogManager.Model.Repositories.UnitOfWork;

namespace WarelogManager.Model.Services.Employee
{
    public class EmployeeService : IEmployeeService, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DtoResponse> Add(EmployeeDto employee)
        {
            try
            {
                if (await _employeeRepository.Add(employee))
                {
                    await _unitOfWork.CompleteAsync();
                    return new DtoResponse(employee);
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

        public async Task<IEnumerable<EmployeeDto>> Get()
        {
            return await _employeeRepository.Get();
        }

        public async Task<IEnumerable<EmployeeDto>> GetUserEmployees(string userId)
        {
            return await _employeeRepository.Get(userId);
        }

        public async Task<EmployeeDto> Get(int id)
        {
            return await _employeeRepository.Get(id);
        }

        public async Task<DtoResponse> Update(int id, EmployeeDto employee)
        {
            var existingEmployee = await _employeeRepository.Get(id);

            if (existingEmployee == null)
            {
                return new DtoResponse($"Could not find employee to update with id:{id}.");
            }
            try
            {
                _employeeRepository.Update(employee);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(employee);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the employee: {ex.Message}");
            }
        }

        public async Task<DtoResponse> ApplyPatch(int id, JsonPatchDocument<BaseEmployeeResource> employeePatchResource)
        {
            var existingEmployee = await _employeeRepository.Get(id);

            if (existingEmployee == null)
            {
                return new DtoResponse($"Could not find employee to apply patch for basket item with id:{id}.");
            }

            try
            {
                var employeeEntity = await _employeeRepository.Get(id);
                var employeeToPatch = _mapper.Map<BaseEmployeeResource>(employeeEntity);
                employeePatchResource.ApplyTo(employeeToPatch);
                _mapper.Map(employeeToPatch, employeeEntity);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(employeeEntity);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the employee: {ex.Message}");
            }
        }

        public async Task<DtoResponse> DeleteAsync(int id)
        {
            var existingEmployee = await _employeeRepository.Get(id);

            if (existingEmployee == null)
            {
                return new DtoResponse($"Could not find employee to update with id: {id}.");
            }

            try
            {
                _employeeRepository.Delete(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(existingEmployee);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when deleting employee. {ex.Message}");
            }
        }
    }
}
