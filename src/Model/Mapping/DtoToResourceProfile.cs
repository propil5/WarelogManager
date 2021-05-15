using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Shared.Resources.Warehouse.Company;
using WarelogManager.Shared.Resources.Warehouse.Product;

namespace WarelogManager.Model.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<object, ProductDto>();
            CreateMap<BaseProductResource, ProductDto>();
            CreateMap<BaseProductResource, ProductDto>();
            CreateMap<ProductDto, ProductResource>();
            CreateMap<ProductResource, ProductDto>();
            CreateMap<CompanyResource, CompanyDto>();
            CreateMap<BaseCompanyResource, CompanyDto>();
            CreateMap<CompanyDto, CompanyResource>();
        }
    }
}
