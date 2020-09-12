using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TariffComparison.Models;
using TariffComparison.Services.Inrefaces;

namespace TariffComparison.Services
{
    public class Repository : IRepository
    {
        public List<TariffProductModel> GetAllTariffs()
        {
            using StreamReader r = new StreamReader("data\\tariffData.json");
            string json = r.ReadToEnd();
            var items = JsonConvert.DeserializeObject<List<TariffProductModel>>(json);

            return items;
        }
    }
}
