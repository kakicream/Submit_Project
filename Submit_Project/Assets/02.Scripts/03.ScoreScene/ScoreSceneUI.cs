using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreSceneUI : MonoBehaviour
{
    #region RecordSoFar
    public TextMeshProUGUI highScoreSoFar;
    [SerializeField] private int highScore;
    [SerializeField] private string recordHolder;
    #endregion

    #region RecordThisTime
    public TextMeshProUGUI scoreThisTime;
    [SerializeField] string thisTimePlayerName;
    [SerializeField] private int currScore;
    #endregion

    #region ResultMessages
    public TextMeshProUGUI resultMessage;
    /* ColorCodes     * RED : FF6300    * BLUE : 32D7FF   
     * GREEN : 9BFF9F    * ORANGE : FFCD60    * PURPLE : E0AAFF */
    private string congrats = "Congratulations!";
    private string newRecord = "New Record";
    private string ptsBy = "pts by";
    private string soClose = "So close! You'll do better next time!!";
    private string tryAgain = "Good Luck Next Time!! Try Again!";
    private string highScoreText = "HighScore : ";
    private string scoreThisTimeText = "Score this time : ";
    #endregion

    #region Scene Change
    private bool canMoveOn = false;
    public GameObject instructionText;
    [SerializeField] private float instructionAppearTime = 1.0f;
    #endregion

    #region ScoreSceneStart
    void Start()
    {
        ScoreSceneUIStart(); /***** Abstraction *****/
    }

    void ScoreSceneUIStart()
    {
        /***** Abstraction *****/
        BringRecordSoFar(); // Method 1        
        SetMessage(); // Method 2
        StartCoroutine(InstructionOn()); // Method 3
    }

    #region Method 1
    void BringRecordSoFar()
    {
        recordHolder = GameManager.Instance.playerName;
        highScore = GameManager.Instance.highScore;
    }
    #endregion

    #region Method 2
    void SetMessage()
    {
        /***** Abstraction *****/
        BringRecordThisTime(); // Method 2-1
        NewRecOrNOT(); // Method 2-2
        SaveGame(); // Method 2-3
    }
    // Method 2-1
    void BringRecordThisTime()
    {
        thisTimePlayerName = StartUIManager.currPlayerName;
        currScore = PlaySceneUI.currentScore;
    }

    void NewRecOrNOT()
    {
        if (currScore > highScore)
        {
            recordHolder = thisTimePlayerName;
            highScore = currScore;

            SetScoreText(highScore, recordHolder, currScore, thisTimePlayerName);
            setResultMessage(congrats, newRecord, highScore, ptsBy, recordHolder);
        }
        else
        {
            SetScoreText(highScore, recordHolder, currScore, thisTimePlayerName);
            if (currScore == highScore)
            {
                setResultMessage(soClose);
            }

            else
            {
                setResultMessage(tryAgain);
            }
        }
    }

    private void SetScoreText(int _highScoreSoFar, string _recordHolder, int _thisTimeScore, string _thisTimePlayerName)
    {
        highScoreSoFar.SetText
            ($"<color=#FF6300>{highScoreText}</color>" +
            $"<color=#FFCD60>{_highScoreSoFar}</color>" +
            $" <color=#FF6300> {ptsBy}</color> " +
            $" <color=#E0AAFF>{_recordHolder}</color>");
        scoreThisTime.SetText
            ($"<color=#32D7FF>{scoreThisTimeText}</color>" +
            $"<color=#FFCD60>{_thisTimeScore}</color> " +
            $" <color=#32D7FF>{ptsBy}</color> " +
            $" <color=#E0AAFF>{_thisTimePlayerName}</color>");
    }

    void setResultMessage(string _congrats, string _newRec, int _highScore, string _ptsBy, string _recordHolder)
    {
        resultMessage.SetText
                ($"<color=#9BFF9F>{_congrats}</color>" +
                $"\n<color=#FF6300>{_newRec}</color>" +
                $" <color=#FFCD60>{_highScore}</color>" +
                $" <color=#9BFF9F>{_ptsBy}</color>" +
                $" <color=#32D7FF>{_recordHolder}</color>");
    }

    void setResultMessage(string text)
    {
        resultMessage.SetText
                    ($"<color=#9BFF9F>{text}</color>");
    }

    // Method 2-3
    void SaveGame()
    {
        GameManager.Instance.playerName = recordHolder;
        GameManager.Instance.highScore = highScore;
        GameManager.Instance.SaveData();
    }
    #endregion


    #region Method 3
    IEnumerator InstructionOn()
    {
        yield return new WaitForSeconds(instructionAppearTime);
        canMoveOn = true;
        instructionText.SetActive(true);
    }
    #endregion

    #endregion

    #region ScoreSceneUpdate
    void Update()
    {
        /***** Abstraction *****/
        SceneChanger(0);
    }

    void SceneChanger(int sceneNo)
    {
        if (canMoveOn == true && Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneNo);
        }
    }
    #endregion
}