using Microsoft.VisualStudio.TestTools.UnitTesting;
using TariffComparison.Services;

namespace TariffComparison.Tests
{
    [TestClass]
    public class TestRepository
    {
        private Repository _repo;

        [TestInitialize]
        public void Initialize()
        {
            _repo = new Repository();
        }

        [TestMethod]
        public void TestGetAllTariffs()
        {
            var tariffs = _repo.GetAllTariffs();

            Assert.IsTrue(tariffs.Count > 0);
        }
    }
}
