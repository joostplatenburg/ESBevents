using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;
using System.Collections.ObjectModel;

namespace ESBevents.ViewModels
{
	public class EventlogViewModel : INotifyPropertyChanged
    {
	public EventlogViewModel()
        {
			_eventlog = new ObservableCollection<EventViewModel> ();
        }

	public EventlogViewModel(MainPageViewModel _mpVM)
	{
		_eventlog = new ObservableCollection<EventViewModel> ();
			/*
		foreach (EventModel e in _mpVM.EventLog) {
				if(
					(!e.SourceClass.StartsWith("Ens.")) && 
					(!e.SourceClass.StartsWith("EnsLib")) &&
					(!e.SourceClass.StartsWith("DXC."))
				)
				{
					_eventlog.Add(new EventViewModel { Event = e });
				}
        }
		*/
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
	private ObservableCollection<EventViewModel> _eventlog;

	public ObservableCollection<EventViewModel> Eventlog
	{
		get { return _eventlog; }
		set {
			if (_eventlog == value)
				return;

			_eventlog = value;

			OnPropertyChanged ("Eventlog");
		}
	}

	private EventViewModel _selectedItem;
	public EventViewModel SelectedItem
	{
		get { return _selectedItem; }
		set {
			if (_selectedItem == value) 
				return;
				
			_selectedItem = value;

			OnPropertyChanged("SelectedItem");
		}
	}
	#endregion Properties
    }
}
