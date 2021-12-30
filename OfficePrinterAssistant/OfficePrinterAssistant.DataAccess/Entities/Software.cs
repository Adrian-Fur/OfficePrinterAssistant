using System;
using System.ComponentModel.DataAnnotations;

namespace OfficePrinterAssistant.DataAccess.Entities
{
    public class Software : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpirationDate { get; set; }
        public decimal Price { get; set; }
        public decimal MonthlyFee { get; set; }
        public int PrinterId { get; set; }

        public Printer Printer { get; set; }
    }
}
