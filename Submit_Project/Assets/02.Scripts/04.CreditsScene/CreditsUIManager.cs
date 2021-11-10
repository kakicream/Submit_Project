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

    private void Awake()
    {
        canMoveOn = false;
    }

    private void Start()
    {
        instructionText.SetText("Use your numpads to fire bullets.\nYou can fire 5 bullets at once.\nBullets will be reloaded when the bullets are destroyed.\ne.g. When bullets hit the enemies or reach the end of the screen.\nGood Luck!");
        creditsText.SetText("Credits\nCreator : kakicream\nGraphic Resources : ???\nSound Resources : ???");

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
        yield return new WaitForSeconds(3.0f);
        returnMessage.SetText("Press Any Keys to return");
        returnMessageObject.SetActive(true);
        canMoveOn = true;
    }
}
