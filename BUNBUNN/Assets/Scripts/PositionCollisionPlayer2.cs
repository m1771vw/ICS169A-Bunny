using UnityEngine;
using System.Collections;

public class PositionCollisionPlayer2 : MonoBehaviour
{
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    public GameObject confetti;

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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (localData.playerData[localData.getPreviousPlayer()].color == "Red")
        {
            //make sure score increased
            if (localData.playerData[localData.getPreviousPlayer()].preTurnScore < localData.playerData[localData.getPreviousPlayer()].score)
            {
                GameObject node = Instantiate(confetti, gameObject.transform.position, Quaternion.identity) as GameObject;
            }
        }
    }

}
