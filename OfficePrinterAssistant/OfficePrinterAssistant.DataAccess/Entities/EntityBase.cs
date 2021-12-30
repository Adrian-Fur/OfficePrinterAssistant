using System.ComponentModel.DataAnnotations;

namespace OfficePrinterAssistant.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
