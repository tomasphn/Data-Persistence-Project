using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
        LoadHighScore();
    }

    public void UpdateHighScore(int newScore)
    {
      HighScore = newScore;
      HighScoreName = CurrentPlayerName;
      SaveHighScore();
    }

    class SaveData
    {
        public string HighScoreName;
        public int HighScore;
    }

    public void SaveHighScore()
    {
        // save high score
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.HighScoreName = HighScoreName;
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighScore = data.HighScore;
            HighScoreName = data.HighScoreName;
        }
    }


}
