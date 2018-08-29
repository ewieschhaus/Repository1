using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR_COP.Common
{
    public class ObservableNotifyCollection<T> : ObservableCollection<T> where T: INotifyPropertyChanged
    {
        /// <summary>
        /// Creates a new ObservableNotifyCollection of Type T
        /// </summary>
        public ObservableNotifyCollection()
            : base()
        {
            this.Initialize();
        }

        /// <summary>
        /// Creates a new ObservableNotifyCollection of Type T from a preset collection of items
        /// </summary>
        /// <param name="collection"></param>
        public ObservableNotifyCollection(IEnumerable<T> collection)
            : base(collection)
        {
            this.Initialize();
        }

        /// <summary>
        /// Creates a new ObservableNotifyCollection of Type T from a preset list of items
        /// </summary>
        /// <param name="list"></param>
        public ObservableNotifyCollection(List<T> list)
            : base(list)
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes the ObservableNotifyCollection by subscribing to the necessary PropertyChanged events
        /// </summary>
        private void Initialize()
        {
            this.CollectionChanged += this.SubscribeToItem_PropertyChanged;
            if (this != null)
            {
                foreach (T item in this)
                {
                    item.PropertyChanged += Item_PropertyChanged;
                }
            }
        }

        /// <summary>
        /// Manages the subscription to a PropertyChanged event on each item and handles it by forwarding to the NotifyCollectionItemPropertyChangedEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubscribeToItem_PropertyChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (T item in e.NewItems)
                {
                    item.PropertyChanged += Item_PropertyChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (T item in e.OldItems)
                {
                    item.PropertyChanged -= Item_PropertyChanged;
                }
            }
        }

        /// <summary>
        /// Fires the Event signifying a change on an Item within the Collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (NotifyCollectionItemPropertyChanged != null)
            {
                NotifyCollectionItemPropertyChanged(sender, new NotifyCollectionItemPropertyChangedEventArgs(e.PropertyName));
            }
        }

        /// <summary>
        /// The EventHandler for a NotifyCollectionItemPropertyChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void NotifyCollectionItemPropertyChangedEventHandler(object sender, NotifyCollectionItemPropertyChangedEventArgs e);

        /// <summary>
        /// The Event signifying a change on an Item within the Collection
        /// </summary>
        public event NotifyCollectionItemPropertyChangedEventHandler NotifyCollectionItemPropertyChanged;

    }
    
    public class NotifyCollectionItemPropertyChangedEventArgs : EventArgs {

        private string mProperty;

        /// <summary>
        /// Event Args for NotifyCollectionItemPropertyChanged
        /// </summary>
        /// <param name="property"></param>
        public NotifyCollectionItemPropertyChangedEventArgs(string property) {
            mProperty = property;
        }

        /// <summary>
        /// Name of the Property that changed on the Item within the Collection
        /// </summary>
        public string Property {
            get {return mProperty; }
        }
    }

}
