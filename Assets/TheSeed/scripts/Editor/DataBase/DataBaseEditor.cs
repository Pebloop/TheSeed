/*
 * Custom editor for the Database.
 *
 * Author: Pebloop
 * Date: 2023-02-01
 * 
 */

#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

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
        int selectedIndex = -1;

        // All the categories of the database
        private CategoryEditor[] categoryEditors = new CategoryEditor[]
        {
            new ItemEditor(),
            new QuestEditor(),
            new ZoneEditor(),
            new MonsterEditor(),
        };

        void OnEnable()
        {
            selectedIndex = 0;
            foreach (var editor in categoryEditors)
            {
                editor.OnEnable(serializedObject);
            }
        }

        public override void OnInspectorGUI()
        {
            // update the serializedObject 
            serializedObject.Update();
            
            
            // Draw the category selector
            selectedIndex = GUILayout.Toolbar(selectedIndex,
                new string[] { "Items", "Quests", "Zones", "Monsters" },
                GUILayout.MinWidth(Screen.width)
            );
        
            // Draw the selected category
            if (selectedIndex < categoryEditors.Length)
            {
                categoryEditors[selectedIndex].OnInspectorGUI();
            }
            else
            {
                EditorGUILayout.LabelField("Not implemented yet");
            }

            // Apply the changes to the serializedObject
            serializedObject.ApplyModifiedProperties();
        }
        
    }
}

#endif