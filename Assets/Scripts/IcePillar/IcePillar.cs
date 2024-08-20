using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePillar : MonoBehaviour
{
    private int Damage = 3;
    private float lastTime;
    private float cooltime = 1;
    private bool isAppear;
    
    private void Start() 
    {
        lastTime = 0;    
        isAppear = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<PlayerStatus>().TakeDamage(Damage);
        }
    }

    private void Update() 
    {
        if(this.gameObject.activeSelf && !isAppear)
        {
            lastTime = Time.time;
            isAppear = true;
        }

        if(Time.time - lastTime >= cooltime)
        {
            this.gameObject.SetActive(false);
            isAppear = false;
        }
        
    }

}
