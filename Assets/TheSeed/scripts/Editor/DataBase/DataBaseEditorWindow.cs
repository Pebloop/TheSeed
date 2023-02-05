/*
 * Windows editor of the database
 *
 * Author: Pebloop
 * Date: 2023-02-05
 * 
 */

using UnityEngine;
using UnityEditor;

namespace TheSeed.Editor.DataBase
{
    /// <summary>
    /// Windows editor of the database
    /// Available in Window/TheSeed/DataBase Editor
    /// </summary>
    public class DataBaseEditorWindow : EditorWindow {
        
        /**
         * The index of the selected category
         */
        int _selectedIndex = -1;
        
        /**
         * The database object
         */
        private global::TheSeed.Database.DataBase _database;

        /**
         * All the categories of the database
         */
        private readonly CategoryEditor[] _categoryEditors = 
        {
            new ItemEditor(),
            new QuestEditor(),
            new ZoneEditor(),
            new MonsterEditor(),
        };

        [MenuItem ("Window/TheSeed/DataBase Editor")]
        public static void  ShowWindow () {
            EditorWindow.GetWindow(typeof(DataBaseEditorWindow));
            
        }

        /**
         * Changes the database and apply it on all the editors, can be forced to update
         * @param newDatabase The new database
         * @param force Force the update
         */
        private void _ChangeDatabase(TheSeed.Database.DataBase newDatabase, bool force = false)
        {
            // If the database is the same and not forced, do nothing
            if (force == false && newDatabase == _database)
            {
                return;
            }
            
            // If the database is not the same, update it on all the editors
            _database = newDatabase;
            if (_database == null)
            {
                return;
            }
            foreach (CategoryEditor categoryEditor in _categoryEditors)
            {
                categoryEditor.OnEnable(_database);
            }
        }
        
        /**
         * Called when the window is enabled, force to refresh all the editors
         */
        void OnEnable()
        {
            _ChangeDatabase(_database, true);
        }

        void OnGUI ()
        {
            // Database selector
             Database.DataBase newDB = (global::TheSeed.Database.DataBase)EditorGUILayout.ObjectField("Database", _database, typeof(global::TheSeed.Database.DataBase), true);
            _ChangeDatabase(newDB);
             
            // if no database is selected, display a message
            if (_database)
            {
                // Draw the category selector
                _selectedIndex = GUILayout.Toolbar(_selectedIndex,
                    new [] { "Items", "Quests", "Zones", "Monsters" },
                    GUILayout.MinWidth(Screen.width)
                );


                // Draw the selected category
                if (_selectedIndex < _categoryEditors.Length)
                {
                    _categoryEditors[_selectedIndex].OnInspectorGUI();
                }
                else
                {
                    EditorGUILayout.LabelField("Not implemented yet");
                }
                
            } else {
                EditorGUILayout.HelpBox("No database selected", MessageType.Warning);
            }
            
        }
    }
}
