using System;
using System.Collections.Generic;
using System.Linq;
using WarelogManager.Model.DataTransfer.Warehouse;
using System.ComponentModel.DataAnnotations.Schema;
using WarelogManager.Model.DataAccess.Warehouse.Interface;

namespace WarelogManager.Model.DataAccess.Warehouse
{
    public class ProductDao : IProductDao
    {
        private readonly ApplicationDbContext _context = null;

        public ProductDao(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(ProductDto product)
        {
            _context.Products.Add(product);
            var saveResult = _context.SaveChanges();
            return saveResult == 1;
        }

        public IEnumerable<ProductDto> Get()
        {
            return _context.Products;
        }

        public IEnumerable<ProductDto> GetById(int id)
        {
            return _context.Products.Where(x => x.Id == id);
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
