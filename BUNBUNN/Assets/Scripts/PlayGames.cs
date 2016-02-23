using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class PlayGames : MonoBehaviour
{
    #region PUBLIC_VAR
    private string leaderboard = "CgkIitHChdsBEAIQBg";
    //achievement strings
    int topscore;
    //private string achievement = "CgkIitHChdsBEAIQAQ";
    private string incremental = "CgkIitHChdsBEAIQAg";
    #endregion

    #region DEFAULT_UNITY_CALLBACKS
    void Start()
    {
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;

        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
    }
    #endregion

    #region BUTTON_CALLBACKS

    /// <summary>
    /// Login In Into Your Google+ Account
    /// </summary>
    public void LogIn()
    {
        //PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Login Sucess");
            }
            else
            {
                Debug.Log("Login failed");
            }
        });
    }
    /// <summary>
    /// Add Acheivments
    /// </summary>
    public void AddAcheivements(string acheivments)
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(acheivments, 100.0f, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("You've successfully logged in");
                }
                else
                {
                    Debug.Log("Login failed for some reason");
                }
            });
        }
    }
    /// <summary>
    /// Shows All Available Leaderborad
    /// </summary>
    public void OnShowLeaderBoard()
    {
        //Social.ShowLeaderboardUI(); // Show all leaderboard
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkIitHChdsBEAIQCA"); // Show current (Active) leaderboard
    }
    public void showAchiev()
    {
        Social.ShowAchievementsUI();
    }
    /// <summary>
    /// Adds Score To leader board
    /// </summary>
    //int scores = PlayerPrefs.GetInt("scores",200);
    public void OnAddScoreToLeaderBorad(int score)
    {
        PlayGamesPlatform.Activate();
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(score, "CgkIitHChdsBEAIQCA", (bool success) =>
            {
                if (success)
                {
                    ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkIitHChdsBEAIQCA");
                }
                else
                {
                    //Debug.Log("Login failed for some reason");
                }
            });
        }
    }

    /// <summary>
    /// On Logout of your Google+ Account
    /// </summary>
    public void OnLogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }
    #endregion
}