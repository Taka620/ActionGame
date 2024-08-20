using UnityEngine;

public class Saber : MonoBehaviour
{
    public float Damage {get; private set;} = 10;
    [SerializeField] private AudioClip ballBreakSE;
    private AudioSource audioSource;

    private void Start() 
    {
        GetComponentInParent<Collider>().enabled = false;    
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStatus enemyStatus = other.GetComponentInParent<EnemyStatus>();
            if (enemyStatus != null)
            {
                enemyStatus.TakeDamage(Damage); 
            }
        }
        if (other.CompareTag("FireBall"))
        {
            audioSource.PlayOneShot(ballBreakSE);
            other.GetComponent<FireBall>().Broke();
        }

        GetComponentInParent<Collider>().enabled = false;
    }
}
