using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quali_T_Repair_and_Services.Models
{
    public class TvBox
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OperatingSystem { get; set; }
        public string Size { get; set; }
        public string Hdmi { get; set; }
        public string ModelNumber { get; set; }
    }
}