using UnityEngine;
using System.Collections;

public class TutorialPortalBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject.Find("background camera").GetComponent<SoundManager>().PlaySound(0);
        Destroy(col.gameObject);
    }
}
