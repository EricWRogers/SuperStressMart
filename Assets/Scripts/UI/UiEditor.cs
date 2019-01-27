using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
[CustomEditor(typeof(UI))]
public class UiEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        UI ui = (UI)target;
        if (GUILayout.Button("search"))
        {
            ui.CheckedIfPickedUp("Items");
        }

    }
}
#endif 