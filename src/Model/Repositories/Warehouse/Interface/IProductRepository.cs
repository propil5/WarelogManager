﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Repositories.Warehouse.Interface
{
    public interface IProductRepository
    {
        int Add(ProductDto product);
        bool Delete(int id);
        Task<IEnumerable<ProductDto>> Get();
        ProductDto GetById(int id);
        bool Update(ProductDto product);
    }
}