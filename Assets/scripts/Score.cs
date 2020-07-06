using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private float startScore;

    void Start()
    {
        startScore = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float q = Time.time *10;


        string seconds = (q).ToString("f0");
        

        scoreText.text = "Score:" + seconds;
    }
}
