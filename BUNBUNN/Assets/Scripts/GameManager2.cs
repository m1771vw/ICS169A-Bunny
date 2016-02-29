using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{

    public GameObject topWall, bottomWall, leftWall, rightWall;
    public GameObject topPortal, botPortal, leftPortal, rightPortal;
    public int totalObjectCount;
    public float spawnLocationBuffer = 100f;
    public float spawnTimeBuffer = .05f;
    public float xSpawnBuffer;
    public float ySpawnBuffer;
    public float firstRoundStartTime, secondRoundStartTime, thirdRoundStartTime;
    private GameObject dataObject, timeObject;
    private LocalMultiplayerGameData localData;
    private Timer timer;
    public float spawnTime = 14.0f;
    public GameObject centerOfScreen;
    public int speedOfObject = 10;
    public int portalSpawnBuffer = 10;
    public int startingTrashCount;
    public int startingCarrotCount;
    public int bombCount = 0;
    public int bombCap = 3;
    public SpriteRenderer colorChanger;
    public Color player1Color = new Color(255, 255, 255);
    public Color player2Color = new Color(255, 0, 0);
    public Color player3Color = new Color(255, 255, 0);
    public Color player4Color = new Color(0, 0, 255);
    public Color player5Color = new Color(0.5f, 0.5f, 0.5f, 1f);
    public List<GameObject> portalList = new List<GameObject>();
    public float spawnTimeIntervalForDecrementing = 0; 
    public int spawnCounter;
    public Text carrotCountText;


    void Awake()
    {

    }

    /// <summary>
    /// Local data connects to the multiplayer data
    /// using that data the creation of the inital play space is made
    /// load all of the scene and portal contents
    /// </summary>
    void Start()
    {
        carrotCountText = GameObject.Find("CarrotCountText").GetComponent<Text>();
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
        timeObject = GameObject.Find("Timer");
        timer = timeObject.GetComponent<Timer>();
        

        localData.currentPlayerColor = localData.playerData[localData.currentPlayer].color;
        /*
        if (localData.numberOfPlayers >= 1)
        {
            player1Color = localData.playerData[0].realColor;
            player2Color = localData.playerData[1].realColor;
        }
        else if (localData.numberOfPlayers >= 2)
        {
            player3Color = localData.playerData[2].realColor;
        }
        else if (localData.numberOfPlayers >= 3)
        {
            player4Color = localData.playerData[3].realColor;
        }
        else if (localData.numberOfPlayers >= 4)
        {
            player5Color = localData.playerData[4].realColor;
        }*/


        PlayerSetup();
        calculateTotalObjectCount();
        setTimer();

        Debug.Log("time  " + timer.maxTime + "object count   " + totalObjectCount);
        setSpawnTimeIntervalForDecrementing();
        
        sceneSetup();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //check for end of session, round, and game
        if (timer.getTime() <= 0)
        {
            if (localData.currentRound == 3 && localData.currentPlayer == localData.lastPlayer)
            {
                SceneManager.LoadScene("EndGameScreen");
            }
            else
            {
                localData.nextPlayer();
                SceneManager.LoadScene("PlayerTurnScreen");
                Destroy(this.gameObject);
            }
        }
        carrotCountText.text = localData.playerData[localData.currentPlayer].carrotCount.ToString();
        Debug.Log(spawnTime);
        if (localData.currentRound == 1 && timer.getTime() < spawnTime && timer.getTime() > spawnTime - spawnTimeBuffer)
        {
            Debug.Log("spawn");
            for(int i = 0; i < localData.numberOfPlayers - 1; i++)
            {
                if(totalObjectCount != 0)
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.startingObjectList[totalObjectCount - 1]);

                    int random = Random.Range(0, (localData.numberOfPlayers-1));
                    Vector3 direction = new Vector3();
                    direction = portalList[random].transform.position - centerOfScreen.transform.position;
                    direction.Normalize();
                    GameObject node = Instantiate(localData.startingObjectList[totalObjectCount - 1], portalList[random].transform.position - (direction*2) , Quaternion.identity) as GameObject;
                    
                    node.GetComponent<Rigidbody2D>().AddForce(new Vector2(-direction.x*2, -direction.y*2), ForceMode2D.Impulse);
                    
                    totalObjectCount--;
                    spawnCounter++;
                }                
            }
            spawnTime -= spawnTimeIntervalForDecrementing;
        }
        else if(localData.currentRound == 2)
        {
            spawnPortalObjects();
            if (bombCount != bombCap)
            {
                GameObject node = Instantiate(localData.bomb, centerOfScreen.transform.position, Quaternion.identity) as GameObject;
                bombCount++;
            }
        }



        //spawnPortalObjects();
    }

    void setTimer()
    {
        if (localData.currentRound == 1)
        {
            timer.setStartTime(firstRoundStartTime);
            totalObjectCount = localData.startingObjectList.Count;
            

        }
        else if (localData.currentRound == 2)
        {
            timer.setStartTime(secondRoundStartTime);
        }
        else
        {
            timer.setStartTime(thirdRoundStartTime);
        }
        spawnTime = timer.maxTime - (float).5f;
    }

    void setSpawnTimeIntervalForDecrementing()
    {
        float temp = (float)totalObjectCount / (float)(localData.numberOfPlayers -1);
        Debug.Log("obj count " + totalObjectCount + "total players" + localData.numberOfPlayers);
        Debug.Log("temp " + temp);
        spawnTimeIntervalForDecrementing = (float)timer.maxTime / (float)temp;
        Debug.Log("time max " + timer.maxTime);
        Debug.Log(spawnTimeIntervalForDecrementing);
    }

    void calculateTotalObjectCount()
    {
        if (localData.playerData[localData.currentPlayer].color == "White")
        {
           totalObjectCount = localData.playerData[localData.currentPlayer].player2PortalContents.Count + localData.playerData[localData.currentPlayer].player3PortalContents.Count
                + localData.playerData[localData.currentPlayer].player4PortalContents.Count + localData.playerData[localData.currentPlayer].player5PortalContents.Count;
        }
        else if (localData.playerData[localData.currentPlayer].color == "Red")
        {
            totalObjectCount = localData.playerData[localData.currentPlayer].player1PortalContents.Count + localData.playerData[localData.currentPlayer].player3PortalContents.Count
                + localData.playerData[localData.currentPlayer].player4PortalContents.Count + localData.playerData[localData.currentPlayer].player5PortalContents.Count;
        }
        else if (localData.playerData[localData.currentPlayer].color == "Yellow")
        {
            totalObjectCount = localData.playerData[localData.currentPlayer].player1PortalContents.Count + localData.playerData[localData.currentPlayer].player2PortalContents.Count
                + localData.playerData[localData.currentPlayer].player4PortalContents.Count + localData.playerData[localData.currentPlayer].player5PortalContents.Count;
        }
        else if (localData.playerData[localData.currentPlayer].color == "Blue")
        {
            totalObjectCount = localData.playerData[localData.currentPlayer].player1PortalContents.Count + localData.playerData[localData.currentPlayer].player2PortalContents.Count
                + localData.playerData[localData.currentPlayer].player3PortalContents.Count + localData.playerData[localData.currentPlayer].player5PortalContents.Count;
        }
        else if (localData.playerData[localData.currentPlayer].color == "Gray")
        {
            totalObjectCount = localData.playerData[localData.currentPlayer].player1PortalContents.Count + localData.playerData[localData.currentPlayer].player2PortalContents.Count
                + localData.playerData[localData.currentPlayer].player4PortalContents.Count + localData.playerData[localData.currentPlayer].player3PortalContents.Count;
        }
        Debug.Log("in clac object" + totalObjectCount);

    }

    //FUNNELS STILL LIVE
    // set inactive for parents of the prefab
    //DONT TOUCH UNLESS ADDING MORE PLAYERS
    //code sorts the scene and controls the colors of the portals
    //the attachment of the portals to specific players
    //and changes it based on the number players in the game
    void PlayerSetup()
    {

        ///Change portal tags for collision detection in order to put the objects in the correct buckets
        if (localData.playerData[localData.currentPlayer].color == "White")
        {
            if (localData.numberOfPlayers == 2)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                Destroy(rightPortal.GetComponent<Collider2D>());
                Destroy(rightPortal.GetComponent<SpriteRenderer>());
                Destroy(botPortal.GetComponent<Collider2D>());
                Destroy(botPortal.GetComponent<SpriteRenderer>());
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());
            }
            if (localData.numberOfPlayers == 3)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
                Destroy(botPortal.GetComponent<Collider2D>());
                Destroy(botPortal.GetComponent<SpriteRenderer>());
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());
            }
            if (localData.numberOfPlayers == 4)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player4Color;
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());

            }
            if (localData.numberOfPlayers == 5)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player4Color;
                leftPortal.tag = "Player5";
                colorChanger = leftPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player5Color;
            }
        }
            /*
            topPortal.tag = "Player1";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player5";
            */
        else if (localData.playerData[localData.currentPlayer].color == "Red")
        {
            if (localData.numberOfPlayers == 2)
            {
                topPortal.tag = "Player1";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
                Destroy(rightPortal.GetComponent<Collider2D>());
                Destroy(rightPortal.GetComponent<SpriteRenderer>());
                Destroy(botPortal.GetComponent<Collider2D>());
                Destroy(botPortal.GetComponent<SpriteRenderer>());
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());
            }
            if (localData.numberOfPlayers == 3)
            {
                topPortal.tag = "Player1";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
                Destroy(botPortal.GetComponent<Collider2D>());
                Destroy(botPortal.GetComponent<SpriteRenderer>());
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());
            }
            if (localData.numberOfPlayers == 4)
            {
                topPortal.tag = "Player1";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player4Color;
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());

            }
            if (localData.numberOfPlayers == 5)
            {
                topPortal.tag = "Player1";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player4Color;
                leftPortal.tag = "Player5";
                colorChanger = leftPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player5Color;
            }
        }
            /*
            topPortal.tag = "Player2";
            rightPortal.tag = "Player1";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player5";
            */
        else if (localData.playerData[localData.currentPlayer].color == "Yellow")
        {
            if (localData.numberOfPlayers == 3)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                rightPortal.tag = "Player1";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
                Destroy(botPortal.GetComponent<Collider2D>());
                Destroy(botPortal.GetComponent<SpriteRenderer>());
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());
            }
            if (localData.numberOfPlayers == 4)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                rightPortal.tag = "Player1";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player4Color;
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());

            }
            if (localData.numberOfPlayers == 5)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                rightPortal.tag = "Player1";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player4Color;
                leftPortal.tag = "Player5";
                colorChanger = leftPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player5Color;
            }
        }
            /*
            topPortal.tag = "Player2";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player1";
            leftPortal.tag = "Player5";
            */
        else if (localData.playerData[localData.currentPlayer].color == "Blue")
        {
            if (localData.numberOfPlayers == 4)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
                botPortal.tag = "Player1";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());

            }
            if (localData.numberOfPlayers == 5)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
                botPortal.tag = "Player1";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
                leftPortal.tag = "Player5";
                colorChanger = leftPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player5Color;
            }
        }
            /*
            topPortal.tag = "Player2";
            rightPortal.tag = "Player3";
            botPortal.tag = "Player4";
            leftPortal.tag = "Player1";
            */
        else if (localData.playerData[localData.currentPlayer].color == "Gray")
        {
            if (localData.numberOfPlayers == 5)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player4Color;
                leftPortal.tag = "Player1";
                colorChanger = leftPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
            }
        }
    }


    //place object back on to the scene
    //color them the corresponding color (if player1Color player is up his leftovers are HIS color)
    void sceneSetup()
    {
        Vector2 location = new Vector2(Random.Range(leftWall.transform.position.x + spawnLocationBuffer, rightWall.transform.position.x - spawnLocationBuffer),
                                           Random.Range(topWall.transform.position.y - spawnLocationBuffer, bottomWall.transform.position.y + spawnLocationBuffer));
        if (localData.playerData[localData.currentPlayer].color == "White")
        {
            for (int i = 0; i < localData.playerData[localData.currentPlayer].currentSceneObjects.Count; i++)
            {
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].currentSceneObjects[i], location, Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
            }
        }
        else if (localData.playerData[localData.currentPlayer].color == "Red")
        {
            for (int i = 0; i < localData.playerData[localData.currentPlayer].currentSceneObjects.Count; i++)
            {
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].currentSceneObjects[i], location, Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
            }
        }
        else if (localData.playerData[localData.currentPlayer].color == "Yellow")
        {
            for (int i = 0; i < localData.playerData[localData.currentPlayer].currentSceneObjects.Count; i++)
            {
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].currentSceneObjects[i], location, Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
            }
        }
        else if (localData.playerData[localData.currentPlayer].color == "Blue")
        {
            for (int i = 0; i < localData.playerData[localData.currentPlayer].currentSceneObjects.Count; i++)
            {
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].currentSceneObjects[i], location, Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player4Color;
            }
        }
        else if (localData.playerData[localData.currentPlayer].color == "Gray")
        {
            for (int i = 0; i < localData.playerData[localData.currentPlayer].currentSceneObjects.Count; i++)
            {
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].currentSceneObjects[i], location, Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player5Color;
            }
        }
    }

    void spawnPortalObjects()
    {
        if (localData.playerData[localData.currentPlayer].color == "White" && timer.getTime() < spawnTime && timer.getTime() > spawnTime - spawnTimeBuffer)
        {
            //Debug.Log("spawn from portal");
            if (localData.playerData[localData.currentPlayer].player2PortalContents.Count != 0)
            {
                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player2").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player2PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player2PortalContents[0]);
                localData.playerData[localData.currentPlayer].player2PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player3PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player3").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player3PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player3PortalContents[0]);
                localData.playerData[localData.currentPlayer].player3PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player4PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player4").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player4PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player4Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player4PortalContents[0]);
                localData.playerData[localData.currentPlayer].player4PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player5PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player5").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player5PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player5Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player5PortalContents[0]);
                localData.playerData[localData.currentPlayer].player5PortalContents.RemoveAt(0);
            }
            spawnTime -= spawnTimeIntervalForDecrementing;
        }
        else if (localData.playerData[localData.currentPlayer].color == "Red" && timer.getTime() < spawnTime && timer.getTime() > spawnTime - spawnTimeBuffer)
        {

            if (localData.playerData[localData.currentPlayer].player1PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player1").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player1PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player1PortalContents[0]);
                localData.playerData[localData.currentPlayer].player1PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player3PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player3").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player3PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player3PortalContents[0]);
                localData.playerData[localData.currentPlayer].player3PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player4PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player4").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player4PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player4Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player4PortalContents[0]);
                localData.playerData[localData.currentPlayer].player4PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player5PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player5").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player5PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player5Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player5PortalContents[0]);
                localData.playerData[localData.currentPlayer].player5PortalContents.RemoveAt(0);
            }
            spawnTime -= spawnTimeIntervalForDecrementing;
        }
        else if (localData.playerData[localData.currentPlayer].color == "Yellow" && timer.getTime() < spawnTime && timer.getTime() > spawnTime - spawnTimeBuffer)
        {

            if (localData.playerData[localData.currentPlayer].player1PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player1").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player1PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player1PortalContents[0]);
                localData.playerData[localData.currentPlayer].player1PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player3PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player2").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player2PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player2PortalContents[0]);
                localData.playerData[localData.currentPlayer].player2PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player4PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player4").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player4PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player4Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player4PortalContents[0]);
                localData.playerData[localData.currentPlayer].player4PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player5PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player5").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player5PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player5Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player5PortalContents[0]);
                localData.playerData[localData.currentPlayer].player5PortalContents.RemoveAt(0);
            }
            spawnTime -= spawnTimeIntervalForDecrementing;
        }
        else if (localData.playerData[localData.currentPlayer].color == "Blue" && timer.getTime() < spawnTime && timer.getTime() > spawnTime - spawnTimeBuffer)
        {

            if (localData.playerData[localData.currentPlayer].player1PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player1").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player1PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player1PortalContents[0]);
                localData.playerData[localData.currentPlayer].player1PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player3PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player2").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player2PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player2PortalContents[0]);
                localData.playerData[localData.currentPlayer].player2PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player3PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player3").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player3PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player3PortalContents[0]);
                localData.playerData[localData.currentPlayer].player3PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player5PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player5").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player5PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player5Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player5PortalContents[0]);
                localData.playerData[localData.currentPlayer].player5PortalContents.RemoveAt(0);
            }
            spawnTime -= spawnTimeIntervalForDecrementing;
        }
        else if (localData.playerData[localData.currentPlayer].color == "Gray" && timer.getTime() < spawnTime && timer.getTime() > spawnTime - spawnTimeBuffer)
        {

            if (localData.playerData[localData.currentPlayer].player1PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player1").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player1PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player1Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player1PortalContents[0]);
                localData.playerData[localData.currentPlayer].player1PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player3PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player2").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player2PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player2Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player2PortalContents[0]);
                localData.playerData[localData.currentPlayer].player2PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player3PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player3").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player3PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player3Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player3PortalContents[0]);
                localData.playerData[localData.currentPlayer].player3PortalContents.RemoveAt(0);
            }
            if (localData.playerData[localData.currentPlayer].player5PortalContents.Count != 0)
            {

                Vector2 location = new Vector2();
                location = GameObject.FindGameObjectWithTag("Player4").transform.position;
                location += location;
                GameObject node = Instantiate(localData.playerData[localData.currentPlayer].player4PortalContents[0], transform.position + (transform.forward * 2), Quaternion.identity) as GameObject;
                colorChanger = node.GetComponent<SpriteRenderer>();
                colorChanger.color = player5Color;
                localData.playerData[localData.currentPlayer].currentSceneObjects.Add(localData.playerData[localData.currentPlayer].player4PortalContents[0]);
                localData.playerData[localData.currentPlayer].player4PortalContents.RemoveAt(0);
            }
            spawnTime -= spawnTimeIntervalForDecrementing;
        }
    }
}
