using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        currentLevel = GetLastSavedLevel();
        levels = InitializeLevels();

    }



    public List<Level> levels;



    public int currentLevel;

    private void Start()
    {
    }


    public void SetLevel(int level)
    {
        currentLevel = level;
        PlayerPrefs.SetInt("lastSavedLevel", level);
    }

    public bool FirstLaunch()
    {
        if (!PlayerPrefs.HasKey("lastSavedLevel"))
        {
            PlayerPrefs.SetInt("lastSavedLevel", 1);
            return true;
        }
        return false;
    }

    public int GetLastSavedLevel()
    {
        if (!PlayerPrefs.HasKey("lastSavedLevel"))
        {
            PlayerPrefs.SetInt("lastSavedLevel", 1);
            return 1;
        }
        else
        {
            return PlayerPrefs.GetInt("lastSavedLevel");
        }
    }

    private List<Level> InitializeLevels()
    {
        return new List<Level>()
        {
            new Level
            {
                LevelId = 1,
                EnemyCount = 10,
                InstantiateTimeFrom = 0.8f,
                InstantiateTimeTo = 1.3f
            },
            new Level
            {
                LevelId = 2,
                EnemyCount = 15,
                InstantiateTimeFrom = 0.8f,
                InstantiateTimeTo = 1.3f
            },
            new Level
            {
                LevelId = 3,
                EnemyCount = 20,
                InstantiateTimeFrom = 0.7f,
                InstantiateTimeTo = 1f
            },
            new Level
            {
                LevelId = 4,
                EnemyCount = 25,
                InstantiateTimeFrom = 0.7f,
                InstantiateTimeTo = 1f,
                // 10% chance of having life more than 1
                probabilityOfHavingLive = 10
            }
        };
    }

}
