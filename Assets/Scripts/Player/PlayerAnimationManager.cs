using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    [SerializeField] private SpriteRenderer sp;
    
    public void SetIsWalking(bool is_walking)
    {
        playerAnim.SetBool("is_walking", is_walking); 
    }

    public void Flip(bool flip)
    {
        if(flip)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }
    }
    
}
