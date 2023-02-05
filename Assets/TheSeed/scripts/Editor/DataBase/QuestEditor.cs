/*
 * Quest category section of the database editor.
 *
 * Author: Pebloop
 * Date: 2023-02-05
 * 
 */

using System.Collections.Generic;
using TheSeed.Database;
using TheSeed.Editor.Common;
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
        private List<Quest> _quests;
        
        /// <summary>
        /// The selected quest index.
        /// </summary>
        private int _selectedIndex = -1;
        
        /// <summary>
        /// The scroll position of the item list.
        /// </summary>
        private Vector2 _scrollPos = Vector2.zero;

        /// <summary>
        /// Initializes the quest editor.
        /// </summary>
        /// <param name="dataBase"> The serialized editor </param>
        public override void OnEnable(Database.DataBase dataBase)
        {
            _quests = dataBase.quests;
        }

        /// <summary>
        /// Draws the quest editor.
        /// </summary>
        public override void OnInspectorGUI()
        {
            // If quests editor is not linked with the database, return.
            if (_quests == null)
            {
                return;
            }
            
            // Create a list of quest uid to display in the quest selector.
            string[] questsList = new string[_quests.Count];
            for (int i = 0; i < _quests.Count; i++)
            {
                questsList[i] = _quests[i].Uid;
            }
            
            // Display the quest selector.
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.BeginVertical();
            
            Vector3 objs = GuiItem.ObjectSelector(
                _selectedIndex,
                _scrollPos,
                questsList,
                (int)EditorGUIUtility.currentViewWidth / 3,
                140
                );
            _selectedIndex = (int)objs.x;
            _scrollPos.x = objs.y;
            _scrollPos.y = objs.z;
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("+", GUILayout.Width(30)))
            {
                _quests.Add(new Quest());
            }
            if (_selectedIndex >= 0 && _selectedIndex < _quests.Count && GUILayout.Button("-", GUILayout.Width(30)))
            {
                _quests.RemoveAt(_selectedIndex);
            }
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.BeginVertical();

            if (_selectedIndex >= 0 && _selectedIndex < _quests.Count)
            {
                Quest item = _quests[_selectedIndex];
                item.SetUid(EditorGUILayout.TextField("uid", item.Uid));
                item.SetName(EditorGUILayout.TextField("name", item.Name));
                EditorGUILayout.LabelField("description");
                item.SetDescription(EditorGUILayout.TextArea(item.Description, GUILayout.Height(70)));

                if (GUILayout.Button("Delete"))
                {
                    _quests.Remove(item);
                }
            } else if (_quests.Count > 0)
            {
                EditorGUILayout.LabelField("Select a quest.");
            } else
            {
                EditorGUILayout.LabelField("No quest in the database.");
            }

            EditorGUILayout.EndVertical();
            
            EditorGUILayout.EndHorizontal();
        
            
        }
    }
}
