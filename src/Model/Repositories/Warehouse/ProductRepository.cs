using System;
using System.Collections.Generic;
using System.Linq;
using WarelogManager.Model.DataTransfer.Warehouse;
using System.ComponentModel.DataAnnotations.Schema;
using WarelogManager.Model.Repositories.Warehouse.Interface;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarelogManager.Model.Mapping;

namespace WarelogManager.Model.Repositories.Warehouse
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int> Add(ProductDto product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<IEnumerable<ProductDto>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductDto> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(ProductDto product)
        {
            var exisitngProduct = await _context.Products
                .SingleOrDefaultAsync(x => x.Id == product.Id);

            if (exisitngProduct == null)
            {
                return false;
            }

            exisitngProduct.ArrivalTime = product.ArrivalTime;
            exisitngProduct.Depth = product.Depth;
            exisitngProduct.Description = product.Description;
            exisitngProduct.Height = product.Height;
            exisitngProduct.Id = product.Id;
            exisitngProduct.Name = product.Name;
            exisitngProduct.Pallet = product.Pallet;
            exisitngProduct.PalletId = product.PalletId;
            exisitngProduct.Picture = product.Picture;
            exisitngProduct.Priority = product.Priority;
            exisitngProduct.Weight = product.Weight;
            exisitngProduct.Width = product.Width;

            _context.Update(exisitngProduct);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> Delete(int id)
        {
            var deleted = false;
            var product = _context.Products
                .SingleOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                _context.Remove(product);
                deleted = true;
            }
            else
            {
                deleted = false;
            }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1 && deleted == true;
        }
    }
}
