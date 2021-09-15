using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Trends;
using WarelogManager.Model.Repositories.GoogleTrends;
using WarelogManager.Model.Repositories.UnitOfWork;

namespace WarelogManager.Model.Services.GoogleTrends
{
    public class GoogleTrendsDataService : IGoogleTrendsDataService
    {
        private readonly IGoogleTrendsRepository _googleTrendsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GoogleTrendsDataService(IGoogleTrendsRepository GoogleTrendsRepository, IUnitOfWork unitOfWork)
        {
            _googleTrendsRepository = GoogleTrendsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DtoResponse> Add(GoogleTrendsDto GoogleTrends)
        {
            try
            {
                if (await _googleTrendsRepository.Add(GoogleTrends) > 0)
                {
                    await _unitOfWork.CompleteAsync();
                    return new DtoResponse(GoogleTrends);
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

        public async Task<IEnumerable<GoogleTrendsDto>> Get()
        {
            return await _googleTrendsRepository.Get();
        }

        public async Task<GoogleTrendsDto> Get(int id)
        {
            return await _googleTrendsRepository.GetById(id);
        }

        public async Task<DtoResponse> Update(int id, GoogleTrendsDto GoogleTrends)
        {
            var existingGoogleTrends = await _googleTrendsRepository.GetById(id);

            if (existingGoogleTrends == null)
            {
                return new DtoResponse($"Could not find GoogleTrends to update with id:{id}.");
            }
            try
            {
                _googleTrendsRepository.Update(GoogleTrends);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(GoogleTrends);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the GoogleTrends: {ex.Message}");
            }
        }

        public async Task<DtoResponse> DeleteAsync(int id)
        {
            var existingGoogleTrends = await _googleTrendsRepository.GetById(id);

            if (existingGoogleTrends == null)
            {
                return new DtoResponse($"Could not find GoogleTrends to update with id: {id}.");
            }

            try
            {
                _googleTrendsRepository.Delete(existingGoogleTrends);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(existingGoogleTrends);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when deleting GoogleTrends. {ex.Message}");
            }
        }
    }
}

