using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextSceneOnClick : MonoBehaviour {

    public string scene;
    public Text countdown;
    public Button Next;
	// Use this for initialization
	void Start () {
	
	}
 
    public void OnMouseDown()
    {
        InvokeRepeating("ReduceTime", 1, 1);
    }
    public void ReduceTime()
    {
        countdown.text = (int.Parse(countdown.text) - 1).ToString();
        if (countdown.text == "0")
        {
            Application.LoadLevel("LocalMultiplayer");
        }
    }
    public void Back()
    {
        Application.LoadLevel("MainMenu");
    }
    // Update is called once per frame
    void Update () {
	
	}
}
