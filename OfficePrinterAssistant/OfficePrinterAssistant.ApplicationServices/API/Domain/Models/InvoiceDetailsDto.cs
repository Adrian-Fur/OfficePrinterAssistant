namespace OfficePrinterAssistant.ApplicationServices.API.Domain.Models
{
    public class InvoiceDetailsDto
    {
        public int Id { get; set; }
        public decimal PrinterFee { get; set; }
        public decimal ExtensionsFee { get; set; }
        public decimal SoftwareFee { get; set; }
    }
}
