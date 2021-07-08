using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int stage = 0;
    [SerializeField] int lives = 0;
    public int enemy_counter = 0;
    bool is_on_pause = true;
    bool spawners_state = false;
    public static GameController instanse;
    [SerializeField] GameObject trajectory;
    [SerializeField] GameObject enemy; // убрать
    [SerializeField] Camera cam;
    [SerializeField] int coins = 0;
    int stage_difficult = 0;
    List<ScriptableEnemy> enemies_list;

    public int Coins
    {
        get
        {
            return coins;
        }
        set
        {
            if (value >= 0)
            {
                coins = value;
            }
            else
                coins = 0;
        }
    }
    public Camera Cam
    {
        get
        {
            return cam;
        }
    }
    
    public int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
            if (lives <= 0)
            {
                Debug.Log("GameOwer");
            }
        }
    }
    public int Wave
    {
        get
        {
            return stage;
        }
    }
    public int EnemyCount
    {
        get
        {
            return enemy_counter;
        }
    }
    public void PauseSwitch()
    {
        if (is_on_pause)
            PauseOff();
        else
            PauseOn();
    }
    void PauseOn()
    {
        is_on_pause = true;
        UIController.instance.PlayButtonToPause();
    }
    void PauseOff()
    {
        is_on_pause = false;
        UIController.instance.PlayButtonToPlay();
        StartNewWave();
    }
    public void SpawnEnemy()
    {
        
        for (int i = enemies_list.Count - 1; i >= 0; i--)
        {
            if (enemies_list[i].StageCost <= stage_difficult)
            {
                int next_enemy_cost = Random.Range(1, enemies_list[i].StageCost);
                for (int j = i; j >= 0; j--)
                {
                    if (next_enemy_cost < enemies_list[j].StageCost)
                        continue;
                    stage_difficult -= next_enemy_cost;

                    Instantiate(enemy).GetComponent<Enemy>().InstantEnemy(trajectory.GetComponentInChildren<Spawners>().GetComponentInChildren<Spawner>().gameObject, enemies_list[j]);
                    
                    enemy_counter++;
                }
                break;
            }
        }
        
    }
    private void Awake()
    {
        instanse = this;
    }
    void Start()
    {
        enemies_list = new List<ScriptableEnemy>();
        stage = 0;
        lives = 100;

        for (int i = 0; i < DataController.instance.EnemyData.Data.Length; i++)
            enemies_list.Add(DataController.instance.EnemyData.Data[i]);
        
        bool sort_switch = true;
        bool restart_switch = false;
        while(sort_switch)
        {
            restart_switch = false;
            for (int i = 1; i < enemies_list.Count; i++)
            {
                if (enemies_list[i - 1].StageCost > enemies_list[i].StageCost)
                {
                    ScriptableEnemy buf = enemies_list[i - 1];
                    enemies_list[i - 1] = enemies_list[i];
                    enemies_list[i] = buf;
                    restart_switch = true;
                }
            }
            sort_switch = restart_switch;
        }
    }
    public void StartNewWave()
    {
        if (!is_on_pause)
        {
            stage++;
            stage_difficult = stage * 10;
            StartCoroutine("NewWave");
        }
    }
    IEnumerator NewWave()
    {
        spawners_state = true;
        StartCoroutine("MoreEnemies");
        yield return new WaitForSeconds(5f);
        spawners_state = false;
        StartCoroutine("CheckForMapEmpty");
    }   
    IEnumerator CheckForMapEmpty()
    {
        yield return new WaitForSeconds(1f);
        if (enemy_counter != 0)
            StartCoroutine("CheckForMapEmpty");
        else
            StartNewWave();
    }
    IEnumerator MoreEnemies()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(1f/stage);
        if (spawners_state == true)
            StartCoroutine("MoreEnemies");
    }
    
    void Update()
    {

    }
}
