using System;
using UnityEditor;
using UnityEngine;

namespace Manor
{
    public abstract class CustomEditorBase : Editor
    {
        protected void InspectorButton(string buttonLabel, Action method)
        {
            if (GUILayout.Button(buttonLabel))
            {
                method?.Invoke();
            }
        }
    }
}