using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextSceneOnClick : MonoBehaviour {

    public string scene;
    public Text countdown;
    public string firstimeAchievment = "CgkIitHChdsBEAIQAw";
    private bool countingDown = false;
    private float timer;
    bool clicked = false;
    PlayGames Gplay = new PlayGames();
    // Use this for initialization
    void Start () {
        timer = (float.Parse(countdown.text));
	}
 
    public void OnMouseDown()
    {
        if(clicked == true)
        {
            SceneManager.LoadScene("LocalMultiplayer");
        }
        else if(clicked == false)
        { 
            GameObject.Find("ClickToPlay").GetComponent<Image>().sprite =
                GameObject.Find("newImage").GetComponent<Image>().sprite;
            GameObject.Find("Camera").GetComponent<RacePosition>().setCurrentPlayerUprightAndPreviousDown();
        }
        clicked = true;   
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update ()
    {
        Gplay.AddAcheivements(firstimeAchievment);
    }

}
