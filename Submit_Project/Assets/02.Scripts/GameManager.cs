using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // GameManager will handle the player info
    // the high score and the current score
    // the isGameOn boolean

    private static bool isGameOver;
    public static bool isGameOver_GM
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }

    private void Awake()
    {
        isGameOver = true;
    }
}
