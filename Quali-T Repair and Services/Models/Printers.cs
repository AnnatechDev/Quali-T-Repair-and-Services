using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quali_T_Repair_and_Services.Models
{
    public class Printers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrintColor { get; set; }
        public string Processor { get; set; }
        public int PrintCatridges { get; set; }
        public string Wireless { get; set; }
        public string SystemRequirements { get; set; }
        public string MobilePrinting { get; set; }
        public string TypeofPrinter { get; set; }
        public string Dimensions { get; set; }
        public string Weight { get; set; }
    }
}