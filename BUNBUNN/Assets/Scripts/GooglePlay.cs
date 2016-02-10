﻿using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlay : MonoBehaviour
{

    public GUISkin skin;
    public int incrementalCount = 5;

    //leaderboard strings
    private string leaderboard = "CgkIitHChdsBEAIQBg ";
    //achievement strings
    private string achievement = "CgkIitHChdsBEAIQAQ ";
    private string incremental = "CgkIitHChdsBEAIQAg ";

    // Use this for initialization
    void Start()
    {
        PlayGamesPlatform.Activate();
    }

    // Update is called once per frame
    public void OnGUI()
    {
        GUI.skin = skin;
        skin.button.fixedWidth = Screen.width - 25;
        skin.textField.fixedWidth = Screen.width - 25;
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        GUILayout.BeginVertical("box");

        GUILayout.Label("Official Google Play Games Services");

        GUILayout.Space(20);

        //Share Status
        if (GUILayout.Button("Log In"))
        {
            Social.localUser.Authenticate((bool success) =>
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

        GUILayout.Space(20);

        //Achievement
        if (GUILayout.Button("Unlock Achievement"))
        {
            if (Social.localUser.authenticated)
            {
                Social.ReportProgress(achievement, 100.0f, (bool success) =>
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

        GUILayout.Space(20);

        //Incremental Achievement
        if (GUILayout.Button("Press " + incrementalCount + "more times to unlock incremental acheivment"))
        {
            if (Social.localUser.authenticated)
            {
                ((PlayGamesPlatform)Social.Active).IncrementAchievement(incremental, 5, (bool success) =>
                {
                    //The achievement unlocked successfully
                });
            }
        }

        GUILayout.Space(20);

        //Leaderboard
        if (GUILayout.Button("Post your 5000 points to the leaderboard"))
        {
            if (Social.localUser.authenticated)
            {
                Social.ReportScore(5000, "CgkIitHChdsBEAIQBg", (bool success) =>
                {
                    if (success)
                    {
                        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkIitHChdsBEAIQBg");
                    }
                    else
                    {
                        //Debug.Log("Login failed for some reason");
                    }
                });
            }
        }

        GUILayout.Space(20);

        // Show Leaderboard
        if (GUILayout.Button("Show Leaderboard"))
        {
            Social.ShowLeaderboardUI();
        }

        GUILayout.Space(20);

        //Show Specific Leaderboard
        if (GUILayout.Button("Show Specific Leaderboard"))
        {
            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard);
        }

        GUILayout.Space(20);

        //Show Achievments
        if (GUILayout.Button("Show Achievments"))
        {
            Social.ShowAchievementsUI();
        }

        GUILayout.Space(20);

        //Sign Out
        if (GUILayout.Button("Sign Out"))
        {
            ((PlayGamesPlatform)Social.Active).SignOut();
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}