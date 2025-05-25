using UnityEditor;
using UnityEngine;
using WhackATham.Domain.Moles;
using WhackATham.GameLogics.Moles;

namespace WhackATham.GameLogics.Editors
{
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
}