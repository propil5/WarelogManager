using System;
using System.Collections.Generic;
using System.Linq;
using WarelogManager.Model.DataTransfer.Warehouse;
using System.ComponentModel.DataAnnotations.Schema;
using WarelogManager.Model.DataAccess.Warehouse.Interface;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WarelogManager.Model.DataAccess.Warehouse
{
    public class ProductDao : IProductDao
    {
        private readonly ApplicationDbContext _context;

        public ProductDao(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(ProductDto product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public async Task<IEnumerable<ProductDto>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public ProductDto GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public bool Update(ProductDto product)
        {
            var exisitngProduct = _context.Products
                .Where(x => x.Id == product.Id)
                .SingleOrDefault();


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
            var saveResult = _context.SaveChanges();
            return saveResult == 1;
        }

        public bool Delete(int id)
        {
            var deleted = false;
            var product = _context.Products
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (product != null)
            {
                _context.Remove(product);
                deleted = true;
            }
            else
            {
                deleted = false;
            }

            var saveResult = _context.SaveChanges();
            return saveResult == 1 && deleted == true;
        }
    }
}
