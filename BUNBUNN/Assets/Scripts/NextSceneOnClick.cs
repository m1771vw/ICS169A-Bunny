using UnityEngine;
using System.Collections;

public class NextSceneOnClick : MonoBehaviour {

    public string scene;
	// Use this for initialization
	void Start () {
	
	}
 
    void OnMouseDown()
    {
        Application.LoadLevel(scene);
    }


	// Update is called once per frame
	void Update () {
	
	}
}
