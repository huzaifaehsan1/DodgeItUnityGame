using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float s;

    void Start()
    {
        s = Time.time;
    }

    void Update()
    {
        s = GetComponent<Timer>().t * 10;
        scoreText.text = "Score:" + s;
    }
}
