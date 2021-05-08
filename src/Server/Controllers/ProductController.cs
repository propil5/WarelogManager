using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarelogManager.Model.Repositories.Warehouse.Interface;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Client.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productDao;

        public ProductController(IProductRepository productDao)
        {
            _productDao = productDao;
        }

        // GET api/product
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
        {
            var products = await _productDao.Get();
            return products;
        }

        // GET api/product/5
        [HttpGet("{id:int}")]
        public ProductDto GetById(int id)
        {
            return _productDao.GetById(id);
        }

        // POST api/product
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

        // PUT api/product
        [HttpPut]
        public bool Update(ProductDto productDto)
        {
            return _productDao.Update(productDto);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _productDao.Delete(id);
        }
    }
}
