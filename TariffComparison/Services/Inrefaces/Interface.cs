using System.Collections.Generic;
using TariffComparison.Models;

namespace TariffComparison.Services.Inrefaces
{
    public interface IRepository
    {
        List<TariffProductModel> GetAllTariffs();
    }
}
