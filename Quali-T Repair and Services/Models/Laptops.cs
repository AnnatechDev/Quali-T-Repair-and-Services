using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quali_T_Repair_and_Services.Models
{
    public class Laptops
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Processor { get; set; }
        public string FormFactor { get; set; }
        public int Rating { get; set; }
        public int SerialNumber { get; set; }
        public string ModelNumber { get; set; }
        public DateTime DateManufactured { get; set; }
        public string ScreenResolution { get; set; }
    }
}