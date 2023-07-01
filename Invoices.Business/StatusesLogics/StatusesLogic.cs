using Invoices.Data.StatusesData;
using Invoices.Model.Status;
using Microsoft.Extensions.Caching.Memory;

namespace Invoices.Business.StatusesLogics
{
    public class StatusesLogic
    {
        private readonly IMemoryCache _cache;
        private readonly int _cachingAbsoluteExpirationMinutes = 10;

        public StatusesLogic(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<List<Status>> Read()
        {
            //try to fetch data from memoryCache
            string key = "statuses-all";
            List<Status> statuses;
            if (!_cache.TryGetValue(key, out statuses))
            {
                var statusData = new StatusData();
                statuses = (await statusData.ReadAll());

                //store value in memory
                if (statuses != null)
                    _cache.Set(key, statuses, TimeSpan.FromMinutes(_cachingAbsoluteExpirationMinutes));
            }

            return statuses;
        }
    }
}
