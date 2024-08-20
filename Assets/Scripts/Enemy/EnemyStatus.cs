using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    private const int BOSSHORSEHP = 2500;
    public float HP {get; private set;} = BOSSHORSEHP;
    public float OHP {get; private set;} = BOSSHORSEHP;
    private AudioSource audioSource;
    [SerializeField] private AudioClip takeDMG_SE;
    [SerializeField] private AudioClip start_SE;
    private EnemyCooldown enemyCooldown;

    private void Start() 
    {
        enemyCooldown = GetComponent<EnemyCooldown>();
        audioSource = GetComponent<AudioSource>();
    }
    public void TakeDamage(float damage)
    {
        HP -= damage;
        GameManager.Instance.UpdateEnemyHP();
        if(HP <= 2000)
        {
            enemyCooldown.CheckEnemyLv(2);
        }
        if (HP <= 1000)
        {
            enemyCooldown.CheckEnemyLv(3);
        }
        if(HP <= 300)
        {
            enemyCooldown.CheckEnemyLv(4);
        }
        if(HP <= 150)
        {
            enemyCooldown.CheckEnemyLv(5);
        }
        if (HP <= 0)
        {
            GameManager.Instance.GameClear();
        }
        audioSource.PlayOneShot(takeDMG_SE);
    }
}
