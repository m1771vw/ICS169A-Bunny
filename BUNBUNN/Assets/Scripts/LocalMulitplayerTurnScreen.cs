﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;

public class LocalMulitplayerTurnScreen : MonoBehaviour
{
    public Text topScore, topPlayer, playerTurn;
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    public string firstimeAchievment = "CgkIitHChdsBEAIQAw";
    PlayGames Gplay = new PlayGames();
    // Use this for initialization
    void Start()
    {

        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();

        ///find top score
        int top = 0;
        for (int i = 0; i < localData.numberOfPlayers-1; i++)
        {
            if (localData.playerData[i].score > top)
            {
                top = localData.playerData[i].score;
                topPlayer.text = "Top Player: Player " + i;
                localData.topPlayer = i;
            }
        }
        /// need to kick to next screen do not remove
        localData.topScore = top;
        /////////////////////////
        topScore.text = "Top Score: " + localData.topScore.ToString();
        playerTurn.text = "Current Player: Player " + localData.playerData[localData.currentPlayer].color;

    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
