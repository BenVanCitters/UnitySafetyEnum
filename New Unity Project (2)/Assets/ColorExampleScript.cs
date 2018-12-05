using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorExampleScript : StateMachineBehaviour {
    public ExampleColor excolor = ExampleColor.blue;
    [HideInInspector]
    public string colorName = "blue";
}
