using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject topWall, bottomWall, leftWall, rightWall;
    public GameObject topPortal, botPortal, leftPortal, rightPortal;
    public float spawnLocationBuffer = 100f;
    private GameObject dataObject,timeObject;
    private LocalMultiplayerGameData localData;
    private Timer timer;
    
    /// <summary>
    /// Local data connects to the multiplayer data
    /// using that data the creation of the inital play space is made
    /// load all of the scene and portal contents
    /// </summary>
    void Start ()
    {
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
        timeObject = GameObject.Find("Timer");
        timer = timeObject.GetComponent<Timer>();

        localData.currentPlayerScene.Clear();
        localData.currentPlayerScene.TrimExcess();

        ///Load objects into the scene
        for (int i = 0; i < localData.playerData[localData.currentPlayer].carrotsInScene; i++)
        {
            localData.currentPlayerScene.Add(localData.carrotList[0]);
        }
        for (int i = 0; i < localData.playerData[localData.currentPlayer].trashInScene; i++)
        {
            int randomInt = Random.Range(0, 2);
            localData.currentPlayerScene.Add(localData.trashList[randomInt]);
        }

        /// Load objects into the portals for spawning
        for (int i = 0; i < localData.playerData[localData.currentPlayer].carrotsInPortals; i++)
        {
            localData.currentPortalsContent.Add(localData.carrotList[0]);
        }
        for (int i = 0; i < localData.playerData[localData.currentPlayer].trashInPortals; i++)
        {
            int randomInt = Random.Range(0, 2);
            localData.currentPortalsContent.Add(localData.trashList[randomInt]);
        }

        ///Change portal tags for collision detection in order to put the objects in the correct buckets
        if (localData.currentPlayer == 0)
        {
            topPortal.tag = "Player2";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player5";
           
        }
        else if(localData.currentPlayer == 1)
        {
            topPortal.tag = "Player1";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player5";
        }
        else if(localData.currentPlayer == 2)
        {
            topPortal.tag = "Player2";
            rightPortal.tag = "Player1";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player5";
        }
        else if(localData.currentPlayer == 3)
        {
            topPortal.tag = "Player2";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player1";
            leftPortal.tag = "Player5";

        }
        else if(localData.currentPlayer == 4)
        {
            topPortal.tag = "Player2";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player1";
        }
        
        ///randomly spawn game objects near bunny
        for (int i = 0; i < localData.currentPlayerScene.Count; i++)
        {
            Vector2 location = new Vector2(Random.Range(leftWall.transform.position.x + spawnLocationBuffer, rightWall.transform.position.x - spawnLocationBuffer),
                                           Random.Range(topWall.transform.position.y - spawnLocationBuffer, bottomWall.transform.position.y + spawnLocationBuffer));

            GameObject node = Instantiate(localData.currentPlayerScene[i], location,Quaternion.identity) as GameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (timer.getTime() == 0)
        {
            localData.nextPlayer();
            Application.LoadLevel("Calibration");
        }

	}
}
