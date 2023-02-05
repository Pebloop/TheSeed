/*
 * Item category section of the database editor.
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
    /// Item category section of the database editor.
    /// </summary>
    public class ItemEditor : CategoryEditor
    {
        /// <summary>
        /// The serialized item category of the database.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// The selected item index.
        /// </summary>
        private int _selectedIndex = -1;
        
        /// <summary>
        /// The scroll position of the item list.
        /// </summary>
        private Vector2 _scrollPos = Vector2.zero;

        /// <summary>
        /// Initializes the item editor.
        /// </summary>
        /// <param name="serializedObject"> The serialized editor </param>
        public override void OnEnable(Database.DataBase dataBase)
        {
            this._items = dataBase.items;
        }

        /// <summary>
        /// Draws the item editor.
        /// </summary>
        public override void OnInspectorGUI()
        {
            // If items editor is not linked with the database, return.
            if (this._items == null)
            {
                return;
            }
            
            // Create a list of item uid to display in the item selector.
            string[] itemsList = new string[_items.Count];
            for (int i = 0; i < _items.Count; i++)
            {
                itemsList[i] = _items[i].Uid;
            }

            
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.BeginVertical();
            
            Vector3 objs = GuiItem.ObjectSelector(
                _selectedIndex,
                _scrollPos,
                itemsList,
                (int)EditorGUIUtility.currentViewWidth / 3,
                140
                );
            _selectedIndex = (int)objs.x;
            _scrollPos.x = objs.y;
            _scrollPos.y = objs.z;
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("+", GUILayout.Width(30)))
            {
                _items.Add(new Item());
            }
            if (_selectedIndex >= 0 && _selectedIndex < _items.Count && GUILayout.Button("-", GUILayout.Width(30)))
            {
                _items.RemoveAt(_selectedIndex);
            }
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.BeginVertical();

            if (_selectedIndex >= 0 && _selectedIndex < _items.Count)
            {
                Item item = _items[_selectedIndex];
                item.SetUid(EditorGUILayout.TextField("uid", item.Uid));
                item.SetName(EditorGUILayout.TextField("name", item.Name));
                EditorGUILayout.LabelField("description");
                item.SetDescription(EditorGUILayout.TextArea(item.Description, GUILayout.Height(70)));
                item.SetIcon((Sprite)EditorGUILayout.ObjectField("icon", item.Icon, typeof(Sprite), false));
                item.SetPrefab(
                    (GameObject)EditorGUILayout.ObjectField("prefab", item.Prefab, typeof(GameObject), false));
                item.SetIsStackable(EditorGUILayout.Toggle("isStackable", item.IsStackable));
                if (item.IsStackable)
                {
                    item.SetMaxStack(EditorGUILayout.IntField("maxStack", item.MaxStack));
                }

                item.SetIsConsumable(EditorGUILayout.Toggle("isConsumable", item.IsConsumable));
                if (item.IsConsumable)
                {
                    item.SetDisappearWhenConsumed(EditorGUILayout.Toggle("disappearWhenConsumed",
                        item.DisappearWhenConsumed));

                }

                if (GUILayout.Button("Delete"))
                {
                    _items.Remove(item);
                }
            } else if (_items.Count > 0)
            {
                EditorGUILayout.LabelField("Select an item.");
            } else
            {
                EditorGUILayout.LabelField("No item in the database.");
            }

            EditorGUILayout.EndVertical();
            
            EditorGUILayout.EndHorizontal();
        }
    }
}
