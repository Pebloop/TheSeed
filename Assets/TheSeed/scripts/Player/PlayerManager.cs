using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    List<PlayerInfo> players = new List<PlayerInfo>();
    int myId = -1;

    // Start is called before the first frame update
    void Start()
    {
        players.Add(new PlayerInfo());
        myId = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerInfo GetMyInfo()
    {
        return players[myId];
    }
}
