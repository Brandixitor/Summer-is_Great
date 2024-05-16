using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public static HighScore Instance;

    private Dictionary<string, int> highScores;

    // Text object to display the high score
    [SerializeField]
    private Text highScoreLabel;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighScores();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Load high scores from PlayerPrefs
    private void LoadHighScores()
    {
        highScores = new Dictionary<string, int>();

        // Load high scores for 2x2, 4x4, 6x6, etc.
        for (int size = 2; size <= 10; size += 2)
        {
            string key = size + "x" + size + "_HighScore";
            highScores[key] = PlayerPrefs.GetInt(key, 0);
        }
    }

    // Save high scores to PlayerPrefs
    private void SaveHighScores()
    {
        foreach (var entry in highScores)
        {
            PlayerPrefs.SetInt(entry.Key, entry.Value);
        }
        PlayerPrefs.Save();
    }

    // Update the high score if the current score is better
    public void UpdateHighScore(int gameSize, int score)
    {
        string key = gameSize + "x" + gameSize + "_HighScore";
        int currentHighScore;

        if (highScores.TryGetValue(key, out currentHighScore))
        {
            if (score > currentHighScore)
            {
                highScores[key] = score;
                SaveHighScores();
                UpdateHighScoreLabel(gameSize);
            }
        }
        else
        {
            highScores[key] = score;
            SaveHighScores();
            UpdateHighScoreLabel(gameSize);
        }
    }

    // Display the high score
    public void UpdateHighScoreLabel(int gameSize)
    {
        string key = gameSize + "x" + gameSize + "_HighScore";
        int highScore = highScores[key];

        if (highScore == 0)
        {
            highScoreLabel.text = gameSize + "x" + gameSize + " High Score: N/A";
        }
        else
        {
            highScoreLabel.text = gameSize + "x" + gameSize + " High Score: " + highScore;
        }
    }

    // Method to update high score label based on current game size
    public void OnGameSizeChanged(int newGameSize)
    {
        UpdateHighScoreLabel(newGameSize);
    }
}
