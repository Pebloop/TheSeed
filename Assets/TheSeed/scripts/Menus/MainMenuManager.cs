/*
 * Main Menu manager
 *
 * Author: Pebloop
 * Date: 2023-02-05
 * 
 */

using Microsoft.MixedReality.Toolkit.Audio;
using UnityEngine;

namespace TheSeed.Menus
{
    /// <summary>
    /// Main Menu Manager
    /// Manage the main menu of the game.
    /// </summary>
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] TextToSpeech tts;

        // Start is called before the first frame update
        void Start()
        {
            tts.StartSpeaking("Welcome Agent, please select your account in the database.");
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void OnSelectAccount(string name)
        {
            tts.StartSpeaking("Account selected.");
            tts.StartSpeaking("Welcome " + name + ".");
        }

        public void OnSelectNewAccount()
        {
            tts.StartSpeaking("Please enter your name so we can verify your subscription to the program.");
        }

        public void OnSelectBack()
        {
            tts.StartSpeaking("Welcome Agent, please select your account in the database.");
        }
    
        public void OnCreateNewAccount()
        {
            tts.StartSpeaking("Identity verified. Instanciating connection.");
        
        }

    }
}
