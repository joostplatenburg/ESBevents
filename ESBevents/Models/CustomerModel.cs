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

		public string IPO { get; set; }
		public string IPT { get; set; }
		public string IPA { get; set; }
		public string IPP { get; set; }

		public string PortEnsemble { get; set; } // Eventlog
		public string PortPubsub { get; set; } // StartProcess

		public string Logo { get; set; }

        public bool ToonEventlog { get; set; }
        public bool StartBP { get; set; }
        public bool ToonPSlog { get; set; }

        public List<KoppelingModel> Koppelingen { get; set; }
	}
}
