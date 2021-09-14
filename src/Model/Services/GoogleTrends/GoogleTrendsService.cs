using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Repositories.GoogleTrends;
using WarelogManager.Model.Repositories.Warehouse.Interface;
using WarelogManager.Model.Services.Warehouse.Interface;

namespace WarelogManager.Model.Services.GoogleTrends
{
    public class GoogleTrendsService : IGoogleTrendsService
    {
        private readonly IProductRepository _productRepository;
        private readonly IGoogleTrendsRepository _googleTrendsRepository;

        public GoogleTrendsService(IProductRepository productRepository, IGoogleTrendsRepository googleTrendsRepository)
        {
            _productRepository = productRepository;
            _googleTrendsRepository = googleTrendsRepository;
        }

        public async void UpdateTrendsData()
        {
            var pythonEngine = Python.CreateEngine();
            var currentDir = Directory.GetCurrentDirectory();
            var googleTrendsScriptPath = Path.Combine(currentDir, "Scripts\\GoogleTrendingOverTime.py");
            //var products = await _productRepository.Get();
            var products = new List<ProductDto>(){new ProductDto
            {
                Name = "Xmas tree"
            }};

            foreach (var product in products.Select(x => x.Name))
            {
                var data = pythonEngine.ExecuteFile(googleTrendsScriptPath);
            }
        }
    }
}
