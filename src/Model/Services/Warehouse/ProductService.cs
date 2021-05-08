using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Repositories.Warehouse.Interface;

namespace WarelogManager.Model.Services.Warehouse
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Add(ProductDto product)
        {
            return await _productRepository.Add(product);
        }

        public async Task<IEnumerable<ProductDto>> Get()
        {
            return await _productRepository.Get();
        }

        public async Task<ProductDto> Get(int id)
        {
            return await _productRepository.GetById(id);
        }


        public async Task<bool> Update(ProductDto product)
        {
            return await _productRepository.Update(product);
        }
    }
}
