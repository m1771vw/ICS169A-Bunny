using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public GameObject topWall, bottomWall, leftWall, rightWall;
    public GameObject topPortal, botPortal, leftPortal, rightPortal;
    public float spawnLocationBuffer = 100f;
    private GameObject dataObject, timeObject;
    private LocalMultiplayerGameData localData;
    private Timer timer;
    public int spawnTime = 28;
    public int spawnRound = 0;
    public int spawnCap = 0;
    private Dictionary<int, List<GameObject>> portalListSectioned;
    public GameObject centerOfScreen;
    public int speedOfObject = 10;

    /// <summary>
    /// Local data connects to the multiplayer data
    /// using that data the creation of the inital play space is made
    /// load all of the scene and portal contents
    /// </summary>
    void Start()
    {
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
        timeObject = GameObject.Find("Timer");
        timer = timeObject.GetComponent<Timer>();
        portalListSectioned = new Dictionary<int, List<GameObject>>();

        localData.currentPlayerScene.Clear();
        localData.currentPlayerScene.TrimExcess();

        ///Load objects into the scene
        for (int i = 0; i < localData.playerData[localData.currentPlayer].carrotsInScene; i++)
        {
            localData.currentPlayerScene.Add(localData.carrotList[0]);
        }
        for (int i = 0; i < localData.playerData[localData.currentPlayer].trashInScene; i++)
        {
            int randomInt = Random.Range(0, 3);
            localData.currentPlayerScene.Add(localData.trashList[randomInt]);
        }

        /// Load objects into the portals for spawning
        for (int i = 0; i < localData.playerData[localData.currentPlayer].carrotsInPortals; i++)
        {
            localData.currentPortalsContent.Add(localData.carrotList[0]);
        }
        for (int i = 0; i < localData.playerData[localData.currentPlayer].trashInPortals; i++)
        {
            int randomInt = Random.Range(0, 3);
            localData.currentPortalsContent.Add(localData.trashList[randomInt]);
        }
        ///create a gated spawn
        /// this takes in a time gate 0, 1st, 2nd, 3rd etc.
        /// then a list of game objects to be spawned at that time
        for (int i = 0; i < 15; i++)
        {
            List<GameObject> objectList = new List<GameObject>();
            portalListSectioned.Add(i, objectList);
        }

        ///Shuffle the list of data for portals
        /// this is to randomize what will come out at each spawn
        /// interval 
        int n = localData.currentPortalsContent.Count - 1;
        while (n > 0)
        {
            int rng = Random.Range(0, n);
            n--;
            int k = rng;
            GameObject value = localData.currentPortalsContent[k];
            localData.currentPortalsContent[k] = localData.currentPortalsContent[n];
            localData.currentPortalsContent[n] = value;
        }

        ///loading up the time gates with the proper objects
        ///fills all the level 0 buckets, then 1, then 2 ect.
        int j = 0;
        int l = 0;
        int count = localData.currentPortalsContent.Count;
        spawnCap = count;
        while (count != 0)
        {
            portalListSectioned[j].Add(localData.currentPortalsContent[l]);
            l++;
            if (j != 11)
            {
                j++;
            }
            else
            {
                j = 0;
            }
            count--;
        }

        ///Change portal tags for collision detection in order to put the objects in the correct buckets
        if (localData.currentPlayer == 0)
        {
            topPortal.tag = "Player2";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player5";
        }
        else if (localData.currentPlayer == 1)
        {
            topPortal.tag = "Player1";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player5";
        }
        else if (localData.currentPlayer == 2)
        {
            topPortal.tag = "Player2";
            rightPortal.tag = "Player1";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player5";
        }
        else if (localData.currentPlayer == 3)
        {
            topPortal.tag = "Player2";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player1";
            leftPortal.tag = "Player5";

        }
        else if (localData.currentPlayer == 4)
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

            GameObject node = Instantiate(localData.currentPlayerScene[i], location, Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (timer.getTime() == 0)
        {
            if (localData.currentRound == 2 && localData.currentPlayer == 4)
            {
                Application.LoadLevel("EndLocalGameScreen");
            }
            else
            {
                portalListSectioned.Clear();
                localData.nextPlayer();
                Application.LoadLevel("Calibration");
                Destroy(this.gameObject);
            }
        }

        if (timer.getTime() == spawnTime && spawnRound < spawnCap && spawnRound <= 14)
        {
            for (int i = 0; i < portalListSectioned[spawnRound].Count; i++)
            {
                if (portalListSectioned[spawnRound][i].tag == "trash")
                {
                    localData.playerData[localData.currentPlayer].score -= localData.trashScoreWorth;
                }
                else
                {
                    localData.playerData[localData.currentPlayer].score += localData.carrotScoreWorth;
                }

                int portalNumber = Random.Range(0, 3);
                if (portalNumber == 0)
                {
                    Instantiate(portalListSectioned[spawnRound][i], GameObject.Find("TopSpawn").transform.position, Quaternion.identity);
                }
                else if (portalNumber == 1)
                {
                    Instantiate(portalListSectioned[spawnRound][i], GameObject.Find("LeftSpawn").transform.position, Quaternion.identity);
                }
                else if (portalNumber == 2)
                {
                    Instantiate(portalListSectioned[spawnRound][i], GameObject.Find("RightSpawn").transform.position, Quaternion.identity);
                }
                else if (portalNumber == 3)
                {
                    Instantiate(portalListSectioned[spawnRound][i], GameObject.Find("BotSpawn").transform.position, Quaternion.identity);
                }
            }
            spawnTime -= 2;
            ++spawnRound;
        }

    }
}
