// MyClass class
public class MyClass {

	private string mName;
	private int mID;

	private string mTestProperty; // Originally Added in TestBranch

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

	public string TestPropery {
		get {
			return mTestProperty;
		}
		set {
			mTestProperty = value;
		}
	}
}