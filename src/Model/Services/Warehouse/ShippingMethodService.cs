using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Shipping;
using WarelogManager.Model.Repositories.ShippingMethod;
using WarelogManager.Model.Repositories.UnitOfWork;
using WarelogManager.Model.Repositories.Warehouse.Interface;
using WarelogManager.Model.Services.Warehouse.Interface;

namespace WarelogManager.Model.Services.Warehouse
{
    public class ShippingMethodService : IShippingMethodService
    {
        private readonly IShippingMethodRepository _shippingMethodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ShippingMethodService(IShippingMethodRepository shippingMethodRepository, IUnitOfWork unitOfWork)
        {
            _shippingMethodRepository = shippingMethodRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DtoResponse> Add(ShippingMethodDto pshippingMethod)
        {
            try
            {
                var id = await _shippingMethodRepository.Add(pshippingMethod);
                return new DtoResponse(pshippingMethod);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the pshippingMethod do the database: {ex.Message}");
            }
        }

        public async Task<IEnumerable<ShippingMethodDto>> Get()
        {
            return await _shippingMethodRepository.Get();
        }

        public async Task<ShippingMethodDto> Get(int id)
        {
            return await _shippingMethodRepository.GetById(id);
        }

        public async Task<DtoResponse> Update(int id, ShippingMethodDto pshippingMethod)
        {
            var existingShippingMethod = await _shippingMethodRepository.GetById(id);

            if (existingShippingMethod == null)
            {
                return new DtoResponse($"Could not find pshippingMethod to update with id:{id}.");
            }

            try
            {
                _shippingMethodRepository.Update(pshippingMethod);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(pshippingMethod);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the pshippingMethod: {ex.Message}");
            }
        }

        public async Task<DtoResponse> Delete(int id)
        {
            var existingCompany = await _shippingMethodRepository.GetById(id);

            if (existingCompany == null)
            {
                return new DtoResponse($"Could not find pshippingMethod to update with id: {id}.");
            }

            try
            {
                _shippingMethodRepository.Delete(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(existingCompany);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when deleting pshippingMethod. {ex.Message}");
            }
        }
    }
}
