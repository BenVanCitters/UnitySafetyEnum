using UnityEditor;
using UnityEngine;
using System.Collections;
using System;
using System.IO;

[CustomEditor(typeof(NewSerializedTest))]
public class NewSerializedTestEditor : Editor
{
    SerializedProperty myValProperty;
    // Use this for initialization
    void OnEnable()
    {
        // Setup the SerializedProperties.
        myValProperty = serializedObject.FindProperty("myVal");
        if (myValProperty == null)
        {
            Debug.Log("yo, wtf unity, can't I use getters/settors???");
        }

    }

    //
    // Summary:
    //     Implement this function to make a custom inspector.
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Slider(myValProperty.floatValue, 0, 100);
    }
}