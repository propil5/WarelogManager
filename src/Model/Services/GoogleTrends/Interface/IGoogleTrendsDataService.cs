using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Trends;

namespace WarelogManager.Model.Services.GoogleTrends
{
    public interface IGoogleTrendsDataService
    {
        Task<DtoResponse> Add(GoogleTrendsDto GoogleTrends);
        Task<DtoResponse> DeleteAsync(int id);
        Task<IEnumerable<GoogleTrendsDto>> Get();
        Task<GoogleTrendsDto> Get(int id);
        Task<DtoResponse> Update(int id, GoogleTrendsDto GoogleTrends);
    }
}
