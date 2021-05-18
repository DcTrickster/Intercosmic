using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int points;
    public Text scoreText1stPerson, scoreText3rdPerson, finalScoreText;
    private int score, finalScore;
    public GameObject finalScreen,cam, pauseCanvas;
    public bool gameOver,paused = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            cam.SetActive(true);
            finalScreen.SetActive(true);
            finalScoreText.text = "Final Score: " + finalScore;
        }
        finalScore = score;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText1stPerson.text = "Score: " + score;
        scoreText3rdPerson.text = "Score: " + score;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
