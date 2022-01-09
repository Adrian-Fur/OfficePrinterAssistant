using System.Collections.Generic;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.Models
{
    public class PrinterDto
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public int Counter { get; set; }
        public int CounterBlack { get; set; }
        public int ConterColor { get; set; }
        public decimal MonthlyFee { get; set; }
        public List<ExtensionDto> ExtensionsList { get; set; }
        public List<SoftwareDto> SoftwaresList { get; set; }

    }
}
