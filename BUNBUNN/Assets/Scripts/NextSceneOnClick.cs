using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextSceneOnClick : MonoBehaviour {

    public string scene;
    public Text countdown;
    public Button Next;
    public string firstimeAchievment = "CgkIitHChdsBEAIQAw";
    private bool countingDown = false;
    private float timer;
    PlayGames Gplay = new PlayGames();
    // Use this for initialization
    void Start () {
        timer = (float.Parse(countdown.text));
	}
 
    public void OnMouseDown()
    {
        countingDown = true;
       // InvokeRepeating("ReduceTime", 1, 1);
    }
    //public void ReduceTime()
    //{
    //    countdown.text = (int.Parse(countdown.text) - 1).ToString();
    //    if (countdown.text == "0")
    //    {
    //        SceneManager.LoadScene("LocalMultiplayer");
    //    }
    //}
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update ()
    {
        Gplay.AddAcheivements(firstimeAchievment);
        if (countingDown)
        {
            reduceTime();
        }
        float newTime = Mathf.Floor(timer * 100.0f + 0.5f) / 100;
        countdown.text = ((int)newTime).ToString();
        if (timer <=0.0f)
        {
            SceneManager.LoadScene("LocalMultiplayer");
        }
    }
    void reduceTime()
    {
        timer -= Time.deltaTime;

    }
}
