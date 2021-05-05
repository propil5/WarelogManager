using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarelogManager.Model.DataAccess.Warehouse.Interface;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Client.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductDao _productDao;

        public ProductController(IProductDao productDao)
        {
            _productDao = productDao;
        }

        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            return _productDao.Get();
        }

        [HttpPost]
        public bool Add(ProductDto productDto)
        {
            _productDao.Add(productDto);
            return true;
        }
    }
}
