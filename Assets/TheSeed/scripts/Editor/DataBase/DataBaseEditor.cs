/*
 * Custom editor for the Database.
 *
 * Author: Pebloop
 * Date: 2023-02-05
 * 
 */

#if UNITY_EDITOR

using UnityEditor;

namespace TheSeed.Editor.DataBase
{
    
    /// <summary>
    /// Custom editor for the Database.
    /// </summary>
    [CustomEditor(typeof(global::TheSeed.Database.DataBase))]
    [CanEditMultipleObjects]
    public class DataBaseEditor : UnityEditor.Editor
    {
        // The index of the selected category

        public override void OnInspectorGUI()
        {
            // Display a message because the database is not editable from the inspector
            EditorGUILayout.HelpBox("The database is not editable from the inspector.\n"
                + "Please open the database editor with\n"
                + "'Window > TheSeed > Database Editor'", MessageType.Info);
        }
        
    }
}

#endif