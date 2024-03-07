using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using CerZen.MultiTenancy.Accounting;
using CerZen.Web.Areas.WebApp.Models.Accounting;
using CerZen.Web.Controllers;

namespace CerZen.Web.Areas.WebApp.Controllers
{
    [Area("WebApp")]
    public class InvoiceController : CerZenControllerBase
    {
        private readonly IInvoiceAppService _invoiceAppService;

        public InvoiceController(IInvoiceAppService invoiceAppService)
        {
            _invoiceAppService = invoiceAppService;
        }


        [HttpGet]
        public async Task<ActionResult> Index(long paymentId)
        {
            var invoice = await _invoiceAppService.GetInvoiceInfo(new EntityDto<long>(paymentId));
            var model = new InvoiceViewModel
            {
                Invoice = invoice
            };

            return View(model);
        }
    }
}