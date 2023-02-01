/*
 * Windows editor of the database
 *
 * Author: Pebloop
 * Date: 2023-02-01
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
        
    /*
     * TODO: implement the windows editor of the database
     */
        
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    [MenuItem ("Window/TheSeed/DataBase Editor")]
    public static void  ShowWindow () {
        EditorWindow.GetWindow(typeof(DataBaseEditorWindow));
        
    }
    
    void OnGUI () {
        GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField ("Text Field", myString);
        
        groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle ("Toggle", myBool);
        myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup ();
    }
    }
}
