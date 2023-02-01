/*
 * Item category section of the database editor.
 *
 * Author: Pebloop
 * Date: 2023-02-01
 * 
 */

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
        private SerializedProperty _items;
        
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
        public override void OnEnable(SerializedObject serializedObject)
        {
            this.SerializedObject = serializedObject;
            _items = SerializedObject.FindProperty("items");
        }

        /// <summary>
        /// Draws the item editor.
        /// </summary>
        public override void OnInspectorGUI()
        {
            Vector3 objs = GuiItem.ObjectSelector(
                _selectedIndex,
                _scrollPos,
                _items.enumDisplayNames,
                (int)EditorGUIUtility.currentViewWidth - 30,
                140
                );
            _selectedIndex = (int)objs.x;
            _scrollPos.x = objs.y;
            _scrollPos.y = objs.z;
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("New Item"))
            {
                _items.InsertArrayElementAtIndex(_items.arraySize);
            }
            EditorGUILayout.EndHorizontal();

            for (int i = 0; i < _items.arraySize; i++)
            {
                SerializedProperty item = _items.GetArrayElementAtIndex(i);

                if (EditorGUILayout.BeginFoldoutHeaderGroup(_selectedIndex == i, item.FindPropertyRelative("_itemId").stringValue))
                {
                    _selectedIndex = i;
                    EditorGUILayout.PropertyField(item.FindPropertyRelative("_itemId"));
                    EditorGUILayout.PropertyField(item.FindPropertyRelative("_itemName"));
                    EditorGUILayout.LabelField("Description");
                    item.FindPropertyRelative("_itemDesc").stringValue =
                        EditorGUILayout.TextArea(item.FindPropertyRelative("_itemDesc").stringValue,
                            GUILayout.Height(70));
                    EditorGUILayout.PropertyField(item.FindPropertyRelative("_itemIcon"));
                    EditorGUILayout.PropertyField(item.FindPropertyRelative("_itemPrefab"));

                    EditorGUILayout.PropertyField(item.FindPropertyRelative("_isStackable"));
                    if (item.FindPropertyRelative("_isStackable").boolValue)
                    {
                        EditorGUILayout.PropertyField(item.FindPropertyRelative("_maxStack"));
                    }

                    EditorGUILayout.PropertyField(item.FindPropertyRelative("_isConsumable"));
                    if (item.FindPropertyRelative("_isConsumable").boolValue)
                    {
                        EditorGUILayout.PropertyField(item.FindPropertyRelative("_disapearWhenConsumed"));
                        EditorGUILayout.PropertyField(item.FindPropertyRelative("_onUse"));
                    }

                    if (GUILayout.Button("Delete"))
                    {
                        _items.DeleteArrayElementAtIndex(i);
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
