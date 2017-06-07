using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quali_T_Repair_and_Services.Models
{
    public class Tablets
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OperatingSystem { get; set; }
        public string Cpu { get; set; }
        public string Camera { get; set; }
        public string InternalMemory { get; set; }
        public string CardSlot { get; set; }
        public string Resolution { get; set; }
        public string Sensors { get; set; }
        public string Weight { get; set; }
        public string Sim { get; set; }
        public int Rating { get; set; }
        public string Network { get; set; }
    }
}