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
    public class PalletService : IPalletService
    {
        private readonly IPalletRepository _palletRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PalletService(IPalletRepository palletRepository, IUnitOfWork unitOfWork)
        {
            _palletRepository = palletRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DtoResponse> Add(PalletDto pallet)
        {
            try
            {
                var id = await _palletRepository.Add(pallet);
                pallet.Id = id ?? 0;

                return new DtoResponse(pallet);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the pallet do the database: {ex.Message}");
            }
        }

        public async Task<IEnumerable<PalletDto>> Get()
        {
            return await _palletRepository.Get();
        }

        public async Task<PalletDto> Get(int id)
        {
            return await _palletRepository.GetById(id);
        }

        public async Task<DtoResponse> Update(int id, PalletDto pallet)
        {
            var existingPallet = await _palletRepository.GetById(id);

            if (existingPallet == null)
            {
                return new DtoResponse($"Could not find pallet to update with id:{id}.");
            }

            try
            {
                _palletRepository.Update(pallet);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(pallet);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the pallet: {ex.Message}");
            }
        }

        public async Task<DtoResponse> Delete(int id)
        {
            var existingCompany = await _palletRepository.GetById(id);

            if (existingCompany == null)
            {
                return new DtoResponse($"Could not find pallet to update with id: {id}.");
            }

            try
            {
                _palletRepository.Delete(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(existingCompany);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when deleting pallet. {ex.Message}");
            }
        }
    }
}
