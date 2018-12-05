using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExampleColor : uint
{
    blue = 6,
    cyan = 12,
    red = 132,
}

public class ExampleColorComp : MonoBehaviour {
    public float nonValue = 0;
    [HideInInspector]
    public string enumName = "";
    public ExampleColor myExColor = ExampleColor.blue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
