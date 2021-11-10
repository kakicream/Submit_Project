using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreSceneUI : MonoBehaviour
{
    // Load the current high score
    // Receive this time's play score
    [SerializeField] private string recordHolder;
    [SerializeField] string thisTimePlayerName;

    [SerializeField] private int highScore;
    [SerializeField] private int currScore;


    private bool canMoveOn = false;

    public TextMeshProUGUI resultMessage;
    public GameObject instructionText;

    public TextMeshProUGUI highScoreSoFar;
    public TextMeshProUGUI scoreThisTime;

    [SerializeField] private float instructionAppearTime = 2.0f;

    void Start()
    {
        recordHolder = GameManager.Instance.playerName;
        highScore = GameManager.Instance.highScore; 
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
        thisTimePlayerName = StartUIManager.currPlayerName;
        currScore = PlaySceneUI.currentScore;
        if (currScore > highScore)
        {
            recordHolder = thisTimePlayerName;
            highScore = currScore;
            SetScoreText(highScore, recordHolder, currScore, thisTimePlayerName);
            resultMessage.SetText($"Congratulations!\nNew Record {highScore} pts by {recordHolder}");
        }
        else
        {
            SetScoreText(highScore, recordHolder, currScore, thisTimePlayerName);
            if (currScore == highScore)
            {
                resultMessage.SetText($"So close! You'll do better next time!!");
            }
            else
            {
                resultMessage.SetText($"Good Luck Next Time!! Try again!");
            }
        }
        GameManager.Instance.playerName = recordHolder;
        GameManager.Instance.highScore = highScore;
        GameManager.Instance.SaveData();
    }

    private void SetScoreText(int _highScoreSoFar, string _recordHolder, int _thisTimeScore, string _thisTimePlayerName)
    {
        highScoreSoFar.SetText($"HighScore : {_highScoreSoFar} pts by {_recordHolder}");
        scoreThisTime.SetText($"Score this time : {_thisTimeScore} pts by {_thisTimePlayerName}");
    }

    IEnumerator InstructionOn()
    {
        yield return new WaitForSeconds(instructionAppearTime);
        canMoveOn = true;
        instructionText.SetActive(true);
    }
}
