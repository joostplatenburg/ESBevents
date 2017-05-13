using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBevents.Models
{
    public class CustomerModel
    {
        public string Name { get; set; }
        public string IPNumber { get; set; }
		public string PortNumberEL { get; set; } // Eventlog
		public string PortNumberSP { get; set; } // StartProcess
		public string Logo { get; set; }

        public List<KoppelingModel> Koppelingen { get; set; }
	}
}
