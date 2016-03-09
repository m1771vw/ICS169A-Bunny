using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;

public class EndGameScreen : MonoBehaviour {
    public Text topPlayer, scores;
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    public Button Menu;
    public string FirstCompleteAchievement = "CgkIitHChdsBEAIQBA";
    PlayGames Gplay = new PlayGames();
    // Use this for initialization
    void Start()
    {
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
        int top = 0;
        for (int i = 0; i < localData.numberOfPlayers - 1; i++)
        {
            if (localData.playerData[i].score > top)
            {
                top = localData.playerData[i].score;
                //topPlayer.text = "Top Player: Player " + i;
                //localData.topPlayer = i;
            }
        }
        /// need to kick to next screen do not remove
        localData.topScore = top;

        topPlayer.text = "The winner is \nPlayer " + localData.topPlayer+1;
        scores.text = localData.topScore.ToString();
        Gplay.OnAddScoreToLeaderBorad(localData.topScore);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Gplay.AddAcheivements(FirstCompleteAchievement);

	}
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
