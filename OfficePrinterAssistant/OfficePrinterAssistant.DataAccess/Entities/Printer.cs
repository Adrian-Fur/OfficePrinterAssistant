using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfficePrinterAssistant.DataAccess.Entities
{
    public class Printer : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Mark { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        [MaxLength(100)]
        public string SerialNumber { get; set; }
        [Required]
        public int Counter { get; set; }
        public int CounterBlack { get; set; }
        public int ConterColor { get; set; }
        public int Limit { get; set; }
        public int LimitBlack { get; set; }
        public int LimitColor { get; set; }
        public int OverLimitPriceBlack { get; set; }
        public int OverLimitPriceColor { get; set; }
        public decimal MonthlyFee { get; set; }
        public decimal PrinterPrice { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Extension> ExtensionsList { get; set; }
        public List<Software> SoftwaresList { get; set; }


    }
}
