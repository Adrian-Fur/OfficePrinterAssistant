using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfficePrinterAssistant.DataAccess.Entities
{
    public class User : EntityBase
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        [MaxLength(50)]
        public int TaxNumber { get; set; }
        public int UserRoleId { get; set; }

        public UserRole UserRole { get; set; }
        public List<Printer> PrintersList { get; set; }
        public List<Invoice> InvoicesList { get; set; }
    }
}
