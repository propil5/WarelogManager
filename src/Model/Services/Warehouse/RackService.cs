using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Repositories.UnitOfWork;
using WarelogManager.Model.Repositories.Warehouse.Interface;
using WarelogManager.Model.Services.Warehouse.Interface;

namespace WarelogManager.Model.Services.Warehouse
{
    public class RackService : IRackService
    {
        private readonly IRackRepository _rackRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RackService(IRackRepository rackRepository, IUnitOfWork unitOfWork)
        {
            _rackRepository = rackRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DtoResponse> Add(RackDto rack)
        {
            try
            {
                var id = await _rackRepository.Add(rack);
                rack.Id = id ?? 0;

                return new DtoResponse(rack);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the rack do the database: {ex.Message}");
            }
        }

        public async Task<IEnumerable<RackDto>> Get()
        {
            return await _rackRepository.Get();
        }

        public async Task<RackDto> Get(int id)
        {
            return await _rackRepository.GetById(id);
        }

        public async Task<DtoResponse> Update(int id, RackDto rack)
        {
            var existingRack = await _rackRepository.GetById(id);

            if (existingRack == null)
            {
                return new DtoResponse($"Could not find rack to update with id:{id}.");
            }

            try
            {
                _rackRepository.Update(rack);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(rack);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the rack: {ex.Message}");
            }
        }

        public async Task<DtoResponse> Delete(int id)
        {
            var existingCompany = await _rackRepository.GetById(id);

            if (existingCompany == null)
            {
                return new DtoResponse($"Could not find rack to update with id: {id}.");
            }

            try
            {
                _rackRepository.Delete(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(existingCompany);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when deleting rack. {ex.Message}");
            }
        }
    }
}
