/*
 * Quest category section of the database editor.
 *
 * Author: Pebloop
 * Date: 2023-02-01
 * 
 */

using UnityEditor;
using UnityEngine;

namespace TheSeed.Editor.DataBase
{
    /// <summary>
    /// Quest category section of the database editor.
    /// </summary>
    public class QuestEditor : CategoryEditor
    {
        /// <summary>
        /// The serialized quest category of the database.
        /// </summary>
        private SerializedProperty _quests;
        
        /// <summary>
        /// The selected quest index.
        /// </summary>
        private int _selectedIndex = -1;

        /// <summary>
        /// Initializes the quest editor.
        /// </summary>
        /// <param name="serializedObject"> The serialized editor </param>
        public override void OnEnable(SerializedObject serializedObject)
        {
            this.SerializedObject = serializedObject;
            _quests = serializedObject.FindProperty("quests");
        }

        /// <summary>
        /// Draws the quest editor.
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("New Quest"))
            {
                _quests.InsertArrayElementAtIndex(_quests.arraySize);
            }
            EditorGUILayout.EndHorizontal();

            for (int i = 0; i < _quests.arraySize; i++)
            {
                SerializedProperty quest = _quests.GetArrayElementAtIndex(i);
            
                if (EditorGUILayout.BeginFoldoutHeaderGroup(_selectedIndex == i, quest.FindPropertyRelative("_name").stringValue))
                {
                    _selectedIndex = i;
                    EditorGUILayout.PropertyField(quest.FindPropertyRelative("_name"));

                    if (GUILayout.Button("Delete"))
                    {
                        _quests.DeleteArrayElementAtIndex(i);
                    }
                }
                else if (_selectedIndex == i)
                {
                    _selectedIndex = -1;
                }
                EditorGUILayout.EndFoldoutHeaderGroup();
            }
        }
    }
}
