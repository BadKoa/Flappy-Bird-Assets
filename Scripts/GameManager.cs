using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public Player player;

    public Text scoreText;

    public GameObject playButton;

    public GameObject gameOver;

    public Text highestScore;

    public Text hScoreAnnouncer;

    bool ScoreAnnouncerExecuted = false;

    private int score;

    private void Awake()
    {
        //PlayerPrefs.SetInt("HighestScore", 0);// silmeyi unutma
        Application.targetFrameRate = 60;
        Pause();

        hScoreAnnouncer.enabled = false;
    }

    private void Update()
    {
        ScoreAnnouncer();
    }


    public void ScoreAnnouncer()
    {
        if(ScoreAnnouncerExecuted == false) 
        {
            int highestScoreValue = PlayerPrefs.GetInt("HighestScore", 0);

            if (score > highestScoreValue)
            {
                PlayerPrefs.SetInt("HighestScore", score);
                PlayerPrefs.Save();

                hScoreAnnouncer.enabled = true;

                StartCoroutine(DelayCoroutine());

                ScoreAnnouncerExecuted = true;
            }
        }
        
    }
    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(1f);

        hScoreAnnouncer.enabled= false;

    }

    private void Start()
    {
        // Load the highest score from PlayerPrefs
        int highestScoreValue = PlayerPrefs.GetInt("HighestScore", 0);

        highestScore.text = "High Score: " + highestScoreValue;
        
    }

    public void GameOver()
    {
        // Update the highest score if the current score is higher
        int highestScoreValue = PlayerPrefs.GetInt("HighestScore", 0);
        
        if (score > highestScoreValue)
        {
            PlayerPrefs.SetInt("HighestScore", score);
            PlayerPrefs.Save();
            highestScore.text = "Highest Score: " + score; 
        }

        gameOver.SetActive(true);
        playButton.SetActive(true);
        highestScore.enabled = true;

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        ScoreAnnouncer();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        highestScore.enabled = false;

        hScoreAnnouncer.enabled = false;

        ScoreAnnouncerExecuted = false;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }



}