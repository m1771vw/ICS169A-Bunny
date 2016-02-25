using UnityEngine;
using System.Collections;

public class CreatePawOnTouch : MonoBehaviour {
    public GameObject paw;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount == 1)
        {
            Vector3 touchPos = Input.GetTouch(0).position;
            Vector3 createPos = Camera.main.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, 10));

            Instantiate(paw, createPos, Quaternion.identity);
        }
    }
}
