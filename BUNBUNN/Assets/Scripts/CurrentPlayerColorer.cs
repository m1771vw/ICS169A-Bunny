using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CurrentPlayerColorer : MonoBehaviour {
    LocalMultiplayerGameData data;
	// Use this for initialization
	void Start () {
        data = GameObject.Find("LocalMultiplayerGameData").GetComponent<LocalMultiplayerGameData>();
        GameManager2 gameManager = GameObject.Find("GameManager").GetComponent<GameManager2>();
        int currentPlayerNumber = data.currentPlayer;
        if (currentPlayerNumber == 0)
        {
            Debug.Log(gameManager.player1Color);
            GetComponent<Image>().color = gameManager.player1Color;
        }
        else if (currentPlayerNumber == 1)
        {
            GetComponent<Image>().color = gameManager.player2Color;
        }
        else if (currentPlayerNumber == 2)
        {
            GetComponent<Image>().color = gameManager.player3Color;
        }
        else if (currentPlayerNumber == 3)
        {
            GetComponent<Image>().color = gameManager.player4Color;
        }
        else if (currentPlayerNumber == 4)
        {
            GetComponent<Image>().color = gameManager.player5Color;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
