using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public string PlayerName;
    public string BestPlayerName;
    public int BestPlayerScore = 0;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public string BestPlayerName;
        public int BestPlayerScore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.BestPlayerName = BestPlayerName;
        data.BestPlayerScore = BestPlayerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(path != null)
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json); 

            PlayerName = data.PlayerName;
            BestPlayerName = data.BestPlayerName;
            BestPlayerScore = data.BestPlayerScore;
        }
    }

    public void SetName(string name)
    {
        PlayerName = name;
    }

    public string GetName()
    {
        return PlayerName;
    }

    public void SetBestName(string name)
    {
        BestPlayerName = name;
    }

    public string GetBestName()
    {
        return BestPlayerName;
    }

    public void SetBestScore(int score)
    {
        BestPlayerScore = score;
    }

    public int GetBestScore()
    {
        return BestPlayerScore;
    }

}
