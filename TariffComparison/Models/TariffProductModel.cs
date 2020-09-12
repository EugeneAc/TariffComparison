namespace TariffComparison.Models
{
    public class TariffProductModel : TariffModel
    {
        public decimal ConsumptionCost { get; set; }

        public decimal ConsumptionThreshold { get; set; }
    }
}
