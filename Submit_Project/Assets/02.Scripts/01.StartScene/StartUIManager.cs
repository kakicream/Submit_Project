using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    #region START BUTTON
    public TMP_InputField playerNameInput;
    public static string currPlayerName;

    public void StartGame()
    {
        currPlayerName = playerNameInput.text;
        SetGameOver(false); /***** Abstraction *****/
        SceneManager.LoadScene(1);
    }

    void SetGameOver(bool _boolValue)
    {
        GameManager.isGameOver_GM = _boolValue;
    }
    #endregion

    #region HOW TO PLAY BUTTON
    public void CreditsInstructions()
    {
        SceneManager.LoadScene(3);
    }
    #endregion

    #region EXIT BUTTON
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    #endregion
}