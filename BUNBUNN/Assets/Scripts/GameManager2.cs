using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{

    public GameObject topWall, bottomWall, leftWall, rightWall;
    public GameObject topPortal, botPortal, leftPortal, rightPortal;
    public float spawnLocationBuffer = 100f;
    private GameObject dataObject, timeObject;
    private LocalMultiplayerGameData localData;
    private Timer timer;
    public int spawnTime = 14;
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

        PlayerSetup();

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
        //check for end of session, round, and game
        if (timer.getTime() == 0)
        {
            if (localData.currentRound == 3 && localData.currentPlayer == localData.lastPlayer)
            {
                SceneManager.LoadScene("EndLocalGameScreen");
            }
            else
            {
                //portalListSectioned.Clear();
                localData.nextPlayer();
                SceneManager.LoadScene("Calibration");
                Destroy(this.gameObject);
            }
        }
    }

    //DONT TOUCH UNLESS ADDING MORE PLAYERS
    //code sorts the scene and controls the colors of the portals
    //the attachment of the portals to specific players
    //and changes it based on the number players in the game
    void PlayerSetup()
    {
        SpriteRenderer colorChanger;
        Color white = new Color(255, 255, 255);
        Color red = new Color(255, 0, 0);
        Color yellow = new Color(255, 255, 0);
        Color blue = new Color(0, 0, 255);
        Color gray = new Color(0.5f, 0.5f, 0.5f, 1f);
        ///Change portal tags for collision detection in order to put the objects in the correct buckets
        if (localData.playerData[localData.currentPlayer].color == "White")
        {
            if (localData.numberOfPlayers == 2)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = red;
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
                colorChanger.color = red;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = yellow;
                Destroy(botPortal.GetComponent<Collider2D>());
                Destroy(botPortal.GetComponent<SpriteRenderer>());
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());
            }
            if (localData.numberOfPlayers == 4)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = red;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = yellow;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = blue;
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());

            }
            if (localData.numberOfPlayers == 5)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = red;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = yellow;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = blue;
                leftPortal.tag = "Player5";
                colorChanger = leftPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = gray;
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
                colorChanger.color = white;
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
                colorChanger.color = white;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = yellow;
                Destroy(botPortal.GetComponent<Collider2D>());
                Destroy(botPortal.GetComponent<SpriteRenderer>());
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());
            }
            if (localData.numberOfPlayers == 4)
            {
                topPortal.tag = "Player1";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = white;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = yellow;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = blue;
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());

            }
            if (localData.numberOfPlayers == 5)
            {
                topPortal.tag = "Player1";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = white;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = yellow;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = blue;
                leftPortal.tag = "Player5";
                colorChanger = leftPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = gray;
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
                colorChanger.color = red;
                rightPortal.tag = "Player1";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = white;
                Destroy(botPortal.GetComponent<Collider2D>());
                Destroy(botPortal.GetComponent<SpriteRenderer>());
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());
            }
            if (localData.numberOfPlayers == 4)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = red;
                rightPortal.tag = "Player1";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = white;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = blue;
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());

            }
            if (localData.numberOfPlayers == 5)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = red;
                rightPortal.tag = "Player1";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = white;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = blue;
                leftPortal.tag = "Player5";
                colorChanger = leftPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = gray;
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
                colorChanger.color = red;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = yellow;
                botPortal.tag = "Player1";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = white;
                Destroy(leftPortal.GetComponent<Collider2D>());
                Destroy(leftPortal.GetComponent<SpriteRenderer>());

            }
            if (localData.numberOfPlayers == 5)
            {
                topPortal.tag = "Player2";
                colorChanger = topPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = red;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = yellow;
                botPortal.tag = "Player1";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = white;
                leftPortal.tag = "Player5";
                colorChanger = leftPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = gray;
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
                colorChanger.color = red;
                rightPortal.tag = "Player3";
                colorChanger = rightPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = yellow;
                botPortal.tag = "Player4";
                colorChanger = botPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = blue;
                leftPortal.tag = "Player1";
                colorChanger = leftPortal.GetComponent<SpriteRenderer>();
                colorChanger.color = white;
            }
        }
    }
}
