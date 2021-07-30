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

        public async Task<int?> Add(ProductDto product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<IEnumerable<ProductDto>> Get()
        {
            return await _context.Products
                .Include(m => m.AddedBy)
                .Include(m => m.EditedBy)
                .Include(m => m.Pallet)
                .Include(m => m.InventoryItems)
                .ThenInclude(m => m.Images)
                .ToListAsync();
        }

        public async Task<ProductDto> GetById(int id)
        {
            return await _context.Products
                .FindAsync(id);
        }

        public void Update(ProductDto product)
        {
            _context.Update(product);
        }

        public void Delete(ProductDto product)
        {
            _context.Products.Remove(product);
        }
    }
}
