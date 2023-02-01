/*
 * Additional GUI Items for the editors.
 *
 * Author: Pebloop
 * Date: 2023-02-01
 * 
 */

using UnityEditor;
using UnityEngine;

namespace TheSeed.Editor.Common
{
    /// <summary>
    /// Additional GUI Items for the editors.
    /// </summary>
    public static class GuiItem
    {
        /// <summary>
        /// Create an object selector.
        /// </summary>
        /// <param name="selected">The currently selected item</param>
        /// <param name="scrollPos">The current scroll position</param>
        /// <param name="options">The available objects to display</param>
        /// <param name="width">The width of the selector</param>
        /// <param name="height">The height of the selector</param>
        /// <returns>A Vector3 with x = current selected item; y = the x scrollpos; z = the y scrollpos</returns>
        public static Vector3 ObjectSelector(int selected, Vector2 scrollPos, string[] options, int width, int height)
        {
            GUIStyle style = GUI.skin.button;

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(width), GUILayout.Height(height));
            selected = GUILayout.SelectionGrid(selected, options, 1, style, GUILayout.Width(width - 20));
            EditorGUILayout.EndScrollView();
            return new Vector3(selected, scrollPos.x, scrollPos.y);
        }
    
    }
}
