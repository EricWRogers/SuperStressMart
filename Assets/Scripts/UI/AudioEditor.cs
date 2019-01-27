using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
[CustomEditor(typeof(AudioManager))]
public class AudioEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AudioManager ui = (AudioManager)target;
        if (GUILayout.Button("-"))
        {
            ui.StartingGame();
        }


    }
}
#endif 
