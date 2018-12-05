using UnityEditor;
using UnityEngine;
using System.Collections;
using System;
using System.IO;

[CustomEditor(typeof(ExampleColorComp))]
public class ExampleColorCompEditor : Editor
{
    SerializedProperty myExColorProp;
    SerializedProperty myStrProp;

    void doLog2(string str)
    {
        String logstr = String.Format("\r\nLog : {0} {1} : {2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), str);
        using (StreamWriter w = File.AppendText("log.txt"))
        {
            w.Write(logstr);
        }
        Console.WriteLine(logstr);
        Debug.Log(logstr);
    }


    void doLog(string str)
    {
        //using (StreamWriter w = File.AppendText("log.txt"))
        //{
        //    w.WriteLine(str);
        //}
        //Console.WriteLine(str);

        //Debug.Log(str);
    }

    void OnEnable()
    {
        // Setup the SerializedProperties.
        myExColorProp = serializedObject.FindProperty("myExColor");
        myStrProp = serializedObject.FindProperty("enumName");
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
        doLog("MyPlayerEditor - OnInspectorGUI");
        serializedObject.Update();

        ExampleColor oldenum = getEnumFromProperty();
        ExampleColor e = oldenum;
        
        e = (ExampleColor) EditorGUILayout.EnumPopup(myExColorProp.name, e);
        if (e != oldenum)
        {
            doLog2("string value was: " + myStrProp.stringValue);

            setPropEnum(e);
            myStrProp.stringValue = enumName(e);
            doLog2("set string value to: " + myStrProp.stringValue);
        }
        serializedObject.ApplyModifiedProperties();
    }

    public void OnSceneGUI()
    {
        doLog("MyPlayerEditor - OnSceneGUI");
    }

    ////////////
    //
    // Summary:
    //     The first entry point for Preview Drawing.
    //
    // Parameters:
    //   previewPosition:
    //     The available area to draw the preview.
    //
    //   previewArea:
    public override void DrawPreview(Rect previewArea)
    {
        doLog("MyPlayerEditor - OnInspectorGUI");
    }

    //
    // Summary:
    //     Implement this method to show asset information on top of the asset preview.
    public override string GetInfoString()
    {
        doLog("MyPlayerEditor - GetInfoString");
        return "GetInfoString";
    }

    //
    // Summary:
    //     Override this method if you want to change the label of the Preview area.
    public override GUIContent GetPreviewTitle()
    {
        doLog("MyPlayerEditor - GetPreviewTitle");
        return new GUIContent();
    }

    //
    // Summary:
    //     Override this method in subclasses if you implement OnPreviewGUI.
    //
    // Returns:
    //     True if this component can be Previewed in its current state.
    public override bool HasPreviewGUI()
    {
        doLog("MyPlayerEditor - HasPreviewGUI");
        return false;
    }

    //
    // Summary:
    //     Implement to create your own interactive custom preview. Interactive custom previews
    //     are used in the preview area of the inspector and the object selector.
    //
    // Parameters:
    //   r:
    //     Rectangle in which to draw the preview.
    //
    //   background:
    //     Background image.
    public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
    {
        doLog("MyPlayerEditor - OnInteractivePreviewGUI");
    }

    //
    // Summary:
    //     Implement to create your own custom preview for the preview area of the inspector,
    //     primary editor headers and the object selector.
    //
    // Parameters:
    //   r:
    //     Rectangle in which to draw the preview.
    //
    //   background:
    //     Background image.
    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        doLog("MyPlayerEditor - OnPreviewGUI");
    }

    //
    // Summary:
    //     Override this method if you want to show custom controls in the preview header.
    public override void OnPreviewSettings()
    {
        doLog("MyPlayerEditor - OnPreviewSettings");
    }

    public override void ReloadPreviewInstances()
    {
        doLog("MyPlayerEditor - ReloadPreviewInstances");
    }

    //
    // Summary:
    //     Override this method if you want to render a static preview that shows.
    //
    // Parameters:
    //   assetPath:
    //
    //   subAssets:
    //
    //   width:
    //
    //   height:
    public override Texture2D RenderStaticPreview(string assetPath, UnityEngine.Object[] subAssets, int width, int height)
    {
        doLog("MyPlayerEditor - RenderStaticPreview");
        return new Texture2D(0, 0);
    }

    //
    // Summary:
    //     Does this edit require to be repainted constantly in its current state?
    public override bool RequiresConstantRepaint()
    {
        doLog("MyPlayerEditor - RequiresConstantRepaint");
        return false;
    }

    //
    // Summary:
    //     Override this method in subclasses to return false if you don't want default
    //     margins.
    public override bool UseDefaultMargins()
    {
        doLog("MyPlayerEditor - UseDefaultMargins");
        return false;
    }

    protected override void OnHeaderGUI()
    {
        doLog("MyPlayerEditor - OnHeaderGUI");
    }

    //
    // Summary:
    //     Returns the visibility setting of the "open" button in the Inspector.
    //
    // Returns:
    //     Return true if the button should be hidden.
    protected override bool ShouldHideOpenButton()
    {
        doLog("MyPlayerEditor - ShouldHideOpenButton");
        return false;
    }
}