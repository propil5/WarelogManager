using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Shared.Resources.Warehouse.Product;

namespace WarelogManager.Model.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<SaveProductResource, ProductDto>();
            CreateMap<ProductResource, ProductDto>();
        }
    }
}
