using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UI))]
public class UiEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        UI ui = (UI)target;
        if (GUILayout.Button("-"))
        {
            ui.SubtractStressBar(0.2f);
        }
        if (GUILayout.Button("+"))
        {
            ui.AddStressBar(0.3f);
        }
        if (GUILayout.Button("search"))
        {
            ui.CheckedIfPickedUp("Items");
        }

    }
}
