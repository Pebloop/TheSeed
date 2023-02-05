/*
 * Category section of the database editor.
 *
 * Author: Pebloop
 * Date: 2023-02-05
 * 
 */

namespace TheSeed.Editor.DataBase
{
    /// <summary>
    /// Abstract class that define a category editor for the database editor.
    /// </summary>
    public abstract class CategoryEditor
    {

        /// <summary>
        /// constructor
        /// </summary>
        protected CategoryEditor()
        {
        }

        /// <summary>
        /// Executed when the editor is enabled.
        /// </summary>
        /// <param name="dataBase">The database</param>
        public abstract void OnEnable(Database.DataBase dataBase);

        /// <summary>
        /// Executed when the user interact with the editor.
        /// </summary>
        public abstract void OnInspectorGUI();

    }
}
