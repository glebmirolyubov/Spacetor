using UnityEngine;
using UnityEngine.SocialPlatforms;

public class StoresSetup : MonoBehaviour
{
    public bool loginSuccessful;

    string leaderboardID = "56035599";

    void Start()
    {
        AuthenticateUser();
    }

    void AuthenticateUser()
    {
        Social.localUser.Authenticate((bool success) => {

            if (success)
            {
                loginSuccessful = true;
                Debug.Log("success");
            }
            else
            {
                Debug.Log("unsuccessful");
            }
            // handle success or failure
        });
    }

    public void PostScoreOnLeaderBoard(int myScore)
    {
        //#if !UNITY_EDITOR

        if(loginSuccessful)
        {
            Social.ReportScore(myScore, leaderboardID, (bool success) => {
            if(success)
            Debug.Log("Successfully uploaded");
            // handle success or failure
            });
        }
        else
        {
            Social.localUser.Authenticate((bool success) => {
            if(success)
            {
                loginSuccessful = true;
                Social.ReportScore(myScore ,leaderboardID, (bool successful) => {
                // handle success or failure
                });
            }
            else
            {
                Debug.Log("unsuccessful");
            }
            // handle success or failure
            });
        }
        //#endif
    }

    public void ShowLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }
}