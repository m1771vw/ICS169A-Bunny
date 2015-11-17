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
        Debug.Log("entered");
        if (col.gameObject.tag == "Player1")
        {
            ++localData.portalOneTrash;
            Destroy(this.gameObject);
            
        }
        else if(col.gameObject.tag == "Player2")
        {
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player3")
        {
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player4")
        {
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player5")
        {
            Destroy(this.gameObject);
        }
    }

}
