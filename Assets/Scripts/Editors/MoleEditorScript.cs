using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PrimitiveMole))]
public class MoleEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PrimitiveMole mole = (PrimitiveMole)target;

        if(GUILayout.Button("Set Active"))
        {
            mole.SetState(MoleState.Active);
        }

    }
}
