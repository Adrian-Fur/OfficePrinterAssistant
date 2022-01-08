using System.ComponentModel.DataAnnotations;

namespace OfficePrinterAssistant.DataAccess.Entities
{
    public class Extension : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string SerialNumber { get; set; }
        public decimal Price { get; set; }
        public decimal MonthlyFee { get; set; }
        public int PrinterId { get; set; }

        public Printer Printer { get; set; }
    }
}
