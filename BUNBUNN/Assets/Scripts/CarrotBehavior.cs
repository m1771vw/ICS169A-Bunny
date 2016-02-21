using UnityEngine;
using System.Collections;

public class CarrotBehavior : MonoBehaviour
{
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    public GameObject pointsGainedObject;
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
        Instantiate(pointsGainedObject, transform.position, Quaternion.identity);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (localData != null)
        {
            if (localData.currentPlayerColor == "White")
            {
                if (col.gameObject.tag == "Player1")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[0].player1PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player2")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[1].player1PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player3")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[2].player1PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player4")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[3].player1PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player5")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[4].player1PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
            }
            if (localData.currentPlayerColor == "Red")
            {
                if (col.gameObject.tag == "Player1")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[0].player2PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player2")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[1].player2PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player3")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[2].player2PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player4")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[3].player2PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player5")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[4].player2PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
            }
            if (localData.currentPlayerColor == "Yellow")
            {
                if (col.gameObject.tag == "Player1")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[0].player3PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player2")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[1].player3PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player3")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[2].player3PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player4")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[3].player3PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player5")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[4].player3PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
            }
            if (localData.currentPlayerColor == "Blue")
            {
                if (col.gameObject.tag == "Player1")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[0].player4PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player2")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[1].player4PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player3")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[2].player4PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player4")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[3].player4PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player5")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[4].player4PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
            }
            if (localData.currentPlayerColor == "Gray")
            {
                if (col.gameObject.tag == "Player1")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[0].player5PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player2")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[1].player5PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player3")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[2].player5PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player4")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[3].player5PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
                else if (col.gameObject.tag == "Player5")
                {
                    localData.playerData[localData.currentPlayer].currentSceneObjects.RemoveAt(0);

                    localData.playerData[4].player5PortalContents.Add(localData.carrot);
                    Destroy(this.gameObject);
                }
            }
        }

    }
}
