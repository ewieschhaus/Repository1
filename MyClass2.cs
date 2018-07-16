// MyClass2 class
public class MyClass2 {

    private string mFirstName;
    private string mLastName;

    // MyClass2 constructor
    public MyClass2() {

    }

    // FirstName property
    public string FirstName {
        get {
            return mFirstName;
        }
        set{
            mFirstName = value;
        }
    }

    // LastName property
    public string LastName {
        get {
            return mLastName;
        }
        set{
            mLastName = value;
        }
    }
}