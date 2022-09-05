using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WorldWrapManager))]
public class WrapUpdateWorld : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        WorldWrapManager worldWrapManager = (WorldWrapManager)target;

        if (GUILayout.Button("Update World Wrap Objects"))
        {
            worldWrapManager.UpdateWorldWrap();
        }
    }
}
