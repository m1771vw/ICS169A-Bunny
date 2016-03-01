using UnityEngine;
using System.Collections;

public class TurnScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "LeftSpawn")
        {
            Debug.Log("Collide");
            Destroy(col.gameObject);
        }
    }
}
