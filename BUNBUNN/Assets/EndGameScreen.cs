using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EndGameScreen : MonoBehaviour {
    public Text topPlayer, scores;
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    public Button Menu;
    // Use this for initialization
    void Start()
    {
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
        topPlayer.text = "The winner is \nPlayer " + localData.topPlayer;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GoToMenu()
    {
        Application.LoadLevel("single-multi");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
