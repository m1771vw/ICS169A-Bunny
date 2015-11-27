using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocalUIinGame : MonoBehaviour
{
    public Text topScore, score;
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    // Use this for initialization
    void Start()
    {
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
        topScore.text = "Top Score:" + localData.topScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        score.text = "Score: " + localData.playerData[localData.currentPlayer].score.ToString();
    }
}
