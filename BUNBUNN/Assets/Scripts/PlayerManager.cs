using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour {

    public GameObject P1, P2, P3, P4, P5;

    public int inputNum = 0;
    public GameObject bunnyHead;
   
    private GameObject[] playerBallArray;

    public bool p1filled, p2filled, p3filled, p4filled, p5filled;
    //just stores the prefabs. use the game object variables above. 

    
	// Use this for initialization
	void Start () 
    {
        p1filled = false;
        p2filled = false;
        p3filled = false; 
        p4filled = false; 
        p5filled = false;
        P3.SetActive(false);
        P4.SetActive(false);
        P5.SetActive(false);
        //listOfPlayerBalls = new List<GameObject>();
        //playerBallArray = GameObject.FindGameObjectsWithTag("ColorBall");
        //for (int i = 0; i < playerBallArray.Length; i++)
        //{
        //    listOfPlayerBalls.Add(playerBallArray[i]);
        //}

	}

    public void addOneToPlayerCount()
    {
        if (inputNum == 0)
        {
            p1filled = true;
        }
        else if (inputNum == 1)
        {
            p2filled = true;
            P3.SetActive(true);
        }
        else if (inputNum == 2)
        {
            p3filled = true;
            P4.SetActive(true);
        }
        else if (inputNum == 3)
        {
            p4filled = true;
            P5.SetActive(true);
        }
        else if (inputNum == 4)
        {
            p5filled = true;
            
        }
        inputNum++;
    }

    public void subOneToPlayerCount()
    {
        if (inputNum == 4)
        {
            p5filled = false;
            P5.SetActive(false);
            bunnyHead.SetActive(true);
            bunnyHead.transform.position = new Vector3(0, 3.31f, 0);
            
        }
        else if (inputNum == 3)
        {
            p4filled = false;
            P4.SetActive(false);
        }
        else if (inputNum == 2)
        {
            p3filled = false;
            P3.SetActive(false);
        }
        else if (inputNum == 1)
        {
            p2filled = true;
        }
        else if (inputNum == 0)
        {
            p1filled = false;

        }
        inputNum--;
    }

}
