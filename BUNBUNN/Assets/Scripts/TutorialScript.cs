using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialScript : MonoBehaviour {
    public Button BackButton;
    public GameObject Back;
	// Use this for initialization
	void Start () {
        BackButton.enabled = false;
        Back.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] thingyToFind = GameObject.FindGameObjectsWithTag("trash");
        int thingyCount = thingyToFind.Length;
        //Debug.Log(thingyCount);
        if (thingyCount == 0)
        {
            Back.SetActive(true);
            BackButton.enabled = true;
        }
    }

    public void BackButtonPress()
    {
        Back.SetActive(true);
        Application.LoadLevel("single-multi");
    }
}
