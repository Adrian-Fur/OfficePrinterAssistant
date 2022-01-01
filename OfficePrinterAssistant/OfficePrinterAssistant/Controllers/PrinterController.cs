using Microsoft.AspNetCore.Mvc;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Collections.Generic;

namespace OfficePrinterAssistant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrinterController : ControllerBase
    {
        private readonly IRepository<Printer> printerRepository;

        public PrinterController(IRepository<Printer> printerRepository)
        {
            this.printerRepository = printerRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Printer> GetAllPrinters()
        {
            return this.printerRepository.GetAll();
        }

        [HttpGet]
        [Route("{printerId}")]
        public Printer GetPrinterById(int printerId)
        {
            return this.printerRepository.GetById(printerId);
        }
    }
}
