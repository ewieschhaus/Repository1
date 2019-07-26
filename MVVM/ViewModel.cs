public class ViewModel : INotifyPropertyChanged{

    private ObservableCollection<ItemViewModel> _items
    private CollectionViewSource _itemsViewSource = new CollectionViewSource();

    public ViewModel () {

        _items = new ObervableCollection<ItemViewModel>();
        _itemsViewSource.Source = _items;
    }

    public ListCollectionView Items {
        get {
            return (ListCollectionView)_itemsViewSource.View;
        }
    }

    private ICommand _deleteCommand;
    public ICommand DeleteCommand {
        get {
            if (_deleteCommand == null){
                _deleteCommand = new CommandHandler((commandParameter)=> {
                    var item = commandParameter as ItemViewModel;
                    if (item!=null) {
                        _items.Remove(item);
                    }
                });
            }

            return _deleteCommand;

        }
    }

    private ICommand _sortByColumnName;
    public ICommand SortByColumnName {
        get {
            if (_sortByColumnName == null) {
                _sortByColumnName = new CommandHandler((commandParameter) => {
                    _itemsViewSource.SortDescriptions.Clear();
                    SortDescription desc = new SortDescription(commandParameter, SortDirection.Ascending);
                    _itemsViewSource.SortDescription.Add(desc);
                });
            }
            return _sortByColumnName;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void Notify(string propName) {
        if (PropertyChanged != null) {
            PropertyChanged(new PropertyChangedEventArgs(propName));
        }
    }

}