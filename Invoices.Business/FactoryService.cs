using Invoices.Business.InvoicesLogics;
using Invoices.Business.StatusesLogics;
using Microsoft.Extensions.Caching.Memory;

namespace Invoices.Business
{
    public class FactoryService
    {
        private readonly IMemoryCache _cache;

        public FactoryService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public InvoicesLogic CreateInvoicesLogic()
        {
            return new InvoicesLogic(_cache);
        }

        public StatusesLogic CreateStatusesLogic()
        {
            return new StatusesLogic(_cache);
        }
    }
}
