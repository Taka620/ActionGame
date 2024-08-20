using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 playerPos;
    private SpriteRenderer sp;
    private void Start() 
    {
        playerPos = player.position;
        sp = GetComponentInChildren<SpriteRenderer>();    
    }

    private void Update()
    {
        if (!GameManager.Instance.IsDead)
        {
            playerPos = player.position;
            if (playerPos.x < transform.position.x)
            {
                sp.flipX = true;
            }
            else
            {
                sp.flipX = false;
            }
        }
    }


}
