using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
  
    private void Start() 
    {
        inputField = GameObject.Find("Name Input").GetComponent<TMP_InputField>();
        string currentPlayer = HighScoreManager.Instance.CurrentPlayerName;
        if (currentPlayer != null)
        {
            inputField.text = currentPlayer;
        }
    }

    public void StartGame()
    {
        HighScoreManager.Instance.CurrentPlayerName = inputField.text;
        Debug.Log(HighScoreManager.Instance.CurrentPlayerName);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
  #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
  #else
        Application.Quit();
  #endif
    }
}
