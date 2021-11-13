using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlaySceneUI : MonoBehaviour
{
    #region Levels
    private static TextMeshProUGUI level;
    private static int levelUpScore = 100;
    private static int currLevel = 1;
    private static int levelChecker;
    public static int speedUpper
    {
        /***** Encapsulation *****/
        get { return currLevel; }
        set { currLevel = value; }
    }
    #endregion

    #region Scores
    public TextMeshProUGUI highScore;
    private static TextMeshProUGUI currScore;
    public static int currentScore;
    #endregion

    #region LoadBullets
    private static TextMeshProUGUI load;
    #endregion

    #region GameOverText
    public GameObject gameoverText;
    #endregion

    #region PlayScene Start
    void Start()
    {
        PlayUIStart();
    }

    void PlayUIStart()
    {
        /***** Abstraction *****/
        InitialSet(); // Method 1
        UpdateLoad(); // Method 2
    }

    // Method 1
    void InitialSet()
    {
        currentScore = 0;
        currLevel = 1;
        highScore.SetText($"High Score : {GameManager.Instance.highScore}");
        level = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
        level.SetText($"Level : {currLevel}");

        currScore = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    // Method 2
    public static void UpdateLoad()
    {
        if (GameManager.isGameOver_GM == false)
        {
            if (load == null)
            {
                load = GameObject.Find("BulletsLoad").GetComponent<TextMeshProUGUI>();
            }
            int bulletNo = CannonController.canYouFire;
            load.SetText($"Load : {bulletNo}");
        }
    }
    #endregion

    #region PlayScene Update
    void Update()
    {
        /***** Abstraction *****/
        GameOverChecker(); // Method 1
    }

    // Method 1
    void GameOverChecker()
    {
        if (GameManager.isGameOver_GM == true)
        {
            gameoverText.SetActive(true);
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(2);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    #endregion

    #region Scoring
    public static int AddPoint(int _enemyPoints)
    {
        levelChecker += _enemyPoints;
        /***** Abstraction *****/
        LevelUpCheck(); // Method 2

        currentScore += _enemyPoints;
        currScore.SetText($"Score : {currentScore}");
        return currentScore;
    }

    // Method 2
    static void LevelUpCheck()
    {
        if (levelChecker >= levelUpScore)
        {
            currLevel++;
            level.SetText($"Level : {currLevel}");
            levelChecker = 0;
        }
    }
    #endregion
}