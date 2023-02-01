/*
 * Manage a collection of windows to only display one at a time.
 *
 * Author: Pebloop
 * Date: 2023-02-01
 * 
 */

using System.Collections.Generic;
using UnityEngine;

namespace TheSeed.Menus
{
    /// <summary>
    /// 
    /// </summary>
    public class WindowManager : MonoBehaviour
    {
        [SerializeField] private List<string> windowsKeys = new List<string>();
        [SerializeField] private List<GameObject> windows = new List<GameObject>();

        private Dictionary<string, GameObject> _menuWindows = new Dictionary<string, GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < windowsKeys.Count; i++)
            {
                _menuWindows.Add(windowsKeys[i], windows[i]);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    
        public void ToggleMainWindows(string key)
        {
            for (int i = 0; i < windowsKeys.Count; i++)
            {
                if (windowsKeys[i] == key)
                {
                    windows[i].SetActive(!windows[i].activeSelf);
                }
                else
                {
                    windows[i].SetActive(false);
                }
            }
        }

    }
}
