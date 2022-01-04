using System.Collections.Generic;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<PrinterDto> Printers { get; set; }

    }
}
