using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataAccess;
using WarelogManager.Model.DataAccess.Warehouse;
using WarelogManager.Model.DataAccess.Warehouse.Interface;

namespace WarelogManager.Client.DataAccess
{
    [TestFixture]
    public class ProductDaoTest
    {
        private IProductDao _productDao;
        [SetUp]
        public void SetUp()
        {
            _productDao = new ProductDao(new ApplicationDbContext());
        }
    }
}
