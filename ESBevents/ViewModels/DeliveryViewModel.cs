using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;

namespace ESBevents.ViewModels
{
    public class DeliveryViewModel : INotifyPropertyChanged
	{
        public DeliveryViewModel()
		{
			_delivery = new DeliveryModel();
		}

        public DeliveryViewModel(DeliverylogViewModel _elVM)
		{
			//_delivery = _elVM.SelectedDelivery;
		}

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string name)
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
		#endregion INotifyPropertyChanged implementation

		#region Properties
		private DeliveryModel _delivery;
		public DeliveryModel Delivery
		{
            get { return _delivery; }
			set
			{
                if (_delivery == value) return;

                _delivery = value;

				OnPropertyChanged("Delivery");
			}
		}

        public string DeliveryId { get { return string.Format("{0}", Delivery.DeliveryId); } }
		public string MessageId { get { return string.Format("{0}", Delivery.MessageId); } }
        public string CreationDate { get { return string.Format("{0}", Delivery.CreationDate); } }
        public string CreationTime { get { return string.Format("{0}", Delivery.CreationTime); } }
        public string ProcessedDate { get { return string.Format("{0}", Delivery.ProcessedDate); } }
        public string ProcessedTime { get { return string.Format("{0}", Delivery.ProcessedTime); } }
        public string SubscriptionStatus { get { return string.Format("{0}", Delivery.SubscriptionStatus); } }
        public string DeliveryStatus { get { return string.Format("{0}", Delivery.DeliveryStatus); } }
        public string NumberOfTries { get { return string.Format("{0}", Delivery.NumberOfTries); } }
        public string Resultmessage { get { return string.Format("{0}", Delivery.Resultmessage); } }
        public string PublisherName { get { return string.Format("{0}", Delivery.PublisherName); } }
        public string SubscriptionName { get { return string.Format("{0}", Delivery.SubscriptionName); } }
        public string MessageType { get { return string.Format("{0}", Delivery.MessageType); } }
        public string Messagecontent { get { return string.Format("{0}", Delivery.Messagecontent); } }

        private string _logo;
        public string Logo { 
            get { return _logo; } 
            set
            {
                if (_logo == value) return;

                _logo = value;

                OnPropertyChanged("Logo");
            }
        }

        /*

		public string TypeImage
		{
			get {
				if (Event.Type != null)
				{
					switch (Event.Type)
					{
						case "1":
							return "led_blue.png";
						case "2":
							return "led_red.png";
						case "3":
							return "led_yellow.png";
						case "4":
							return "led_green.png";
						case "5":
							return "led_blue.png";
						default:
							break;
					}
				}

				return "";
			}
		}

        public string MsgType
		{
			get
			{
                if (Event.Type != null)
                {
                    switch (Type)
                    {
                        case "1":
                            return "1";
                        case "2":
                            return "Error";
                        case "3":
                            return "Warning";
                        case "4":
                            return "Info";
                        case "5":
                            return "Trace";
                        default:
                            break;
                    }
                }
				return "";
			}
		}
        */

		#endregion Properties
	}
}
