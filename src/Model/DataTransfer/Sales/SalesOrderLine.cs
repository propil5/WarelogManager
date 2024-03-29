﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.DataTransfer.Sales
{
    [Table("SalesOrderLine")]
    public class SalesOrderLineDto : BaseEntity
    {
        public int? SalesOrderId { get; set; }
        public SalesOrderDto SalesOrder { get; set; }
        public int Quantity { get; set; }
        public int? Discount { get; set; }
        public double TotalPrice { get; set; }
        public double SalesTax { get; set; }
        public int? InventoryItemId { get; set; }
        public InventoryItemDto InventoryItem { get; set; }
    }
}
