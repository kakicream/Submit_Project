using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreSceneUI : MonoBehaviour
{
    // Load the current high score
    // Receive this time's play score

    [SerializeField] private int highScore;
    [SerializeField] private int currScore;

    private bool canMoveOn = false;

    public TextMeshProUGUI resultMessage;
    public GameObject instructionText;

    void Start()
    {
        SetMessage();
        StartCoroutine(InstructionOn());
    }

    void Update()
    {   
        if (canMoveOn == true && Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
    }

    void SetMessage()
    {
        if (currScore > highScore)
        {
            resultMessage.SetText("Congratulations!\nNew Record {highScore}pts by {playerName}");
        }
        else if (currScore == highScore)
        {
            resultMessage.SetText("So close! Just one more point!");
        }
        else
        {
            resultMessage.SetText("Try Again! You'll do better next time!");
        }
    }

    IEnumerator InstructionOn()
    {
        yield return new WaitForSeconds(3.0f);
        canMoveOn = true;
        instructionText.SetActive(true);
    }
}
