using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static string playerName = "NoName";
    public static int playerScore = 0;

    public static string bestPlayerNameSave = "NoBestPlayerYet";
    public static int bestPlayerScoreSave = 0;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameSession();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerNameSave;
        public int bestPlayerScoreSave;
    }

    public void SaveGameSession()
    {
        SaveData data = new SaveData();
        data.bestPlayerNameSave = playerName;
        data.bestPlayerScoreSave = MainManager.m_Points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameSession()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerNameSave = data.bestPlayerNameSave;
            bestPlayerScoreSave = data.bestPlayerScoreSave;
        }
    }

    public void UpdateBestScore()
    {
        bestPlayerNameSave = playerName;
        bestPlayerScoreSave = playerScore;
    }
}
