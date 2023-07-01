using Invoices.Api.ActionFilters;
using Invoices.Business;
using Invoices.Model.Status;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Api.Controllers.StatusesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController
    {
        private readonly FactoryService _factoryService;

        public StatusesController(FactoryService factoryService)
        {
            _factoryService = factoryService;
        }

        [HttpGet, ActionName("Read")]
        [TypeFilter(typeof(AuthorizationActionFilter))]
        public async Task<ActionResult<List<Status>>> Read()
        {
            var statusesLogic = _factoryService.CreateStatusesLogic();
            return await statusesLogic.Read();
        }
    }
}
