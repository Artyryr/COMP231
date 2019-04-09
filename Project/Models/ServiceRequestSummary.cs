using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class ServiceRequestSummary
    {
        public string ServiceName { get; set; }
        public double PricePerHour { get; set; }
        public double NumberOfHours { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
    }
}
