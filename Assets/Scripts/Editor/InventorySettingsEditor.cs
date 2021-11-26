using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InventorySettings))]
public class InventorySettingsEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        InventorySettings settings = target as InventorySettings;
        if (GUILayout.Button("Generate List"))
        {
            settings.FillDefaultList();
        }

    }
    
}
