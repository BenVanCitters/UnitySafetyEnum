using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using System.IO;

[CustomEditor(typeof(ColorExampleScript))]
public class StateMachineEditor : Editor {
	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update () {}

    SerializedProperty myExColorProp;
    SerializedProperty myStrProp;
    void doLog2(string str)
    {
        using (StreamWriter w = File.AppendText("log.txt"))
        {
            w.WriteLine(str);
        }
        Console.WriteLine(str);

        Debug.Log(str);

    }
    void OnEnable()
    {
        // Setup the SerializedProperties.
        myExColorProp = serializedObject.FindProperty("excolor");
        myStrProp = serializedObject.FindProperty("colorName");
        refreshEnum();
    }

    public void refreshEnum()
    {
        serializedObject.Update();

        string oldName = myStrProp.stringValue;

        Array names = Enum.GetNames(typeof(ExampleColor));
        int index = Array.IndexOf(names, oldName);

        if (index == -1)
        {
            doLog2("we done fucked up - old enum name: " + oldName + " not found in current enum!");
            setEnumProperty(0);
            doLog2("NOT SURE WHAT TO DO setting enum color value to: " + getEnumFromProperty() + " on " + serializedObject.targetObject.name);
        }
        else
        {
            string newName = (string)names.GetValue(index);
            doLog2("old string enumname is [" + oldName + "], new name is [" + newName + "]");

            if (newName != oldName || myExColorProp.enumValueIndex == -1)
            {
                doLog2("congrats! an enum got broke!");
                setEnumProperty(index);
                doLog2("setting enum color value to: " + getEnumFromProperty());
            }
        }
        serializedObject.ApplyModifiedProperties();
    }

    #region Enum property helper functions
    public void setEnumProperty(int enumIndex)
    {
        myExColorProp.enumValueIndex = enumIndex;
        myStrProp.stringValue = enumName(getEnumFromProperty());
    }

    public ExampleColor getEnumFromProperty()
    {
        ExampleColor e = (ExampleColor)Enum.GetValues(typeof(ExampleColor)).GetValue(myExColorProp.enumValueIndex);
        return e;
    }
    public void setPropEnum(ExampleColor e)
    {
        int index = Array.IndexOf(Enum.GetValues(typeof(ExampleColor)), e);
        myExColorProp.enumValueIndex = index;
    }

    public string enumName(ExampleColor e)
    {
        return Enum.GetName(typeof(ExampleColor), e);
    }

    ExampleColor enumFromName(string name)
    {
        Array names = Enum.GetNames(typeof(ExampleColor));
        //This will potentially break if the index here is -1
        int index = Array.IndexOf(names, name);
        return (ExampleColor)Enum.GetValues(typeof(ExampleColor)).GetValue(index);
    }
    #endregion

    //
    // Summary:
    //     Implement this function to make a custom inspector.
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        ExampleColor oldenum = getEnumFromProperty();
        ExampleColor e = oldenum;

        e = (ExampleColor)EditorGUILayout.EnumPopup(myExColorProp.name, e);
        if (e != oldenum)
        {
            doLog2("string value was: " + myStrProp.stringValue);

            setPropEnum(e);
            myStrProp.stringValue = enumName(e);
            doLog2("set string value to: " + myStrProp.stringValue);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
