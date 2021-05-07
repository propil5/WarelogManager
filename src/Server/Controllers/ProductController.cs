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
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductDao _productDao;

        public ProductController(IProductDao productDao)
        {
            _productDao = productDao;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
        {
            var products = await _productDao.Get();
            return products;
        }

        [HttpGet("{id:int}")]
        public ProductDto GetById(int id)
        {
            return _productDao.GetById(id);
        }

        [HttpPost]
        public ActionResult<int> Add(ProductDto productDto)
        {
            var id = _productDao.Add(productDto);
            if(id > 0)
            {
                return Ok(id);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public bool Update(ProductDto productDto)
        {
            return _productDao.Update(productDto);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _productDao.Delete(id);
        }
    }
}
