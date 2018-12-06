using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorExampleScript : StateMachineBehaviour {
    //public ExampleColor myExColor = ExampleColor.blue;
    [HideInInspector]
    public string enumName = "blue";

    private ExampleColor _myExColor;
    public ExampleColor myExColor { get { return _myExColor; } set { _myExColor = value; Debug.Log("god is great"); } }
}
