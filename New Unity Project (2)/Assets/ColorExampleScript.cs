using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorExampleScript : StateMachineBehaviour {
    public ExampleColor myExColor = ExampleColor.blue;
    [HideInInspector]
    public string enumName = "blue";
}
