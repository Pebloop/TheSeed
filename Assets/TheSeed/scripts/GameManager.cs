using System.Collections;
using System.Collections.Generic;
using TheSeed.Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager playerManager;

    public GameObject menuScene;
    public GameObject gameScene;    

    public enum Scene { 
        MainMenu,
        Game
    }
    Scene currentScene = Scene.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        ChangeScene(Scene.MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerInfo GetMyInfo()
    {
        return playerManager.GetMyInfo();
    }

    public void ChangeScene(Scene scene)
    {
        currentScene = scene;
        switch (scene)
        {
            case Scene.MainMenu:
                menuScene.SetActive(true);
                gameScene.SetActive(false);
                break;
            case Scene.Game:
                menuScene.SetActive(false);
                gameScene.SetActive(true);
                break;
        }
    }

    public void ChangeScene(string scene)
    {
        switch (scene)
        {
            case "MainMenu":
                ChangeScene(Scene.MainMenu);
                break;
            case "Game":
                ChangeScene(Scene.Game);
                break;
        }
    }
}
