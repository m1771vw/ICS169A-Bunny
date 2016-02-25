using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour {


    void OnMouseDown()
    {
        LocalMultiplayerGameData data = GameObject.Find("LocalMultiplayerGameData").GetComponent<LocalMultiplayerGameData>();
        int inputNum = 0;
        GameObject[] playerBalls = GameObject.FindGameObjectsWithTag("PlayerNumBall");
        for (int i = 0; i < playerBalls.Length; i++)
        {
            if (playerBalls[i].GetComponent<SpriteRenderer>().color != Color.white)
            {
                
                inputNum++;
                data.playerData[i].realColor = playerBalls[i].GetComponent<SpriteRenderer>().color;
            }
        }

        data.updatePlayerCount(inputNum);
        SceneManager.LoadScene("PlayerTurnScreen");
    }
}
