using System.Collections.Generic;
using System.Linq;
using TariffComparison.Models;
using TariffComparison.Services.Inrefaces;

namespace TariffComparison.Services
{
    public class ComparisonService
    {
        private readonly IRepository _repository;

        public ComparisonService(IRepository repo)
        {
            _repository = repo;
        }

        public List<TariffModel> CompareTariffs(uint consumption)
        {
            var tariffs = _repository.GetAllTariffs();
            var result = new List<TariffModel>();
            foreach (var tariff in tariffs)
            {
                var tariffConsumption = GetAnnualConsumption(tariff, consumption);
                result.Add(new TariffModel
                {
                    Name = tariff.Name,
                    AnnualCost = tariffConsumption
                });
            }

            return result.OrderBy(t => t.AnnualCost).ToList();
        }

        public decimal GetAnnualConsumption(TariffProductModel tariff, uint consumption)
        {
            var billableConsumption = consumption - tariff.ConsumptionThreshold;
            if (billableConsumption < 0)
            {
                billableConsumption = 0;
            }

            var c = tariff.AnnualCost + (tariff.ConsumptionCost * billableConsumption);
            return c;
        }
    }
}
