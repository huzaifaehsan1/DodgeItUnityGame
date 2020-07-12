using UnityEngine;
using UnityEngine.Advertisements;

public class AdControl : MonoBehaviour
{

    string gameId = "3708645";
    bool TestMode = true;

    void Start()
    {
        // Initialize the Ads service:
        Advertisement.Initialize(gameId, TestMode);
    }

    public void DisplayInterstitialAD()
    {
        Advertisement.Show();
    }
}