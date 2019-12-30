using System;
using System.Reflection;
using System.Collections.Generic;

using UnityEngine;

public struct MyTestStruct
{
	public string MyString;
	string MyName_private;
};

public struct MyTestStruct_WithConstructor
{
	public string MyString;
	string MyName_private;

	MyTestStruct_WithConstructor(string InMyString, string InMyName)
	{
		MyString = InMyString;
		MyName_private = InMyName;
	}
};

public enum MyEnum
{
	None = 0,
	First,
	Second,
};

[Flags]
public enum MyEnumFlags
{
	None = 0,
	First = 1 << 0,
	Second = 1 << 1,
};

public class MyScript : MonoBehaviour
{

	#region Simple C# types
	public byte MyByte;
	public sbyte MySignedByte;
	public int MyInt;
	public uint MyUnsignedInt;
	public long MyLong;
	public float MyFloat;
	public double MyDouble;
	public decimal MyDecimal; // Does NOT show up!!!
	public char MyChar;
	public bool bMyBool = true; // we DO can initialize fields
	public string MyStr;
	public string MyStr_initialized = "test";
	#endregion // Simple C# types

	#region Array collection
	public int[] IntArray = new int[4];
	public int[] IntArray_Uninitialized;
	#endregion

	#region List collection
	public List<int> IntList = new List<int>();
	public List<int> List_Uninitilized;
	#endregion // List

	#region Dictionary collection
	// Dictionaries are NOT shown up!!!
	public Dictionary<int, string> MyDictionary = new Dictionary<int, string>();
	public Dictionary<int, string> MyDictionary_Uninitilized;
	#endregion // Dictionary

	#region Delegates
	// WARNING!!! Std C#-delegates are NEVER shown!!!!
	public delegate void MyTestDelegate(object sender, EventArgs e);
	public MyTestDelegate MyDelegate;
	public Action MyActionDelegate;
	public Func<int> MyIntFuncDelegate;

	// WARNING!!! std C# events are NEVER shown!!!!
	public event MyTestDelegate MyTestEvent;
	public event Action MyActionEvent;
	public event Func<int> MyIntFuncEvent;

	// OK: Event.UnityEvent: DO can be set in inspector
	public UnityEngine.Events.UnityEvent MyUnityEvent;
	#endregion // Delegates

	#region structs
	// Structs are NOT shown UP!!!
	public MyTestStruct MyStruct;
	public MyTestStruct_WithConstructor MyStruct_WithConstructor;
	#endregion

	#region enums
	public MyEnum MyEnum;
	// Enum flags are shown as ORDINARY enums!!!
	public MyEnumFlags MyEnumFlags;
	#endregion // enums

	#region Custom Interfaces
	// Does NOT show up in editor!
	public MyTestInterface MyInterface;
	#endregion

	#region Custom Classes
	// Does NOT show up in editor!
	public MyTestObject MyObject;
	#endregion

	#region CSharp classes
	// System.Object: NOT visible
	// WARNING!!! we must ALWAYS reference like System.Object,
	// otherwise - ambigious reference!
	public System.Object Object;
	#endregion // CSharp classes

	#region Unity math types
	public Vector3 MyVec3;
	public Vector4 MyVec4;
	public Vector2 MyVec2;
	public Quaternion MyQuaternion;
	#endregion

	#region Unity Object
	// Allows to select any object in the scene
	// WARNING!!! Always access as UnityEngine.Object, otherwise - ambigious call (if using System namespace)
	public UnityEngine.Object MyUnityObject;
	// Allows to select object in the scene
	public GameObject MyGameObject;
	// Component: Unity ONLY allows to select object WITHIN scene,
	// and select its TRANSFOM component!
	public Component MyComponent;

	// Behaviour: Allows to select game object in scene and AUTOMATICALLY choses its SCRIPT
	public Behaviour MyBehaviour;
	// MonoBehaviour: Allows to select game object in scene and AUTOMATICALLY choses its SCRIPT
	public MonoBehaviour MyMonoBehaviour;
	#endregion // Unity

	// Type: NOT accessible
	public Type type; // Invisible

	// Protected and private variables are NEVER accessible!
	protected string str_protected;
	string str_private;

	// Properties are NEVER accessible!
	public float prop_f { get; set; }

	public void Awake()
	{
		Debug.Log($"{nameof(Awake)}");
	}

	public void Start()
	{
		Debug.Log($"{nameof(Start)}");
	}
}
