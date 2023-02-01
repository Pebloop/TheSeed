/*
 * Category section of the database editor.
 *
 * Author: Pebloop
 * Date: 2023-02-01
 * 
 */

using UnityEditor;

namespace TheSeed.Editor.DataBase
{
    /// <summary>
    /// Abstract class that define a category editor for the database editor.
    /// </summary>
    public abstract class CategoryEditor
    {
        /// <summary>
        /// The serialized object of the database.
        /// Need to be assigned in the the OnEnable method.
        /// </summary>
        protected SerializedObject SerializedObject;

        /// <summary>
        /// constructor
        /// </summary>
        protected CategoryEditor()
        {
        }

        /// <summary>
        /// Executed when the editor is enabled.
        /// </summary>
        /// <param name="serializedObject">The serialized database</param>
        public abstract void OnEnable(SerializedObject serializedObject);

        /// <summary>
        /// Executed when the user interact with the editor.
        /// </summary>
        public abstract void OnInspectorGUI();

    }
}
