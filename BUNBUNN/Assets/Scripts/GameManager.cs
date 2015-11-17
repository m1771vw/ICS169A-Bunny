using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject topWall, bottomWall, leftWall, rightWall;
    public GameObject topPortal, botPortal, leftPortal, rightPortal;
    public float spawnLocationBuffer = 100f;
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    public List<GameObject> currentPlayerObjects = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
        
        if(localData.currentPlayer == 1)
        {
            currentPlayerObjects = localData.playerOne;
            topPortal.tag = "Player2";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player5";
           
        }
        else if(localData.currentPlayer == 2)
        {
            currentPlayerObjects = localData.playerTwo;
            topPortal.tag = "Player1";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player5";
        }
        else if(localData.currentPlayer == 3)
        {
            currentPlayerObjects = localData.playerThree;
            topPortal.tag = "Player2";
            rightPortal.tag = "Player1";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player5";
        }
        else if(localData.currentPlayer == 4)
        {
            currentPlayerObjects = localData.playerFour;
            topPortal.tag = "Player2";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player1";
            leftPortal.tag = "Player5";

        }
        else if(localData.currentPlayer == 5)
        {
            currentPlayerObjects = localData.playerFive;
            topPortal.tag = "Player2";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player1";
        }
        
        for (int i = 0; i < currentPlayerObjects.Count; i++)
        {
            Vector2 location = new Vector2(Random.Range(leftWall.transform.position.x + spawnLocationBuffer, rightWall.transform.position.x - spawnLocationBuffer),
                                           Random.Range(topWall.transform.position.y - spawnLocationBuffer, bottomWall.transform.position.y + spawnLocationBuffer));

            GameObject node = Instantiate(currentPlayerObjects[i],location,Quaternion.identity) as GameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
