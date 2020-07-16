using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    string gameId = "3708645";
    bool TestMode = false;

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