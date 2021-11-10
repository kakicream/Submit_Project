using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlaySceneUI : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    private static TextMeshProUGUI level;
    private static int levelUpScore = 100;
    private static int currLevel = 1;
    public static int speedUpper
    {
        get { return currLevel; }
        set { currLevel = value; }
    }
    private static int levelChecker;
    private static TextMeshProUGUI currScore;
    public static int currentScore;

    private static TextMeshProUGUI load;

    public GameObject gameoverText;

    void Start()
    {
        currentScore = 0;
        currLevel = 1;
        highScore.SetText($"High Score : {GameManager.Instance.highScore}");
        level = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
        level.SetText($"Level : {currLevel}");

        currScore = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        
        UpdateLoad();
    }

    void Update()
    {
        if (GameManager.isGameOver_GM == true)
        {
            gameoverText.SetActive(true);
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    public static int AddPoint(int _enemyPoints)
    {
        levelChecker += _enemyPoints;
        if (levelChecker >= levelUpScore)
        {
            currLevel++;
            level.SetText($"Level : {currLevel}");
            levelChecker = 0;
        }
        currentScore += _enemyPoints;
        currScore.SetText($"Score : {currentScore}");
        return currentScore;
    }

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
}
