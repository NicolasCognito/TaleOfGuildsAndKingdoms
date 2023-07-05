using System;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

/* public class DrawWithLabelOnTop<T> : OdinValueDrawer<T>
{
    protected override void DrawPropertyLayout(GUIContent label)
    {
        if (label != null)
        {
            EditorGUILayout.LabelField(label, SirenixGUIStyles.LeftAlignedGreyMiniLabel);
        }
        this.CallNextDrawer(label);
    }

    protected override bool CanDrawValueProperty(InspectorProperty property)
    {
        return property.Info.GetAttribute<DrawWithLabelOnTopAttribute>() != null;
    }
}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class DrawWithLabelOnTopAttribute : Attribute
{
} */

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class DrawWithLabelOnTopAttribute : Attribute
{
}

public class DrawWithLabelOnTop<T> : OdinValueDrawer<T>
{
    protected override void DrawPropertyLayout(GUIContent label)
    {
        if (label != null)
        {
            var style = new GUIStyle(SirenixGUIStyles.BlackLabel);
            style.fontSize = 12; // set your desired font size here
            EditorGUILayout.LabelField(label, style);
        }
        this.CallNextDrawer(null); // Pass null to hide the label
    }

    protected override bool CanDrawValueProperty(InspectorProperty property)
    {
        return property.Info.GetAttribute<DrawWithLabelOnTopAttribute>() != null;
    }
}
 