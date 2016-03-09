using UnityEngine;
using System.Collections;

public class PlayerNumPortals : MonoBehaviour {

    private GameObject playerManager;
    private GameObject parent;
    
    public void SetThisParent(GameObject setToThis)
    {
        parent = setToThis;
    }

    void OnMouseDown()
    {
        playerManager = GameObject.Find("PlayerManager");
        playerManager.GetComponent<PlayerManager>().subOneToPlayerCount();
        this.parent.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
