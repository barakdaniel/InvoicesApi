using Invoices.Data.InvoicesData;
using Invoices.Model.Invoice;
using Microsoft.Extensions.Caching.Memory;

namespace Invoices.Business.InvoicesLogics
{
    public class InvoicesLogic
    {
        private readonly IMemoryCache _cache;
        private readonly int _cachingAbsoluteExpirationMinutes = 10;

        public InvoicesLogic(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<List<Invoice>> Read(int id = 0)
        {
            if (id == 0)
                return await ReadAll();
            else
            {
                Invoice invoice = await ReadById(id);
                return new List<Invoice> { invoice };
            }
        }

        public async Task<bool> Insert(InvoiceInsert invoice)
        {

            var invoiceData = new InvoiceData();
            var result = await invoiceData.Insert(invoice);

            if (result) _cache.Remove("invoices-all");

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var invoiceData = new InvoiceData();
            var result = await invoiceData.Delete(id);

            if (result)
            {
                _cache.Remove("invoices-all");
                _cache.Remove($"invoices-{id}");
            }

            return result;
        }

        public async Task<bool> Update(InvoiceUpdate invoice)
        {
            var invoiceData = new InvoiceData();
            var result = await invoiceData.Update(invoice);

            if (result)
            {
                _cache.Remove("invoices-all");
                _cache.Remove($"invoices-{invoice.Id}");
            }

            return result;
        }

        private async Task<List<Invoice>> ReadAll()
        {
            //try to fetch data from memoryCache
            string key = "invoices-all";
            List<Invoice> invoices;
            if (!_cache.TryGetValue(key, out invoices))
            {
                var invoiceData = new InvoiceData();
                invoices = (await invoiceData.ReadAll());

                //store value in memory
                if (invoices != null)
                    _cache.Set(key, invoices, TimeSpan.FromMinutes(_cachingAbsoluteExpirationMinutes));
            }

            return invoices;
        }

        private async Task<Invoice> ReadById(int id)
        {
            //try to fetch data from memoryCache
            string key = $"invoices-{id}";
            Invoice invoice;
            if (!_cache.TryGetValue(key, out invoice))
            {
                var invoiceData = new InvoiceData();
                invoice = (await invoiceData.ReadById(id));

                //store value in memory
                if (invoice != null)
                    _cache.Set(key, invoice, TimeSpan.FromMinutes(_cachingAbsoluteExpirationMinutes));
            }

            return invoice;
        }
    }
}
