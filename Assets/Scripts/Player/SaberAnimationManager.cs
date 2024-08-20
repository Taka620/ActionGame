using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberAnimationManager : MonoBehaviour
{
    private Animator animator;

    private void Start() 
    {
        animator = GetComponent<Animator>();    
    }

    public void SetSaberFlip(bool isPlayerFlip)
    {
        if(isPlayerFlip)
        {
            animator.SetBool("is_player_flip", true);
        }
        else
        {
            animator.SetBool("is_player_flip", false);
        }
    }

    public void SetAttackTrigger()
    {
        animator.SetTrigger("attack");
    }

}
