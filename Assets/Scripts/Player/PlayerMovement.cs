using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed {get; private set;} = 20;
    private Rigidbody rb;
    private PlayerAnimationManager playerAnimationManager;
    private SaberAnimationManager saberAnimationManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip moveSE;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 2;

        playerAnimationManager = GetComponent<PlayerAnimationManager>();
        saberAnimationManager = GetComponentInChildren<SaberAnimationManager>();
    }
    public void Move()
    {
        float verticalInput = Input.GetAxisRaw("Vertical") * Speed;
        float horizontalInput = Input.GetAxisRaw("Horizontal") * Speed;
        if(verticalInput != 0 || horizontalInput != 0)
        {
            /*
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(moveSE);
            }
            */

            playerAnimationManager.SetIsWalking(true);
            if(horizontalInput > 0)
            {
                saberAnimationManager.SetSaberFlip(true);
                playerAnimationManager.Flip(true);
            }else if(horizontalInput < 0)
            {
                saberAnimationManager.SetSaberFlip(false);
                playerAnimationManager.Flip(false);
            }
        }
        else
        {
            playerAnimationManager.SetIsWalking(false);
        }

        Vector3 force = new Vector3(horizontalInput, 0, verticalInput);

        rb.AddForce(force, ForceMode.Acceleration);
    }
}
