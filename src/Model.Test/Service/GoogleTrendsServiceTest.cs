using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Repositories.GoogleTrends;
using WarelogManager.Model.Repositories.Warehouse;
using WarelogManager.Model.Repositories.Warehouse.Interface;
using WarelogManager.Model.Services.GoogleTrends;
using WarelogManager.Model.Services.Helpers;

namespace WarelogManager.Client.Service
{
    [TestFixture]
    public class GoogleTrendsServiceTest
    {
        private IGoogleTrendsService _googleTrendsService;

        [SetUp]
        public void SetUp()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            var mockGoogleRepository = new Mock<IGoogleTrendsRepository>();

            _googleTrendsService = new GoogleTrendsService(mockProductRepository.Object, mockGoogleRepository.Object, new PythonEngineService());
        }

        [Test]
        public void CanGetTrendsData()
        {
            _googleTrendsService.UpdateTrendsData();
            Assert.IsTrue(true);
        }
    }
}
