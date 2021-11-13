using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditsUIManager : MonoBehaviour
{
    #region Texts
    /* ColorCodes      * RED : FF6300     * BLUE : 32D7FF
     * GREEN : 9BFF9F     * ORANGE : FFCD60     * PURPLE : E0AAFF */

    #region InstructionMessage
    public TextMeshProUGUI instructionText;
    private string howTo = "How To Play";
    private string instructions = "Use your <color=#E0AAFF>numpads</color> to fire bullets.\nYou can fire <color=#E0AAFF>5 bullets</color> at once.\nBullets will be reloaded when the bullets are destroyed.\ne.g. When bullets hit the enemies or reach the end of the screen.\n<color=#E0AAFF>Good Luck!</color>";
    #endregion

    #region CreditsMessage
    public TextMeshProUGUI creditsText;
    private string credits = "Credits";
    private string createdBy = "Created by ";
    private string creatorName = "kakicream";
    private string graphicAssetsBy = "For Graphics & Audio Assets Info : ";
    private string AssetsInfo = "Checkout my <color=#E0AAFF>GITHUB</color>'s README";
    #endregion

    #region ReturnMessage
    private bool canMoveOn;
    public GameObject returnMessageObject;
    public TextMeshProUGUI returnMessage;
    private string returnMessageString = "Press Any Keys to Return";
    #endregion

    #endregion

    private void Awake()
    {
        canMoveOn = false;
    }

    #region CreditsSceneStart
    private void Start()
    {
        /***** Abstraction *****/
        SetTextStart(); // Method 1
        StartCoroutine(TextOnInterval()); // IEnumerator 1
    }

    // Method 1
    void SetTextStart()
    {
        /***** Abstraction *****/
        instructionText.SetText(InstText()); // Method 1-1
        creditsText.SetText(CreditsText()); // Method 1-2
    }

    // Method 1-1
    string InstText()
    {
        string instText = $"<color=#FF6300>{howTo}</color>" + $"\n<color=#9BFF9F>{instructions}</color>";
        return instText;
    }

    // Method 1-2
    string CreditsText()
    {
        string credText = $"< color =#FF6300>{credits}</color>" + $"\n<color=#FFCD60>{createdBy}</color>" +
            $"<color=#32D7FF>{creatorName}</color>" +
            $"\n<color=#FFCD60>{graphicAssetsBy}</color>" +
            $"<color=#9BFF9F>{AssetsInfo}</color>";
        return credText;
    }

    // IEnumerator 1
    IEnumerator TextOnInterval()
    {
        yield return new WaitForSeconds(2.5f);
        returnMessage.SetText(returnMessageString);
        returnMessageObject.SetActive(true);
        canMoveOn = true;
    }
    #endregion

    #region CreditsSceneUpdate
    void Update()
    {
        /***** Abstraction *****/
        SceneChanger();
    }

    void SceneChanger()
    {
        if (Input.anyKeyDown && canMoveOn == true)
        {
            SceneManager.LoadScene(0);
        }
    }
    #endregion
}