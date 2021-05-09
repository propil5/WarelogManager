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
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlantService(IPlantRepository plantRepository, IUnitOfWork unitOfWork)
        {
            _plantRepository = plantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DtoResponse> Add(PlantDto plant)
        {
            try
            {
                var id = await _plantRepository.Add(plant);
                await _unitOfWork.CompleteAsync();
                plant.Id = id ?? 0;

                return new DtoResponse(plant);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the plant do the database: {ex.Message}");
            }
        }

        public async Task<IEnumerable<PlantDto>> Get()
        {
            return await _plantRepository.Get();
        }

        public async Task<PlantDto> Get(int id)
        {
            return await _plantRepository.GetById(id);
        }

        public async Task<DtoResponse> Update(int id, PlantDto plant)
        {
            var existingPlant = await _plantRepository.GetById(id);

            if (existingPlant == null)
            {
                return new DtoResponse($"Could not find plant to update with id:{id}.");
            }

            try
            {
                _plantRepository.Update(plant);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(plant);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the plant: {ex.Message}");
            }
        }

        public async Task<DtoResponse> Delete(int id)
        {
            var existingCompany = await _plantRepository.GetById(id);

            if (existingCompany == null)
            {
                return new DtoResponse($"Could not find plant to update with id: {id}.");
            }

            try
            {
                _plantRepository.Delete(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(existingCompany);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when deleting plant. {ex.Message}");
            }
        }
    }
}
