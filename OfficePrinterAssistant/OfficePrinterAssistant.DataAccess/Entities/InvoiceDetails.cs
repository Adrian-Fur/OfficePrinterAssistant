namespace OfficePrinterAssistant.DataAccess.Entities
{
    public class InvoiceDetails : EntityBase
    {
        public decimal PrinterFee { get; set; }
        public decimal ExtensionsFee { get; set; }
        public decimal SoftwareFee { get; set; }
        public int InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
