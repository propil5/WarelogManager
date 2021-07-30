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
using WarelogManager.Model.Services.Warehouse.Interface;
using WarelogManager.Model.DataTransfer.Common;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WarelogManager.Client.Controllers.Warehouse
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductController(IProductService productService, IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _productService = productService;
            _mapper = mapper;
        }

        // GET api/product
        [HttpGet]
        public async Task<IEnumerable<ProductResource>> Get()
        {
            var products = await _productService.Get();
            var productResources = _mapper.Map<List<ProductDto>, List<ProductResource>>(products.ToList());

            return productResources;
        }

        // GET api/product/5
        [HttpGet("{id:int}")]
        public async Task<ProductResource> GetById(int id)
        {
            var product = await _productService.Get(id);
            var productResource = _mapper.Map<ProductDto, ProductResource>(product);
            return productResource;
        }

        // POST api/product
        [HttpPost]
        public async Task<IActionResult> Add(BaseProductResource product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var productDto = _mapper.Map<BaseProductResource, ProductDto>(product);
            productDto.AddedById = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _productService.Add(productDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            productDto = result.Dto as ProductDto;
            var productResorce = _mapper.Map<ProductDto, ProductResource>(productDto);
            return Ok(productResorce);
        }

        // PUT api/product
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductResource product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var productDto = _mapper.Map<ProductResource, ProductDto>(product);
            productDto.EditedById = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _productService.Update(id, productDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var productResource = _mapper.Map<ProductDto, ProductResource>(result.Dto as ProductDto);
            return Ok(productResource);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var productResource = _mapper.Map<ProductDto, ProductResource>(result.Dto as ProductDto);
            return Ok(productResource);
        }
    }
}
