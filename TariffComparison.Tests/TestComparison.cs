using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TariffComparison.Models;
using TariffComparison.Services;
using TariffComparison.Services.Inrefaces;

namespace TariffComparison.Tests
{
    [TestClass]
    public class TestComparison
    {
        private const string PName1 = "basic electricity tariff";
        private const string PName2 = "Packaged tariff";
        
        private ComparisonService _service;
        private TariffProductModel[] _products;

        [TestInitialize]
        public void Initialize()
        {
            var mock = new Mock<IRepository>();
            _products = new[]
            {
                
                new TariffProductModel
                {
                    Name = PName1,
                    AnnualCost = 60,
                    ConsumptionCost = 0.22m,
                    ConsumptionThreshold = 0
                },
                new TariffProductModel
                {
                    Name = PName2,
                    AnnualCost = 800,
                    ConsumptionCost = 0.3m,
                    ConsumptionThreshold = 4000
                }
            };

            mock.Setup(p => p.GetAllTariffs()).Returns(_products.ToList());

            _service = new ComparisonService(mock.Object);
        }

        [DataTestMethod]  
        [DataRow(3500, 830, PName1)]
        [DataRow(4500, 1050, PName1)]
        [DataRow(6000, 1380, PName1)]
        [DataRow(3500, 800, PName2)]
        [DataRow(4500, 950, PName2)]
        [DataRow(6000, 1400, PName2)]
        public void TestAnnualConsumption(int consumption, int expected, string productName)
        {
            var product = _products.Single(p => p.Name == productName);
            Assert.AreEqual(expected, _service.GetAnnualConsumption(product, (uint)consumption));
        }

        [DataTestMethod]  
        [DataRow(PName2, PName1, 3500)]
        [DataRow(PName2, PName1, 4500)]
        [DataRow(PName1, PName2, 6000)]
        public void TestCompareTariffs(string first, string last, int consumption)
        {
            var result = _service.CompareTariffs((uint)consumption);
            Assert.IsTrue(result.First().AnnualCost <= result.Last().AnnualCost); // ASC order;
            Assert.IsTrue(result.First().Name == first && result.Last().Name == last);
        }
    }
}
