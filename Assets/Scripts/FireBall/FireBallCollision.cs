using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCollision : MonoBehaviour
{
    private const float DAMAGE = 1;
    void OnTriggerEnter(Collider collisionInfo)
    {
        if(collisionInfo.gameObject.CompareTag("Player"))
        {
            collisionInfo.gameObject.GetComponentInParent<PlayerStatus>().TakeDamage(DAMAGE);
            Destroy(this.gameObject);
        }
        else if(collisionInfo.gameObject.CompareTag("Barrier"))
        {
            Destroy(this.gameObject);
        }
    }
}
