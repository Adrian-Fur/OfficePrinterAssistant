using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfficePrinterAssistant.DataAccess.Entities
{
    public class User : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        public int TaxNumber { get; set; }


        public List<Printer> PrintersList { get; set; }
        public List<Invoice> InvoicesList { get; set; }

    }
}
