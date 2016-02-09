using UnityEngine;
using System.Collections;

public class TrashBehavior : MonoBehaviour {
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    // Use this for initialization
    void Start () {
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Player1" && localData.playerData[localData.currentPlayer].color == "red")
        {
            localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
            localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "Player2")
        {
            localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
            localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player3")
        {
            localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
            localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player4")
        {
            localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
            localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player5")
        {
            localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
            localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
            Destroy(this.gameObject);
        }
    }

}
