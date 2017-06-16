using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBevents.Models
{
    public class EventModel
    {
        public string SourceClass { get; set; }
        public string SourceMethod { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string TimeLogged { get; set; }
        public string SessionId { get; set; }
		public string ConfigName { get; set; }
        public string TraceCat { get; set; }
        public string Job { get; set; }
		public string MessageId { get; set; }
	}
}
