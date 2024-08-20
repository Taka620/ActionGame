using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    private Slider enemyHPBar;
    private Slider playerHPBar;


    [Header("Scripts")]
    private PlayerStatus playerStatus;
    private EnemyStatus enemyStatus;
    private Saber saber;

    private GameObject deadScreen;

    public bool IsDead {get; set;}
    private float originalPlayerHP;
    private float originalBossHP;

    [SerializeField] private TextMeshProUGUI timetxt;
    private float time = 0;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start() 
    {
        enemyHPBar = GameObject.Find("BossHP bar").GetComponent<Slider>();
        playerHPBar = GameObject.Find("KnightHP bar").GetComponent<Slider>();
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
        enemyStatus = GameObject.Find("Enemy").GetComponent<EnemyStatus>();
        saber = GameObject.Find("saber").GetComponent<Saber>();
        deadScreen = GameObject.Find("DeadScreen");


        IsDead = false;
        deadScreen.SetActive(false);
        UpdatePlayerHP();    
        UpdateEnemyHP();
        timetxt.maxVisibleCharacters = 10;
        timetxt.text = ("Time: 0");
    }

    private void Update() 
    {
        if(!IsDead)
        {
            time += Time.deltaTime;
            timetxt.text = ("Time: " + time);    
        }
    }

        public void UpdatePlayerHP()
    {
        playerHPBar.value = playerStatus.HP/playerStatus.OHP;
    }

    public void UpdateEnemyHP()
    {
        enemyHPBar.value = enemyStatus.HP/enemyStatus.OHP;
    }

    public void GameClear()
    {
        Debug.Log("Game Clear");
        SceneManager.LoadScene("Clear");
    }

    public void GameOver()
    {
        Debug.Log("GameOver from game Manager");
        IsDead = true;
        time = 0;
        deadScreen.SetActive(true);
    }

}
