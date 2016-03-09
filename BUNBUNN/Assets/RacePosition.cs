using UnityEngine;
using System.Collections;

public class RacePosition : MonoBehaviour {
    public GameObject maxPosition, minPosition;
    public GameObject Player1, Player2, Player3, Player4, Player5;
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    private Vector3 endPosition, startPosition;
    private int maxScore;
    public int lerpTime = 100;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    // Use this for initialization
    void Start () {
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
        setPreviousPlayerUpright();
        maxScore = localData.getMaxScore()/2;

        Debug.Log("max Score >>>  " + localData.getMaxScore());
        Debug.Log("previous player >>>  " + localData.getPreviousPlayer());
        Debug.Log("previous player Score before game >>>  " + localData.playerData[localData.getPreviousPlayer()].preTurnScore);
        Debug.Log("previous player Score post game >>>  " + localData.playerData[localData.getPreviousPlayer()].score);

        //set the pre score for the next player
        localData.playerData[localData.currentPlayer].preTurnScore = localData.playerData[localData.currentPlayer].score;

        initializePlayerPositions();

        //change the position of the player who just went to animation start
        float previousScoreInPercentage = localData.playerData[localData.getPreviousPlayer()].preTurnScore / (float)maxScore;
        Vector2 temp = new Vector2();
        temp.x = maxPosition.transform.position.x * previousScoreInPercentage;
        //calc and lerp for the previous player
        //first we calculate the percent of the previous score and the current score
        // then multiply the max position (the end of the number line) with percentage for each
        // take the new positons and lerp between them
        float currentScoreInPercentage = localData.playerData[localData.getPreviousPlayer()].score / (float)maxScore;
        Debug.Log(temp.x + "<<< position and percentage >> " + currentScoreInPercentage);
        startPosition.x = maxPosition.transform.position.x * previousScoreInPercentage;
        endPosition.x = maxPosition.transform.position.x * currentScoreInPercentage;
        
        if (localData.playerData[localData.getPreviousPlayer()].color == "White")
        {
            Player1.transform.position = temp; 
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Red")
        {
            Player2.transform.position = temp;
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Yellow")
        {
            Player3.transform.position = temp;
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Blue")
        {
            Player4.transform.position = temp;
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Gray")
        {
            Player5.transform.position = temp;
        }

        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, endPosition);
}

	// Update is called once per frame
	void Update ()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        //transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);

        //lerp it
        if (localData.playerData[localData.getPreviousPlayer()].color == "White")
        {
            Player1.transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Red")
        {
            Player2.transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Yellow")
        {
            Player3.transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Blue")
        {
            Player4.transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Gray")
        {
            Player5.transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
        }
    }
    void setPreviousPlayerUpright()
    {
        Vector3 upright = new Vector3();
        upright.y = 0;
        if (localData.playerData[localData.getPreviousPlayer()].color == "White")
        {
            Player1.transform.position = upright;
            Player1.transform.Rotate(0, 0, 180);

        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Red")
        {
            Player2.transform.position = upright;
            Player2.transform.Rotate(0, 0, 180);
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Yellow")
        {
            Player3.transform.position = upright;
            Player3.transform.Rotate(0, 0, 180);
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Blue")
        {
            Player4.transform.position = upright;
            Player4.transform.Rotate(0, 0, 180);
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Gray")
        {
            Player5.transform.position = upright;
            Player5.transform.Rotate(0,0,180);
        }
    }


    //used for click and pass feature
    public void setCurrentPlayerUprightAndPreviousDown()
    {
        Vector3 upright = new Vector3();
        upright.y = 0;
        Vector3 down = new Vector3();
        down.y = -2;
        if (localData.playerData[localData.getPreviousPlayer()].color == "White")
        {
            Player1.transform.position = upright;
            Player1.transform.Rotate(0, 0, 180);
            Player1.transform.position = down;
            Player1.transform.Rotate(0, 0, 180);
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Red")
        {
            Player2.transform.position = upright;
            Player2.transform.Rotate(0, 0, 180);
            Player2.transform.position = down;
            Player2.transform.Rotate(0, 0, 180);
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Yellow")
        {
            Player3.transform.position = upright;
            Player3.transform.Rotate(0, 0, 180);
            Player3.transform.position = down;
            Player3.transform.Rotate(0, 0, 180);
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Blue")
        {
            Player4.transform.position = upright;
            Player4.transform.Rotate(0, 0, 180);
            Player4.transform.position = down;
            Player4.transform.Rotate(0, 0, 180);
        }
        else if (localData.playerData[localData.getPreviousPlayer()].color == "Gray")
        {
            Player5.transform.position = upright;
            Player5.transform.Rotate(0, 0, 180);
            Player5.transform.position = down;
            Player5.transform.Rotate(0, 0, 180);
        }
    }

    void initializePlayerPositions()
    {
        if (localData.numberOfPlayers == 2)
        {
            Destroy(Player3);
            Destroy(Player4);
            Destroy(Player5);
        }
        else if(localData.numberOfPlayers == 3)
        {
            Destroy(Player4);
            Destroy(Player5);
        }
        else if (localData.numberOfPlayers == 4)
        {
            Destroy(Player5);
        }
        Vector2 temp = new Vector2();
        temp.y = -2;
        //set player positions
        for (int i = 0; i < localData.numberOfPlayers; i++)
        {
            float percentForPositionCalc = localData.playerData[i].score / (float)maxScore;
            if (i == 0)
            {
                temp.x = maxPosition.transform.position.x * percentForPositionCalc;
                Player1.transform.position = temp;
            }
            else if (i == 1)
            {
                temp.x = maxPosition.transform.position.x * percentForPositionCalc;
                Player2.transform.position = temp;
            }
            else if (i == 2)
            {
                temp.x = maxPosition.transform.position.x * percentForPositionCalc;
                Player3.transform.position = temp;
            }
            else if (i == 3)
            {
                temp.x = maxPosition.transform.position.x * percentForPositionCalc;
                Player4.transform.position = temp;
            }
            else if (i == 4)
            {
                temp.x = maxPosition.transform.position.x * percentForPositionCalc;
                Player5.transform.position = temp;
            }
        }
    }

}
