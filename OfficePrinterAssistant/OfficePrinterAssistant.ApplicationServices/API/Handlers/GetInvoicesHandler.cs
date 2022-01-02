using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.DataAccess;
using OfficePrinterAssistant.DataAccess.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Handlers
{
    public class GetInvoicesHandler : IRequestHandler<GetInvoicesRequest, GetInvoicesResponse>
    {
        private readonly IRepository<Invoice> invoiceRepository;

        public GetInvoicesHandler(IRepository<Invoice> invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }
        public Task<GetInvoicesResponse> Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
        {
            var invoices = this.invoiceRepository.GetAll();

            var domainInvoices = invoices.Select(x => new Domain.Models.Invoice()
            {
                Id = x.Id,
                CreateDate = x.CreateDate,
                PaymentDate = x.PaymentDate,
                PaymentMethod = x.PaymentMethod,
            });

            var response = new GetInvoicesResponse()
            {
                Data = domainInvoices.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
