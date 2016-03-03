using UnityEngine;
using System.Collections;

public class ConfettiDestroyScript : MonoBehaviour {
    public float TimeToDestroy = 2.0f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, TimeToDestroy);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
