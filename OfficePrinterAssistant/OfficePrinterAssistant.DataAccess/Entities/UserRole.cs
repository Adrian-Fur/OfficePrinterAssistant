using System.ComponentModel.DataAnnotations;

namespace OfficePrinterAssistant.DataAccess.Entities
{
    public class UserRole : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
