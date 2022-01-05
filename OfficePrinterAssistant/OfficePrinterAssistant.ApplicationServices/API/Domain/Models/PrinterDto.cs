﻿using System.Collections.Generic;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.Models
{
    public class PrinterDto
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int UserId { get; set; }
        public List<ExtensionDto> ExtensionsList { get; set; }
        public List<SoftwareDto> SoftwaresList { get; set; }

    }
}
