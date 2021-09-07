using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Repositories.Warehouse.Interface;

namespace WarelogManager.Model.Services.Shop
{
    public class ShopProductsService
    {
        public readonly IProductRepository _productRepository;
        public ShopProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        //public IDictionary<ProductDto, List<SalesOrder>> GetProducts()
        //{
        //    //_productRepository.Pr
        //}
    }
}
