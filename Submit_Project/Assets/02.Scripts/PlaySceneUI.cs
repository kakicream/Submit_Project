using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlaySceneUI : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI level;
    public TextMeshProUGUI currScore;

    public GameObject gameoverText;
    
    void Start()
    {
        // Set the highscore, level

        // set currscore as zero, 
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

    public void PointAdd()
    {
        // Add points each time enemy is destroyed
    }
}
