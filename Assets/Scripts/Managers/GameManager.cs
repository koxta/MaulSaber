using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }


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
    }
    #endregion

    #region UI Screens
    [Header("UI Screens")]
    public GameScreen GameScreen;
    public UiScreen PauseScreen;
    public UiScreen GameOverScreen;
    [Space(10)]
    #endregion


    public GameObject player;
    public Enemy[] enemies;

    private RandomManager randomManager;
    private void Start()
    {
        randomManager = gameObject.AddComponent<RandomManager>();

        if (LevelManager.Instance.FirstLaunch())
        {
            //TODO: show tutorial

            StartLevel(1);
        }
        else
        {
            Debug.Log("else");
            Debug.Log(LevelManager.Instance.GetLastSavedLevel());
            StartLevel(LevelManager.Instance.GetLastSavedLevel());
        }
    }

    Level currentLevel;
    public void StartLevel(int level)
    {
        player.GetComponent<RotationController>().enable = true;
        LevelManager.Instance.SetLevel(level);
        GameScreen.levelProgressText.text = level.ToString();
        currentLevel = LevelManager.Instance.levels[level - 1];
        killedEnemies = 0;
        StartCoroutine(InstantiateEnemies(currentLevel));
    }

    List<GameObject> activeEnemies;
    private IEnumerator InstantiateEnemies(Level level)
    {
        activeEnemies = new List<GameObject>();
        for (int i = 0; i < level.EnemyCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.7f,1.2f));

            int random = Random.Range(0, enemies.Length);

            var enemyInstance = Instantiate(enemies[random].gameObject , null);
            enemyInstance.transform.position = randomManager.GetRandomPosition();
            activeEnemyCounter++;

            activeEnemies.Add(enemyInstance);
        }
    }

    public void Restart()
    {
        StopAllCoroutines();
        GameScreen.levelProgress.value = 0;
        activeEnemies.ForEach(delegate (GameObject obj)
        {
            Destroy(obj);
        });
        StartLevel(currentLevel.LevelId);
    }

    public int killedEnemies;
    public void CheckActiveEnemies()
    {
        if (activeEnemyCounter <= 0)
        {
            StartNextLevel();
        }

        GameScreen.levelProgress.value = ((float)killedEnemies / (float)currentLevel.EnemyCount);
    }

    public int activeEnemyCounter;
    internal void StartNextLevel()
    {
        Debug.Log("Next Level");
        StartLevel(LevelManager.Instance.GetLastSavedLevel() + 1);
    }

    public void Die()
    {
        StartCoroutine(player.GetComponent<Player>().Die());
        GameOverScreen.Show(GameScreen);
        player.GetComponent<RotationController>().enable = false;
    }

}
