using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
    private float score = 0.0f;

    private int DifficultyLevel = 1;
    private int MaxDifficultyLevel = 10;
    private int ScoreToNextLevel = 10;

    public Text scoreText;

    private bool IsDead = false;

    public DeathMenu death;

    void Update()
    {
        if (IsDead)
            return;

        if (score >= ScoreToNextLevel)
            LevelUp();

        score += Time.deltaTime * DifficultyLevel;
        scoreText.text = ((int)score).ToString ();
    }

    void LevelUp()
    {

        if (DifficultyLevel == MaxDifficultyLevel)
            return;

        ScoreToNextLevel *= 2;
        DifficultyLevel++;

        GetComponent<MyControl>().SetSpeed(DifficultyLevel);
    }

    public void OnDeath()
    {
        IsDead = true;

        if(PlayerPrefs.GetFloat("Highscore") < score)
            PlayerPrefs.SetFloat ("Highscore", score);

        death.ToggleEndMenu (score);
    }

}
