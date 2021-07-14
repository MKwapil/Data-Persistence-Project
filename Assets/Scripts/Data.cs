using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Data : MonoBehaviour
{

    public static Data Instance;

    public int highScore;
    public string playerName;
    public string highPlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
        public string highPlayer;
    }

        public void SaveScore()
        {
            SaveData save = new SaveData();
            save.playerName = playerName;
            save.highScore = highScore;
            save.highPlayer = highPlayer;

            string json = JsonUtility.ToJson(save);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        }

        public void LoadData()
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData save = JsonUtility.FromJson<SaveData>(json);

                playerName = save.playerName;
                highScore = save.highScore;
            }
        }
    
}
