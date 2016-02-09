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
    public GameObject carrot;
    public GameObject trash;
    public List<GameObject> trashList = new List<GameObject>();
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
    public int startingCarrots;
    public int startingTrash;

    [System.Serializable]
    public class PlayerData
    {
        public string color;
        public int score;
        public bool lastPlayer;
        public List<GameObject> currentSceneObjects = new List<GameObject>();
        public List<GameObject> player1PortalContents = new List<GameObject>();
        public List<GameObject> player2PortalContents = new List<GameObject>();
        public List<GameObject> player3PortalContents = new List<GameObject>();
        public List<GameObject> player4PortalContents = new List<GameObject>();
        public List<GameObject> player5PortalContents = new List<GameObject>();
    }
    public List<PlayerData> playerData;

    /// Initialization
    /// Sets the game up for the first round of the game
    void Start()
    {
        for (int i = 0; i < startingCarrots; i++)
        {
            playerData[0].player2PortalContents.Add(carrot);
            playerData[0].player3PortalContents.Add(carrot);
            playerData[0].player4PortalContents.Add(carrot);
            playerData[0].player5PortalContents.Add(carrot);

            playerData[1].player1PortalContents.Add(carrot);
            playerData[1].player3PortalContents.Add(carrot);
            playerData[1].player4PortalContents.Add(carrot);
            playerData[1].player5PortalContents.Add(carrot);

            playerData[2].player2PortalContents.Add(carrot);
            playerData[2].player1PortalContents.Add(carrot);
            playerData[2].player4PortalContents.Add(carrot);
            playerData[2].player5PortalContents.Add(carrot);

            playerData[3].player2PortalContents.Add(carrot);
            playerData[3].player3PortalContents.Add(carrot);
            playerData[3].player4PortalContents.Add(carrot);
            playerData[3].player5PortalContents.Add(carrot);

            playerData[4].player2PortalContents.Add(carrot);
            playerData[4].player3PortalContents.Add(carrot);
            playerData[4].player1PortalContents.Add(carrot);
            playerData[4].player5PortalContents.Add(carrot);

            playerData[5].player2PortalContents.Add(carrot);
            playerData[5].player3PortalContents.Add(carrot);
            playerData[5].player4PortalContents.Add(carrot);
            playerData[5].player1PortalContents.Add(carrot);
        }

        for (int i = 0; i < startingTrash; i++)
        {
            int random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[0].player2PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[0].player3PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[0].player4PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[0].player5PortalContents.Add(trash);

            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[1].player1PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[1].player3PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[1].player4PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[1].player5PortalContents.Add(trash);

            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[2].player2PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[2].player1PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[2].player4PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[2].player5PortalContents.Add(trash);

            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[3].player2PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[3].player3PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[3].player4PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[3].player5PortalContents.Add(trash);

            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[4].player2PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[4].player3PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[4].player1PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[4].player5PortalContents.Add(trash);

            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[5].player2PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[5].player3PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[5].player4PortalContents.Add(trash);
            random = Random.Range(0, trashList.Count);
            trash = trashList[random];
            playerData[5].player1PortalContents.Add(trash);
        }

        

        playerData = new List<PlayerData>();
        for (int i = 0; i < numberOfPlayers; i++)
        {
            PlayerData newData = new PlayerData();
            playerData.Add(newData);

            if (numberOfPlayers >= 2)
            {
                ShuffleArray(playerData[i].player1PortalContents);
                ShuffleArray(playerData[i].player2PortalContents);
            }
            if (numberOfPlayers >= 3)
            {
                ShuffleArray(playerData[i].player3PortalContents);
            }
            if (numberOfPlayers >= 4)
            {
                ShuffleArray(playerData[i].player4PortalContents);
            }
            if (numberOfPlayers >= 5)
            { 
                ShuffleArray(playerData[i].player5PortalContents);
            }
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
            Debug.Log("round ++");
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

    public static void ShuffleArray(List<GameObject> arr)
    {
        int random = Random.Range(0, arr.Capacity);
        int n = arr.Capacity;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n - 1);
            GameObject value = arr[k];
            arr[k] = arr[n];
            arr[n] = value;
        }
    }
}
