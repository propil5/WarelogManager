using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Client.Resources.Common;
using WarelogManager.Client.Resources.Sales;
using WarelogManager.Client.Resources.Warehouse.Identity;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.Sales;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Shared.Resources.Warehouse.Company;
using WarelogManager.Shared.Resources.Warehouse.InventoryItem;
using WarelogManager.Shared.Resources.Warehouse.Product;

namespace WarelogManager.Model.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            //CreateMap<object, ProductDto>();
            CreateMap<BaseProductResource, ProductDto>();
            CreateMap<ProductResource, ProductDto>();
            CreateMap<ProductDto, ProductResource>();

            CreateMap<CompanyResource, CompanyDto>();
            CreateMap<BaseCompanyResource, CompanyDto>();
            CreateMap<CompanyDto, CompanyResource>();

            CreateMap<InventoryItemResource, InventoryItemDto>();
            CreateMap<BaseInventoryItemResource, InventoryItemDto>();
            CreateMap<InventoryItemDto, BaseInventoryItemResource>();
            CreateMap<InventoryItemDto, InventoryItemResource>();
            CreateMap<BaseImageResource, InventoryItemImageDto>();
            CreateMap<InventoryItemImageDto, BaseImageResource>();
            CreateMap<ApplicationUser, UserResource>();

            //Sales
            CreateMap<BasketItemDto, BaseBasketItemResource>();
            CreateMap<BaseBasketItemResource, BasketItemDto>();
            CreateMap<BasketItemDto, BasketItemResource>();
            CreateMap<BasketItemResource, BasketItemDto>();
            CreateMap<PurchaseOrderDto, PurchaseOrderResource>();
            CreateMap<PurchaseOrderResource, PurchaseOrderDto>();
            //CreateMap<InventoryItemImageDto, BaseImageResource>();
        }
    }
}
