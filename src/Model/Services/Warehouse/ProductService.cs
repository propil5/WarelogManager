using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Repositories.UnitOfWork;
using WarelogManager.Model.Repositories.Warehouse.Interface;
using WarelogManager.Model.Services.Warehouse.Interface;

namespace WarelogManager.Model.Services.Warehouse
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DtoResponse> Add(ProductDto product)
        {
            try
            {
                product.AddedDate = DateTime.Now;
                var id = await _productRepository.Add(product);
                product.Id = id ?? 0;

                return new DtoResponse(product);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the product do the database: {ex.Message}");
            }
        }

        public async Task<IEnumerable<ProductDto>> Get()
        {
            return await _productRepository.Get();
        }

        public async Task<ProductDto> Get(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<DtoResponse> Update(int id, ProductDto product)
        {
            var existingProduct = await _productRepository.GetById(id);

            if (existingProduct == null)
            {
                return new DtoResponse($"Could not find product to update with id:{id}.");
            }

            existingProduct.ArrivalTime = product.ArrivalTime;
            existingProduct.Depth = product.Depth;
            existingProduct.Description = product.Description;
            existingProduct.Height = product.Height;
            existingProduct.Id = product.Id; 
            existingProduct.Name = product.Name;
            existingProduct.Pallet = product.Pallet;
            existingProduct.PalletId = product.PalletId;
            existingProduct.Picture = product.Picture;
            existingProduct.Priority = product.Priority;
            existingProduct.Weight = product.Weight;
            existingProduct.Width = product.Width;
            existingProduct.EditedDate = DateTime.Now;
            existingProduct.EditedBy = product.EditedBy;

            try
            {
                _productRepository.Update(product);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(product);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when saving the product: {ex.Message}");
            }
        }

        public async Task<DtoResponse> Delete(int id)
        {
            var existingCompany = await _productRepository.GetById(id);

            if (existingCompany == null)
            {
                return new DtoResponse($"Could not find product to update with id: {id}.");
            }

            try
            {
                _productRepository.Delete(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new DtoResponse(existingCompany);
            }
            catch (Exception ex)
            {
                return new DtoResponse($"An error occurred when deleting product. {ex.Message}");
            }
        }
    }
}
