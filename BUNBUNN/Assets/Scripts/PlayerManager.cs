using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour {

    private int inputNum = 2;

    private List<GameObject> listOfPlayerBalls;
    private GameObject[] playerBallArray;
    //just stores the prefabs. use the game object variables above. 

    
	// Use this for initialization
	void Start () 
    {

        listOfPlayerBalls = new List<GameObject>();
        playerBallArray = GameObject.FindGameObjectsWithTag("ColorBall");
        for (int i = 0; i < playerBallArray.Length; i++)
        {
            listOfPlayerBalls.Add(playerBallArray[i]);
        }

	}

}
