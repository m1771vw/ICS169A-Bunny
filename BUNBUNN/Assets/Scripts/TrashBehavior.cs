using UnityEngine;
using System.Collections;

public class TrashBehavior : MonoBehaviour {
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    // Use this for initialization
    void Start () {
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
        localData.playerData[localData.currentPlayer].score -= localData.trashScoreWorth;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (localData.playerData[localData.currentPlayer].color == "White")
        {
            if (col.gameObject.tag == "Player1")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[0].player1PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player2")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[1].player1PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player3")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[2].player1PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player4")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[3].player1PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player5")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[4].player1PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
        }
        if (localData.playerData[localData.currentPlayer].color == "Red")
        {
            if (col.gameObject.tag == "Player1")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[0].player2PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player2")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[1].player2PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player3")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[2].player2PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player4")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[3].player2PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player5")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[4].player2PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
        }
        if (localData.playerData[localData.currentPlayer].color == "Yellow")
        {
            if (col.gameObject.tag == "Player1")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[0].player3PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player2")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[1].player3PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player3")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[2].player3PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player4")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[3].player3PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player5")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[4].player3PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
        }
        if (localData.playerData[localData.currentPlayer].color == "Blue")
        {
            if (col.gameObject.tag == "Player1")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[0].player4PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player2")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[1].player4PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player3")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[2].player5PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player4")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[3].player5PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player5")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[4].player5PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
        }
        if (localData.playerData[localData.currentPlayer].color == "Gray")
        {
            if (col.gameObject.tag == "Player1")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[0].player5PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player2")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[1].player5PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player3")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[2].player5PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player4")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[3].player5PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
            else if (col.gameObject.tag == "Player5")
            {
                localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);
                localData.playerData[localData.currentPlayer].score += localData.trashScoreWorth;
                localData.playerData[4].player5PortalContents.Add(gameObject);
                this.gameObject.SetActive(false);
            }
        }
    }

}
