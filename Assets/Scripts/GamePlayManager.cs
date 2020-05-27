using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public GameObject originalPipe;
    public float pipeSpacing = 3f;
    public float gapRange = 1f;
    public GameObject canvasGameOver;
    public Text textScore;
    public Text textBestScore;
    public int score = 0;
    public int best = 0;
    public bool newHighScore = false;
    public bool gameOver = false;
    public AudioSource audioScore;
    public AudioSource audioBest;
    public AudioSource audioOver;
    public AudioSource audioBG;

    void Start()
    {
        GenerateLevel();
        if (PlayerPrefs.HasKey("BEST"))
        {
            best = PlayerPrefs.GetInt("BEST");
        }
        
    }
    void Update()
    {
        
    }
    public void GenerateLevel()
    {
        if(score == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject pipe = Instantiate(originalPipe);
                pipe.transform.position = new Vector3(i * pipeSpacing, Random.Range(-gapRange, gapRange), 0);
            }
        }
        else
        {
            for (int i = score + 1; i < score + 11; i++)
            {
                GameObject pipe = Instantiate(originalPipe);
                pipe.transform.position = new Vector3(i * pipeSpacing, Random.Range(-gapRange, gapRange), 0);
            }
        }
        
    }

    public void GameOver()
    {
        gameOver = true;
        canvasGameOver.SetActive(true);
        textBestScore.text = PlayerPrefs.GetInt("BEST").ToString();
        audioBG.Stop();
        audioOver.Play();
    }

    public void AddScore()
    {
        if (gameOver)
            return;

        score++;
        textScore.text = score.ToString();
        audioScore.Play();

        // Add newHighScore Boolean
        if (score > best)
        {
            if (!newHighScore)
            {
                audioBest.Play();
                newHighScore = true;
            }
            PlayerPrefs.SetInt("BEST", score);
            PlayerPrefs.Save();
        }

        if((score + 1) % 10 == 0)
        {
            GenerateLevel();
        }
        
    }

    public void ResetBestScore()
    {
        PlayerPrefs.SetInt("BEST", 0);
        PlayerPrefs.Save();
    }
}
