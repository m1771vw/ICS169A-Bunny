using UnityEngine;
using System.Collections;

public class timedRemoval : MonoBehaviour {
    float destroyTime = 2.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        Destroy(gameObject, destroyTime);
    }
}

