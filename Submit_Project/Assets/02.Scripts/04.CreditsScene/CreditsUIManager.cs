using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditsUIManager : MonoBehaviour
{
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI creditsText;
    public GameObject returnMessageObject;
    public TextMeshProUGUI returnMessage;

    private bool canMoveOn;
    #region Texts
    #region InstructionMessage
    private string howTo = "How To Play";
    private string instructions = "Use your numpads to fire bullets.\nYou can fire 5 bullets at once.\nBullets will be reloaded when the bullets are destroyed.\ne.g. When bullets hit the enemies or reach the end of the screen.\nGood Luck!";
    #endregion
    #region CreditsMessage
    private string credits = "Credits";
    private string createdBy = "Created by ";
    private string creatorName = "kakicream";
    private string graphicAssetsBy = "Graphic Assets by";
    private string graphicAssetCreator1 = "David Stenfors' ";
    private string graphicAssetName1 = "Low Poly SpaceRocks";
    private string graphicAssetCreator2 = "Prodigious Creations' ";
    private string graphicAssetName2 = "Vast Outer Space";
    private string particleAssetCreator1 = "Sherbb's";
    private string particleAssetName1 = "Sherbb's Particle Collection";
    private string soundAssetsBy = "Sound Assets by";
    private string soundAssetCreator1 = "???'s ";
    private string soundAssetName1 = "@@@";
    #endregion
    #region ReturnMessage
    private string returnMessageString = "Press Any Keys to Return";
    #endregion
    #endregion
    private void Awake()
    {
        canMoveOn = false;
    }


    private void Start()
    {
        instructionText.SetText
            ($"<color=#FF6300><size=40>{howTo}</size></color>" +
            $"\n{instructions}");
        creditsText.SetText
            ($"<color=#FF6300><size=40>{credits}</size></color>" +
            $"\n{createdBy} <color=#9BFF9F>{creatorName}</color>" +
            $"\n{graphicAssetsBy}" +
            $"\n<color=#E0AAFF>{graphicAssetCreator1}</color> " +
            $"<color=#FFCD60>{graphicAssetName1}</color>" +
            $"\n<color=#E0AAFF>{graphicAssetCreator2}</color>" +
            $" <color=#FFCD60>{graphicAssetName2}</color>" +
            $"\n{soundAssetsBy}" +
            $"\n<color=#E0AAFF>{particleAssetCreator1}</color>" +
            $" <color=#FFCD60>{particleAssetName1}</color>" +
            $"\n<color=#E0AAFF>{soundAssetCreator1}</color> " +
            $"<color=#FFCD60>{soundAssetName1}</color>");

        StartCoroutine(TextOnInterval());
    }

    void Update()
    {
        if (Input.anyKeyDown && canMoveOn == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator TextOnInterval()
    {
        yield return new WaitForSeconds(2.5f);
        returnMessage.SetText(returnMessageString);
        returnMessageObject.SetActive(true);
        canMoveOn = true;
    }
}
