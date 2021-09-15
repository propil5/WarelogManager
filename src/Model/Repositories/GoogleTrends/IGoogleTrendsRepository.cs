using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Trends;

namespace WarelogManager.Model.Repositories.GoogleTrends
{
    public interface IGoogleTrendsRepository
    {
        Task<int?> Add(GoogleTrendsDto product);
        void Delete(GoogleTrendsDto product);
        Task<IEnumerable<GoogleTrendsDto>> Get();
        Task<GoogleTrendsDto> GetById(int id);
        void Update(GoogleTrendsDto product);
    }
}
