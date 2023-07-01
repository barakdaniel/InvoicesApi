using Invoices.Api.ActionFilters;
using Invoices.Business;
using Invoices.Model.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Api.Controllers.InvoicesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController
    {
        private readonly FactoryService _factoryService;

        public InvoicesController(FactoryService factoryService)
        {
            _factoryService = factoryService;
        }

        [HttpGet, ActionName("Read")]
        [TypeFilter(typeof(AuthorizationActionFilter))]
        public async Task<ActionResult<List<Invoice>>> Read([FromQuery] int id = 0)
        {
            if (id < 0) return new BadRequestObjectResult("Invalid ID");

            var invoicesLogic = _factoryService.CreateInvoicesLogic();
            return await invoicesLogic.Read(id);
        }

        [HttpPost, ActionName("Insert")]
        [TypeFilter(typeof(AuthorizationActionFilter))]
        public async Task<ActionResult<bool>> Insert([FromQuery] InvoiceInsert invoice)
        {
            if (invoice == null) return new BadRequestObjectResult("Received Empty Invoice");

            var invoicesLogic = _factoryService.CreateInvoicesLogic();
            return await invoicesLogic.Insert(invoice);
        }

        [HttpPut, ActionName("Update")]
        [TypeFilter(typeof(AuthorizationActionFilter))]
        public async Task<ActionResult<bool>> Update([FromQuery] InvoiceUpdate invoice)
        {
            if (invoice == null) return new BadRequestObjectResult("Received Empty Invoice");

            var invoicesLogic = _factoryService.CreateInvoicesLogic();
            return await invoicesLogic.Update(invoice);
        }

        [HttpDelete, ActionName("Delete")]
        [TypeFilter(typeof(AuthorizationActionFilter))]
        public async Task<ActionResult<bool>> Delete([FromQuery] int id)
        {
            if (id < 0) return new BadRequestObjectResult("Invalid ID");

            var invoicesLogic = _factoryService.CreateInvoicesLogic();
            return await invoicesLogic.Delete(id);
        }
    }
}
