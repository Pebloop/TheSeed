/*
 * Monster category section of the database editor.
 *
 * Author: Pebloop
 * Date: 2023-02-01
 * 
 */

using UnityEditor;

namespace TheSeed.Editor.DataBase
{
    /// <summary>
    /// Monster category section of the database editor.
    /// </summary>
    public class MonsterEditor : CategoryEditor
    {
        
        /// <summary>
        /// Initializes the monster editor.
        /// </summary>
        /// <param name="serializedObject"> The serialized editor </param>
        public override void OnEnable(SerializedObject serializedObject)
        {
        }

        /// <summary>
        /// Draws the monster editor.
        /// </summary>
        public override void OnInspectorGUI()
        {
        }
    }
}
