using UnityEngine;
using System.Collections;

public class TrashBehavior : MonoBehaviour {
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    public int pointWorth = 30;
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
        
        if (col.gameObject.tag == "Player1")
        {
            --localData.playerData[localData.currentPlayer].trashInScene;
            ++localData.playerData[0].trashInPortals;
            localData.playerData[localData.currentPlayer].score += pointWorth;
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "Player2")
        {
            --localData.playerData[localData.currentPlayer].trashInScene;
            ++localData.playerData[1].trashInPortals;
            localData.playerData[localData.currentPlayer].score += pointWorth;
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player3")
        {
            --localData.playerData[localData.currentPlayer].trashInScene;
            ++localData.playerData[2].trashInPortals;
            localData.playerData[localData.currentPlayer].score += pointWorth;
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player4")
        {
            --localData.playerData[localData.currentPlayer].trashInScene;
            ++localData.playerData[3].trashInPortals;
            localData.playerData[localData.currentPlayer].score += pointWorth;
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player5")
        {
            --localData.playerData[localData.currentPlayer].trashInScene;
            ++localData.playerData[4].trashInPortals;
            localData.playerData[localData.currentPlayer].score += pointWorth;
            Destroy(this.gameObject);
        }
    }

}
