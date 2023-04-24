using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    public string CurrentPlayerName;
    public string HighScoreName;
    public int HighScore;

    private void Awake() 
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateHighScore(int newScore)
    {
      HighScore = newScore;
      HighScoreName = CurrentPlayerName;
    }

    public void LoadHighScore()
    {
        // load high score
    }

    public void SaveHighScore()
    {
        // save high score
    }
}
