using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExampleColor : uint
{
    blue = 6,
    cyan = 12,
    red = 132,

    //VV the presence of a number with 1 in the 32nd bit will break this...
    //verylargecolor = 2147483648


}

public class ExampleColorComp : MonoBehaviour {
    public float nonValue = 0;
    [HideInInspector]
    public string enumName = "";
    public ExampleColor myExColor = ExampleColor.blue;
    //private ExampleColor _myExColor;    
    //public ExampleColor myExColor { get { return _myExColor; } set { _myExColor = value; Debug.Log("god is great"); } }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
