using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class StoresSetup : MonoBehaviour
{
    public bool loginSuccessful;

    #if UNITY_IOS
    string leaderboardIDApple = "SpacetorLeaderboard";
    #elif UNITY_ANDROID
    string leaderboardIDGoogle = "CgkIpsDJjIISEAIQAg";
    #endif


    void Start()
    {
        #if UNITY_IOS
        AuthenticateUser();
        #elif UNITY_ANDROID
        PlayGamesPlatform.Activate();
        AuthenticateUser();
        #endif
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
        #if UNITY_IOS
        if(loginSuccessful)
        {
            Social.ReportScore(myScore, leaderboardIDApple, (bool success) => {
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
                Social.ReportScore(myScore, leaderboardIDApple, (bool successful) => {
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
        #elif UNITY_ANDROID
        if (loginSuccessful)
        {
            Social.ReportScore(myScore, leaderboardIDGoogle, (bool success) => {
                if (success)
                    Debug.Log("Successfully uploaded");
                // handle success or failure
            });
        }
        else
        {
            Social.localUser.Authenticate((bool success) => {
                if (success)
                {
                    loginSuccessful = true;
                    Social.ReportScore(myScore, leaderboardIDGoogle, (bool successful) => {
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
        #endif
    }

    public void ShowLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }
}