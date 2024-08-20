using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Scripts")]
    private PlayerMovement playerMovement;
    private PlayerStatus playerStatus;
    private PlayerAttack playerAtack;
    private SaberAnimationManager saberAnimationManager;
    [SerializeField] private AudioClip saberSE;
    [SerializeField] private AudioSource SaberAudioSource;




    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerStatus = GetComponent<PlayerStatus>();
        playerAtack = GetComponent<PlayerAttack>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (!GameManager.Instance.IsDead)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                SaberAudioSource.PlayOneShot(saberSE);
                playerAtack.Attack();
            }
        }
    }
    
    private void FixedUpdate()
    {
        if(!GameManager.Instance.IsDead)
        {
            playerMovement.Move();
        }
    }
}
