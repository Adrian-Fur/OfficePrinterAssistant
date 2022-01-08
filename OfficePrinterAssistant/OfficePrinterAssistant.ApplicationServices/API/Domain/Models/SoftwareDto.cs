﻿namespace OfficePrinterAssistant.ApplicationServices.API.Domain.Models
{
    public class SoftwareDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public decimal Price { get; set; }
        public decimal MonthlyFee { get; set; }
    }
}
