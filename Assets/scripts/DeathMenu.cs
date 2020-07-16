using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public Text ScoreText;
    public Image BgImage;

    private bool IsShowned = false;

    private float transition = 0.0f;

    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsShowned)
            return;

        transition += Time.deltaTime;
        BgImage.color = Color.Lerp(new Color(1f, 0.7294118f, 0.03137255f, 0f), new Color(0.9882353f, 0.4627451f, 0.4156863f, 1f), transition);
    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true); 
        ScoreText.text = "Score: " + ((int)score).ToString();
        IsShowned = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
