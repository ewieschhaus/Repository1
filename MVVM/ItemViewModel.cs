public class ItemViewModel : INotifyPropertyChanged {

    private string _prop1 = string.empty;
    private int _prop2;

    public ItemViewModel(string prop1, int prop2) {
        _prop1 = prop1;
        _prop2 = prop2;
    }

    public string Prop1 {
        get {
            return _prop1;
        }
        set {
            if (_prop1 != value) {
                _prop1 = value;
                Notify("Prop1");
            }
        }
    }

    public int Prop2 {
        get {
            return _prop2;
        }
        set {
            if (_prop2 != value) {
                _prop2 = value;
                Notify("Prop2");
            }
        }
    }

    public event eventhandler PropertyChanged;

    private void Notify(string propName) {
        if ( PropertyChanged != null) {
            PropertyChanged(new PropertyChangedEventArgs(propName));
        }
    }

}