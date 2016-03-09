using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextSceneOnClick : MonoBehaviour {

    public string scene;
    public Text countdown;
    public Button Next;
    public string firstimeAchievment = "CgkIitHChdsBEAIQAw";
    PlayGames Gplay = new PlayGames();
    // Use this for initialization
    void Start () {
	
	}
 
    public void OnMouseDown()
    {
        SceneManager.LoadScene("LocalMultiplayer");
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
