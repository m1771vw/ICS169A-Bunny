using UnityEngine;
using System.Collections;

public class CarrotBehavior : MonoBehaviour
{
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    // Use this for initialization
    void Start()
    {
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        localData.playerData[localData.currentPlayer].score += localData.carrotScoreWorth;
        Destroy(this.gameObject);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        /*
        if (col.gameObject.tag == "Player1")
        {
            --localData.playerData[localData.currentPlayer].carrotsInScene;
            ++localData.playerData[0].carrotsInPortals;
            //localData.playerData[localData.currentPlayer].score -= localData.carrotScoreWorth;
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player2")
        {
            --localData.playerData[localData.currentPlayer].carrotsInScene;
            ++localData.playerData[1].carrotsInPortals;
            //localData.playerData[localData.currentPlayer].score -= localData.carrotScoreWorth;
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player3")
        {
            --localData.playerData[localData.currentPlayer].carrotsInScene;
            ++localData.playerData[2].carrotsInPortals;
            localData.playerData[localData.currentPlayer].score -= localData.carrotScoreWorth;
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player4")
        {
            --localData.playerData[localData.currentPlayer].carrotsInScene;
            ++localData.playerData[3].carrotsInPortals;
            //localData.playerData[localData.currentPlayer].score -= localData.carrotScoreWorth;
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player5")
        {
            --localData.playerData[localData.currentPlayer].carrotsInScene;
            ++localData.playerData[4].carrotsInPortals;
            //localData.playerData[localData.currentPlayer].score -= localData.carrotScoreWorth;
            Destroy(this.gameObject);
        }
        */
    }
}
