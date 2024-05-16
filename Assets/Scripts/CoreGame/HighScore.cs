using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public static HighScore Instance;

    private Dictionary<string, int> highScores;
    private int currentGameSize;
    private string highScoreKey;

    [SerializeField]
    private Text highScoreLabel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeHighScores();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeHighScores()
    {
        highScores = new Dictionary<string, int>();
        for (int i = 2; i <= 16; i++)
        {
            string key = $"{i}x{i}_HighScore";
            highScores[key] = PlayerPrefs.GetInt(key, 0);
        }
    }

    public void UpdateHighScore(int gameSize, int score)
    {
        string key = $"{gameSize}x{gameSize}_HighScore";
        if (!highScores.ContainsKey(key) || score > highScores[key])
        {
            highScores[key] = score;
            PlayerPrefs.SetInt(key, score);
            PlayerPrefs.Save();
        }
        UpdateHighScoreLabel();
    }

    public void OnGameSizeChanged(int gameSize)
    {
        currentGameSize = gameSize;
        highScoreKey = $"{gameSize}x{gameSize}_HighScore";
        UpdateHighScoreLabel();
    }

    private void UpdateHighScoreLabel()
    {
        if (highScores.ContainsKey(highScoreKey))
        {
            highScoreLabel.text = "High Score: " + highScores[highScoreKey];
        }
        else
        {
            highScoreLabel.text = "High Score: N/A";
        }
    }
}
