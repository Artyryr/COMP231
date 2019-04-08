using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class SearchModel
    {
        public string SearchName{ get; set; }
        public List<Service> Services { get; set; }
        public string Filter { get; set; }
    }
}
