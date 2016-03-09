using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using System.Collections;
using UnityEngine.SceneManagement;
public class single_multi : MonoBehaviour
{
    public Canvas quitMenu;
    public string LoggingInAcheivment = "CgkIitHChdsBEAIQAQ";
    public Button PlaySingle;
    public Button exitText;
    public Button PlayMulti;
    public GameObject SinglePlayer;
    public GameObject Multi;
    public GameObject Quit;
    PlayGames Gplay = new PlayGames();

    void Start()
    {
        PlayGamesPlatform.Activate();
        //Gplay.AddAcheivements(LoggingInAcheivment);
        quitMenu = quitMenu.GetComponent<Canvas>();
        exitText = exitText.GetComponent<Button>();
        PlaySingle = PlaySingle.GetComponent<Button>();
        //PlayMulti = PlayMulti.GetComponent<Button>();
        quitMenu.enabled = false;

    }

    void logIn()
    {
        Gplay.LogIn();
    }
    void Update()
    {
        Gplay.AddAcheivements(LoggingInAcheivment);
    }
    public void exitPress()
    {
        quitMenu.enabled = true;
        exitText.enabled = true;
        PlaySingle.enabled = false;
        //PlayMulti.enabled = false;
        SinglePlayer.SetActive(false);
        //Multi.SetActive(false);
        Quit.SetActive(false);
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        exitText.enabled = true;
        PlaySingle.enabled = true;
        PlayMulti.enabled = true;
        SinglePlayer.SetActive(true);
        Multi.SetActive(true);
        Quit.SetActive(true);
    }
    public void TutorialPress()
    {
        SceneManager.LoadScene("TutorialRemade");
    }
    public void SinglePress()
    {
        SceneManager.LoadScene("PlayerNamingAndNumber");
    }
    public void MultiPress()
    {
       // Application.LoadLevel("Calibration");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
