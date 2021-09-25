using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnAIUnits))]
public class SelectUnitDropDown : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SpawnAIUnits spawnAIUnits = (SpawnAIUnits)target;

        List<string> unitNames = new List<string>();

        foreach (var unit in FindObjectOfType<UnitManager>().GetUnitList())
        {
            unitNames.Add(unit.name);
        }

        GUIContent listLabel = new GUIContent("AI Unit Type");
        spawnAIUnits.unitListIndex = EditorGUILayout.Popup(listLabel, spawnAIUnits.unitListIndex, unitNames.ToArray());
    }
}
