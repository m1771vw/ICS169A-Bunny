using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LocalMultiplayerGameData : MonoBehaviour
{

    /// <summary>
    /// Setting base data
    /// current player goes from 0 to 4 for ease in arrays and lists
    /// </summary>
    public int numberOfPlayers = 2;
    public int currentPlayer = 0;
    public int currentRound = 1;
    public int topScore;
    public int topPlayer;
    public static LocalMultiplayerGameData Instance;
    public int trashScoreWorth = 30;
    public int carrotScoreWorth;
    public List<int> playerOrder = new List<int>();
    public int lastPlayer;
    public int playerIndex;


    /// <summary>
    /// total list with ALL objects for the game
    /// two lists one with bad objects and one with good
    /// </summary>
    public List<GameObject> trashList = new List<GameObject>();
    public List<GameObject> carrotList = new List<GameObject>();

    [System.Serializable]
    public class PlayerData
    {
        public string color;
        public int score;
        public int carrotsInScene;
        public int trashInScene;
        public int carrotsInPortals;
        public int trashInPortals;
        public bool lastPlayer;
    }
    public List<PlayerData> playerData;

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
    void Start()
    {
        playerData = new List<PlayerData>();
        for(int i = 0; i < numberOfPlayers; i++)
        {
            PlayerData newData = new PlayerData();
            playerData.Add(newData);
        }

        if (numberOfPlayers >= 2)
        {  
            playerData[0].color = "White";
            playerData[1].color = "Red";
        }
        if (numberOfPlayers >= 3)
        {
            playerData[2].color = "Yellow";
        }
        if (numberOfPlayers >= 4)
        {
            playerData[3].color = "Blue";
        }
        if (numberOfPlayers >= 5)
        {
            playerData[4].color = "Gray";
        }

        for (int i = 0; i < numberOfPlayers; i++)
        {
            playerData[i].score = 0;
            playerData[i].carrotsInScene = 0;
            playerData[i].trashInScene = 0;
            playerData[i].carrotsInPortals = 0;
            playerData[i].trashInPortals = 0;
        }
        currentPlayer = 0;
        lastPlayer = numberOfPlayers - 1;
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
        if((currentRound == 1) && (currentPlayer != lastPlayer))
        {
            currentPlayer++;
        }
        else if (currentPlayer == lastPlayer)
        {
            playerIndex = 0;
            ++currentRound;
            //Shuffle Player Order
            int n = playerOrder.Count - 1;
            while (n > 0)
            {
                int rng = Random.Range(0, n);
                n--;
                int k = rng;
                int value = playerOrder[k];
                playerOrder[k] = playerOrder[n];
                playerOrder[n] = value;
            }

            currentPlayer = playerOrder[playerIndex];
            lastPlayer = playerOrder[playerOrder.Count-1];
        }
        else
        {
            playerIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("single-multi"))
        {
            Destroy(this.gameObject);
        }
    }
}
