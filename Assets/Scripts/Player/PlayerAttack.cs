using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject saber;
    private SaberAnimationManager saberAnimationManager;

    private void Start() 
    {
        saberAnimationManager = GetComponentInChildren<SaberAnimationManager>();    
    }

    public void Attack()
    {
        saber.GetComponentInChildren<Collider>().enabled = true;
        saberAnimationManager.SetAttackTrigger();
    }
}

