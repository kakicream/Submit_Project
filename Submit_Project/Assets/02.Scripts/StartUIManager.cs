using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.isGameOver_GM = false;
        SceneManager.LoadScene(1);
    }

    public void CreditsInstructions()
    {
        SceneManager.LoadScene(3);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
