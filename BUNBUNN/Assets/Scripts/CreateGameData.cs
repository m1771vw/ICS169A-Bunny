using UnityEngine;
using System.Collections;

public class CreateGameData : MonoBehaviour {

    public GameObject gameData;
    // Use this for initialization
    void Start()
    {
        Vector2 location;
        location.x = 0;
        location.y = 0;
        GameObject data = Instantiate(gameData, location, Quaternion.identity) as GameObject;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
