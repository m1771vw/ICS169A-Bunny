using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LocalMultiplayerGameData : MonoBehaviour {

    /// <summary>
    /// Setting base data
    /// current player goes from 0 to 4 for ease in arrays and lists
    /// </summary>
    public int currentPlayer = 0;
    public int currentRound = 1;
    public int topScore;
    public static LocalMultiplayerGameData Instance;

    /// <summary>
    /// total list with ALL objects for the game
    /// two lists one with bad objects and one with good
    /// </summary>
    public List<GameObject> trashList = new List<GameObject>();
    public List<GameObject> carrotList = new List<GameObject>();

    [System.Serializable]
    public class PlayerData
    {
        public int score;
        public int carrotsInScene;
        public int trashInScene;
        public int carrotsInPortals;
        public int trashInPortals;
    }
    public PlayerData[] playerData = new PlayerData[5];

    /// <summary>
    /// store information for each players scene
    /// this is used to load the center of the game around the body
    /// </summary>
    public List<GameObject> currentPlayerScene = new List<GameObject>();
    
    /// <summary>
    /// Will be loaded with the ratios of carrots and trash durign level loads
    /// this list contains ALL of the objects for ALL of the portals 
    /// </summary>
    public List<GameObject> currentPortalsContent = new List<GameObject>();


    /// Initialization
    /// Sets the game up for the first round of the game
    /// start with 100 points
    /// 7 trash and 3 carrots loaded in scene
    /// 6 trash in the portals and 2 trash in the scene
    void Start()
    {   
        for(int i = 0; i < 5; i++)
        { 
            playerData[i].score = 300;
            playerData[i].carrotsInScene = 3;
            playerData[i].trashInScene = 7;
            playerData[i].carrotsInPortals = 2;
            playerData[i].trashInPortals = 6;
        }
    }

    /// <summary>
    /// keep this data until main sceen then destroy it
    /// </summary>
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
    /// <summary>
    /// for ease of lists current player goes from 0 - 4
    /// </summary>
    public void nextPlayer()
    {
        if (currentPlayer == 4)
        {
            ++currentRound;
            currentPlayer = 0;
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
