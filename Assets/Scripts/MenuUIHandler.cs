using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;




// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_Text HighscoreText;
    public void Start()
    {
        DataManager.Instance.LoadData();
        nameInputField.text = DataManager.Instance.Name;
        HighscoreText.text = "Highscore: " + DataManager.Instance.Name + " : " + DataManager.Instance.highscore;
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SaveNameTyped(string value)
    {
        Debug.Log("Name entered: " + value);
        DataManager.Instance.Name = value;
    }
}
