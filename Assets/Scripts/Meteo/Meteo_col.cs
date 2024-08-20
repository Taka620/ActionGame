using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo_col : MonoBehaviour
{
    private Meteo meteo;
    private void Start() 
    {
        meteo = GetComponentInParent<Meteo>();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<PlayerStatus>().TakeDamage(Meteo.Damage);
        }
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.CompareTag("Ground"))
        {
            meteo.MeteoBurn();
        }
        if(collisionInfo.gameObject.CompareTag("Untagged"))
        {
            meteo.MeteoEnd();
        }
    }

}
