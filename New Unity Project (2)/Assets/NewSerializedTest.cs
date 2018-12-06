using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSerializedTest : MonoBehaviour {

    private float _myVal;
    [SerializeField]
    public float myVal { get { return _myVal; } set { _myVal = value; Debug.Log("SET THE VAL!  HELL YEAH! " + _myVal); } }


}
