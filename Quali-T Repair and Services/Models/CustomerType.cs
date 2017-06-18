using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quali_T_Repair_and_Services.Models
{
    public class CustomerType
    {
        [Key]
        public int CustomerTypeId { get; set; }

        public string Name { get; set; }

        public short MemberShipFee { get; set; }

        public string DiscountRate { get; set; }

        public byte Duration { get; set; }
    }
}