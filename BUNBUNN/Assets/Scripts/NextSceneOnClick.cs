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

    void Update()
    {
        GameObject[] thingyToFind = GameObject.FindGameObjectsWithTag("trash");
        int thingyCount = thingyToFind.Length;
        Debug.Log(thingyCount);
        if (thingyCount == 0)
        {
            Application.LoadLevel(scene);
            //Back.SetActive(true);
            //BackButton.enabled = true;
        }
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
            Application.LoadLevel(scene);
        }
    }
    public void Back()
    {
        Application.LoadLevel("single-multi");
    }
    // Update is called once per frame
}
