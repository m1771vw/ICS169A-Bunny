using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LocalMultiplayerGameData : MonoBehaviour {

    public int currentPlayer = 1;
    public int[] playerScores = new int[5];

    public List<GameObject> trashList = new List<GameObject>();
    public List<GameObject> carrotList = new List<GameObject>();

    public static LocalMultiplayerGameData Instance;

    public List<GameObject> playerOne = new List<GameObject>();
    public List<GameObject> playerTwo = new List<GameObject>();
    public List<GameObject> playerThree = new List<GameObject>();
    public List<GameObject> playerFour = new List<GameObject>();
    public List<GameObject> playerFive = new List<GameObject>();

    public int portalOneTrash, portalTwoTrash, portalThreeTrash, portalFourTrash, portalFiveTrash;

    public List<GameObject> portalOneContents = new List<GameObject>();
    public List<GameObject> portalTwoContents = new List<GameObject>();
    public List<GameObject> portalThreeContents = new List<GameObject>();
    public List<GameObject> portalFourContents = new List<GameObject>();
    public List<GameObject> portalFiveContents = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            playerScores[i] = 0;
        }

        //insert trash
        for (int i = 0; i < 7; i++)
        {
            int randomTrash1 = Random.Range(0, 3);
            int randomTrash2 = Random.Range(0, 3);
            int randomTrash3 = Random.Range(0, 3);
            int randomTrash4 = Random.Range(0, 3);
            int randomTrash5 = Random.Range(0, 3);

            playerOne.Add(trashList[randomTrash1]);
            playerTwo.Add(trashList[randomTrash2]);
            playerThree.Add(trashList[randomTrash3]);
            playerFour.Add(trashList[randomTrash4]);
            playerFive.Add(trashList[randomTrash5]);
        }

        //load carrots
        for (int i = 0; i < 3; i++)
        {
            playerOne.Add(carrotList[0]);
            playerTwo.Add(carrotList[0]);
            playerThree.Add(carrotList[0]);
            playerFour.Add(carrotList[0]);
            playerFive.Add(carrotList[0]);
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void nextPlayer()
    {
        if (currentPlayer == 5)
        {
            currentPlayer = 1;
        }
        else
        {
            ++currentPlayer;
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
