using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour {

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void OnMouseDown()
    {
        PlayerManager playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        LocalMultiplayerGameData data = GameObject.Find("LocalMultiplayerGameData").GetComponent<LocalMultiplayerGameData>();
        int inputNum = playerManager.inputNum;

        //GameObject[] playerBalls = GameObject.FindGameObjectsWithTag("PlayerNumBall");
        //for (int i = 0; i < playerBalls.Length; i++)
        //{
        //    if (playerBalls[i].GetComponent<SpriteRenderer>().color != Color.white)
        //    {
                
        //        inputNum++;
        //        Color tempColor = new Color();
        //        tempColor = playerBalls[i].GetComponent<SpriteRenderer>().color;
        //        //data.playerData[i].realColor = tempColor;
        //        Debug.Log(data.playerData[i].realColor);
        //    }
        //}
        if (inputNum>=2)
        {
            data.updatePlayerCount(inputNum);
            SceneManager.LoadScene("PlayerTurnScreen");
        }
        
    }
}
