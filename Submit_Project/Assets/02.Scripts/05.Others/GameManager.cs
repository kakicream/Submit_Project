using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    #region GameOverCheck Bool
    private static bool isGameOver;
    public static bool isGameOver_GM
    {
        /***** Encapsulation *****/
        get { return isGameOver; }
        set { isGameOver = value; }
    }
    #endregion

    #region Data to save
    public static GameManager Instance;
    public string playerName;
    public int highScore;
    #endregion

    #region GameManager Awake
    private void Awake()
    {
        isGameOver = true;
        CheckNull(); /***** Abstraction *****/
        Instance = this;
        DontDestroyOnLoad(Instance);
        LoadData(); /***** Abstraction *****/
        if (playerName == null)
        {
            playerName = "AAA";
        }
    }

    void CheckNull()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion

    #region Save & Load Data
    [System.Serializable]
    class SavePlayerData
    {
        public string SD_playerName;
        public int SD_highScore;
    }

    public void SaveData()
    {
        SavePlayerData data = new SavePlayerData();
        data.SD_playerName = playerName;
        data.SD_highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedatafile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savedatafile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavePlayerData data = JsonUtility.FromJson<SavePlayerData>(json);
            playerName = data.SD_playerName;
            highScore = data.SD_highScore;
        }
    }
    #endregion
}