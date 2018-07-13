// MyClass class
public class MyClass {

	private string mName;
	private int mID;

	private int mTestProperty; // Originally Added in TestBranch as string, later changed to int

	// MyClass constructor
	public MyClass(){

	}

	// Name property
	public string Name {
		get {
			return mName;
		}
		set {
			mName = value;
		}
	}

	// ID property
	public int ID {
		get {
			return mID;
		}
		set {
			mID = value;
		}
	}

	public int TestPropery {
		get {
			return mTestProperty;
		}
		set {
			mTestProperty = value;
		}
	}
}