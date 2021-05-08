using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarelogManager.Model.Repositories.Warehouse.Interface;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Extensions;
using AutoMapper;
using WarelogManager.Shared.Resources.Warehouse.Product;

namespace WarelogManager.Client.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productDao;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productDao, IMapper mapper)
        {
            _productDao = productDao;
            _mapper = mapper;
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
        public async Task<ProductDto> GetById(int id)
        {
            return  await _productDao.GetById(id);
        }

        // POST api/product
        [HttpPost]
        public async Task<ActionResult<int>> Add(SaveProductResource product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var productDto = _mapper.Map<SaveProductResource, ProductDto>(product);

            var id = await _productDao.Add(productDto);

            if(id > 0)
            {
                return Ok(id);
            }
            else
            {
                return BadRequest("There was an error while adding product.");
            }
        }

        // PUT api/product
        [HttpPut]
        public async Task<ActionResult> Update(ProductResource product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var productDto = _mapper.Map<ProductResource, ProductDto>(product);

            if(await _productDao.Update(productDto))
            {
                return Ok($"Succesfully updated product with id: {product.Id}.");
            }
            return BadRequest($"Could not update product with id: {product.Id}.");
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _productDao.Delete(id);
        }
    }
}
